using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Models;
using MCPForUnity.Editor.Services;
using MCPForUnity.Editor.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;

namespace MCPForUnity.Editor.Services.Transport
{
    /// <summary>
    /// Centralised command execution pipeline shared by all transport implementations.
    /// Guarantees that MCP commands are executed on the Unity main thread while preserving
    /// the legacy response format expected by the server.
    /// </summary>
    [InitializeOnLoad]
    internal static class TransportCommandDispatcher
    {
        private static SynchronizationContext _mainThreadContext;
        private static int _mainThreadId;
        private static int _processingFlag;

        private sealed class PendingCommand
        {
            public PendingCommand(
                string commandJson,
                TaskCompletionSource<string> completionSource,
                CancellationToken cancellationToken,
                CancellationTokenRegistration registration)
            {
                CommandJson = commandJson;
                CompletionSource = completionSource;
                CancellationToken = cancellationToken;
                CancellationRegistration = registration;
                QueuedAt = DateTime.UtcNow;
            }

            public string CommandJson { get; }
            public TaskCompletionSource<string> CompletionSource { get; }
            public CancellationToken CancellationToken { get; }
            public CancellationTokenRegistration CancellationRegistration { get; }
            public bool IsExecuting { get; set; }
            public DateTime QueuedAt { get; }

            public void Dispose()
            {
                CancellationRegistration.Dispose();
            }

            public void TrySetResult(string payload)
            {
                CompletionSource.TrySetResult(payload);
            }

            public void TrySetCanceled()
            {
                CompletionSource.TrySetCanceled(CancellationToken);
            }
        }

        private static readonly Dictionary<string, PendingCommand> Pending = new();
        private static readonly object PendingLock = new();
        private static bool updateHooked;
        private static bool initialised;
        internal static string CurrentCommandJson { get; private set; }

        static TransportCommandDispatcher()
        {
            // Ensure this runs on the Unity main thread at editor load.
            _mainThreadContext = SynchronizationContext.Current;
            _mainThreadId = Thread.CurrentThread.ManagedThreadId;

            EnsureInitialised();

            // Always keep the update hook installed so commands arriving from background
            // websocket tasks don't depend on a background-thread event subscription.
            if (!updateHooked)
            {
                updateHooked = true;
                EditorApplication.update += ProcessQueue;
            }
        }

        /// <summary>
        /// Schedule a command for execution on the Unity main thread and await its JSON response.
        /// </summary>
        public static Task<string> ExecuteCommandJsonAsync(string commandJson, CancellationToken cancellationToken)
        {
            if (commandJson is null)
            {
                throw new ArgumentNullException(nameof(commandJson));
            }

            EnsureInitialised();

            var id = Guid.NewGuid().ToString("N");
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            var registration = cancellationToken.CanBeCanceled
                ? cancellationToken.Register(() => CancelPending(id, cancellationToken))
                : default;

            var pending = new PendingCommand(commandJson, tcs, cancellationToken, registration);

            lock (PendingLock)
            {
                Pending[id] = pending;
            }

            // Proactively wake up the main thread execution loop. This improves responsiveness
            // in scenarios where EditorApplication.update is throttled or temporarily not firing
            // (e.g., Unity unfocused, compiling, or during domain reload transitions).
            RequestMainThreadPump();

            return tcs.Task;
        }

        internal static Task<T> RunOnMainThreadAsync<T>(Func<T> func, CancellationToken cancellationToken)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

            var registration = cancellationToken.CanBeCanceled
                ? cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken))
                : default;

            void Invoke()
            {
                try
                {
                    if (tcs.Task.IsCompleted)
                    {
                        return;
                    }

                    var result = func();
                    tcs.TrySetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
                finally
                {
                    registration.Dispose();
                }
            }

            // Best-effort nudge: if we're posting from a background thread (e.g., websocket receive),
            // encourage Unity to run a loop iteration so the posted callback can execute even when unfocused.
            try { EditorApplication.QueuePlayerLoopUpdate(); } catch { }

            if (_mainThreadContext != null && Thread.CurrentThread.ManagedThreadId != _mainThreadId)
            {
                _mainThreadContext.Post(_ => Invoke(), null);
                return tcs.Task;
            }

            Invoke();
            return tcs.Task;
        }

        private static void RequestMainThreadPump()
        {
            void Pump()
            {
                try
                {
                    // Hint Unity to run a loop iteration soon.
                    EditorApplication.QueuePlayerLoopUpdate();
                }
                catch
                {
                    // Best-effort only.
                }

                ProcessQueue();
            }

            if (_mainThreadContext != null && Thread.CurrentThread.ManagedThreadId != _mainThreadId)
            {
                _mainThreadContext.Post(_ => Pump(), null);
                return;
            }

            Pump();
        }

        private static void EnsureInitialised()
        {
            if (initialised)
            {
                return;
            }

            CommandRegistry.Initialize();
            initialised = true;
        }

        private static void HookUpdate()
        {
            // Deprecated: we keep the update hook installed permanently (see static ctor).
            if (updateHooked) return;
            updateHooked = true;
            EditorApplication.update += ProcessQueue;
        }

        private static void UnhookUpdateIfIdle()
        {
            // Intentionally no-op: keep update hook installed so background commands always process.
            // This avoids "must focus Unity to re-establish contact" edge cases.
            return;
        }

        private static void ProcessQueue()
        {
            if (Interlocked.Exchange(ref _processingFlag, 1) == 1)
            {
                return;
            }

            try
            {
            List<(string id, PendingCommand pending)> ready;

            lock (PendingLock)
            {
                // Early exit inside lock to prevent per-frame List allocations (GitHub issue #577)
                if (Pending.Count == 0)
                {
                    return;
                }

                ready = new List<(string, PendingCommand)>(Pending.Count);
                foreach (var kvp in Pending)
                {
                    if (kvp.Value.IsExecuting)
                    {
                        continue;
                    }

                    kvp.Value.IsExecuting = true;
                    ready.Add((kvp.Key, kvp.Value));
                }

                if (ready.Count == 0)
                {
                    UnhookUpdateIfIdle();
                    return;
                }
            }

            foreach (var (id, pending) in ready)
            {
                ProcessCommand(id, pending);
            }
            }
            finally
            {
                Interlocked.Exchange(ref _processingFlag, 0);
            }
        }

        private static void ProcessCommand(string id, PendingCommand pending)
        {
            if (pending.CancellationToken.IsCancellationRequested)
            {
                RemovePending(id, pending);
                pending.TrySetCanceled();
                return;
            }

            string commandText = pending.CommandJson?.Trim();
            if (string.IsNullOrEmpty(commandText))
            {
                pending.TrySetResult(SerializeError("Empty command received"));
                RemovePending(id, pending);
                return;
            }

            if (string.Equals(commandText, "ping", StringComparison.OrdinalIgnoreCase))
            {
                pending.TrySetResult("{\"status\":\"success\",\"result\":{\"message\":\"pong\"}}");
                RemovePending(id, pending);
                return;
            }

            if (!IsValidJson(commandText))
            {
                pending.TrySetResult(SerializeError(
                    "Invalid JSON format",
                    null,
                    null,
                    commandText.Length > 50 ? commandText[..50] + "..." : commandText));
                RemovePending(id, pending);
                return;
            }

            try
            {
                string commandType = ExtractJsonString(commandText, "type");
                if (commandType == null)
                {
                    commandType = ExtractJsonString(commandText, "command");
                }

                if (string.IsNullOrWhiteSpace(commandType))
                {
                    pending.TrySetResult(SerializeError("Command type cannot be empty"));
                    RemovePending(id, pending);
                    return;
                }

                if (string.Equals(commandType, "ping", StringComparison.OrdinalIgnoreCase))
                {
                    pending.TrySetResult("{\"status\":\"success\",\"result\":{\"message\":\"pong\"}}");
                    RemovePending(id, pending);
                    return;
                }

                var parameters = ExtractJsonObject(commandText, "params");
                if (parameters == null)
                {
                    parameters = ParseFlatJsonObject(commandText);
                    parameters.Remove("type");
                    parameters.Remove("command");
                }
                // Block execution of disabled resources
                var resourceMeta = MCPServiceLocator.ResourceDiscovery.GetResourceMetadata(commandType);
                if (resourceMeta != null && !MCPServiceLocator.ResourceDiscovery.IsResourceEnabled(commandType))
                {
                    pending.TrySetResult(SerializeError(
                        $"Resource '{commandType}' is disabled in the Unity Editor."));
                    RemovePending(id, pending);
                    return;
                }

                // Block execution of disabled tools
                var toolMeta = MCPServiceLocator.ToolDiscovery.GetToolMetadata(commandType);
                if (toolMeta != null && !MCPServiceLocator.ToolDiscovery.IsToolEnabled(commandType))
                {
                    pending.TrySetResult(SerializeError(
                        $"Tool '{commandType}' is disabled in the Unity Editor."));
                    RemovePending(id, pending);
                    return;
                }

                var logType = resourceMeta != null ? "resource" : toolMeta != null ? "tool" : "unknown";
                var sw = McpLogRecord.IsEnabled ? System.Diagnostics.Stopwatch.StartNew() : null;
                CurrentCommandJson = commandText;
                var result = CommandRegistry.ExecuteCommand(commandType, parameters, pending.CompletionSource);

                if (result == null)
                {
                    // Async command – cleanup after completion on next editor frame to preserve order.
                    var capturedType = commandType;
                    var capturedParams = parameters;
                    var capturedLogType = logType;
                    pending.CompletionSource.Task.ContinueWith(t =>
                    {
                        sw?.Stop();
                        var logStatus = "SUCCESS";
                        string logError = null;
                        if (t.IsFaulted)
                        {
                            logStatus = "ERROR";
                            logError = t.Exception?.InnerException?.Message;
                        }
                        else if (t.IsCompletedSuccessfully && t.Result != null)
                        {
                            try
                            {
                                var resultObj = JObject.Parse(t.Result);
                                if (string.Equals(resultObj.Value<string>("status"), "error", StringComparison.OrdinalIgnoreCase))
                                {
                                    logStatus = "ERROR";
                                    logError = resultObj.Value<string>("error");
                                }
                            }
                            catch { }
                        }
                        McpLogRecord.Log(capturedType, capturedParams, capturedLogType,
                            logStatus, sw?.ElapsedMilliseconds ?? 0, logError);
                        EditorApplication.delayCall += () => RemovePending(id, pending);
                    }, TaskScheduler.Default);
                    return;
                }

                sw?.Stop();

                string syncLogStatus = "SUCCESS";
                string syncLogError = null;
                if (result is ErrorResponse errResp)
                {
                    syncLogStatus = "ERROR";
                    syncLogError = errResp.Error;
                }
                McpLogRecord.Log(commandType, parameters, logType, syncLogStatus, sw?.ElapsedMilliseconds ?? 0, syncLogError);

                pending.TrySetResult(SerializeSuccess(result));
                RemovePending(id, pending);
            }
            catch (Exception ex)
            {
                McpLog.Error($"Error processing command: {ex.Message}\n{ex.StackTrace}");
                pending.TrySetResult(SerializeError(ex.Message, "Unknown (error during processing)", ex.StackTrace));
                RemovePending(id, pending);
            }
        }

        private static void CancelPending(string id, CancellationToken token)
        {
            PendingCommand pending = null;
            lock (PendingLock)
            {
                if (Pending.Remove(id, out pending))
                {
                    UnhookUpdateIfIdle();
                }
            }

            pending?.TrySetCanceled();
            pending?.Dispose();
        }

        private static void RemovePending(string id, PendingCommand pending)
        {
            lock (PendingLock)
            {
                Pending.Remove(id);
                UnhookUpdateIfIdle();
            }

            pending.Dispose();
        }

        private static string SerializeSuccess(object result)
        {
            return "{\"status\":\"success\",\"result\":" + SerializeJsonValue(result) + "}";
        }

        private static string SerializeError(string message, string commandType = null, string stackTrace = null, string receivedText = null)
        {
            var builder = new StringBuilder();
            builder.Append("{\"status\":\"error\",\"error\":");
            builder.Append(SerializeJsonString(message ?? "Unknown error"));
            builder.Append(",\"command\":");
            builder.Append(SerializeJsonString(commandType ?? "Unknown"));
            if (stackTrace != null)
            {
                builder.Append(",\"stackTrace\":");
                builder.Append(SerializeJsonString(stackTrace));
            }
            if (receivedText != null)
            {
                builder.Append(",\"receivedText\":");
                builder.Append(SerializeJsonString(receivedText));
            }
            builder.Append('}');
            return builder.ToString();
        }

        private static string SerializeJsonValue(object value, int depth = 0)
        {
            if (value == null)
            {
                return "null";
            }

            if (depth > 12)
            {
                return SerializeJsonString(value.ToString());
            }

            if (value is SuccessResponse successResponse)
            {
                var builder = new StringBuilder();
                builder.Append("{\"Success\":true,\"success\":true,\"Message\":");
                builder.Append(SerializeJsonString(successResponse.Message));
                if (successResponse.Data != null)
                {
                    builder.Append(",\"Data\":");
                    builder.Append(SerializeJsonValue(successResponse.Data, depth + 1));
                    builder.Append(",\"data\":");
                    builder.Append(SerializeJsonValue(successResponse.Data, depth + 1));
                }
                builder.Append('}');
                return builder.ToString();
            }

            if (value is ErrorResponse errorResponse)
            {
                var builder = new StringBuilder();
                builder.Append("{\"Success\":false,\"success\":false,\"Code\":");
                builder.Append(SerializeJsonString(errorResponse.Code));
                builder.Append(",\"Error\":");
                builder.Append(SerializeJsonString(errorResponse.Error));
                builder.Append(",\"error\":");
                builder.Append(SerializeJsonString(errorResponse.Error));
                if (errorResponse.Data != null)
                {
                    builder.Append(",\"Data\":");
                    builder.Append(SerializeJsonValue(errorResponse.Data, depth + 1));
                    builder.Append(",\"data\":");
                    builder.Append(SerializeJsonValue(errorResponse.Data, depth + 1));
                }
                builder.Append('}');
                return builder.ToString();
            }

            switch (value)
            {
                case string s:
                    return SerializeJsonString(s);
                case bool b:
                    return b ? "true" : "false";
                case byte or sbyte or short or ushort or int or uint or long or ulong or float or double or decimal:
                    return Convert.ToString(value, CultureInfo.InvariantCulture);
                case Enum e:
                    return SerializeJsonString(e.ToString());
                case JValue jValue:
                    return SerializeJsonValue(jValue.Value, depth + 1);
                case JObject jObject:
                    return SerializeJObject(jObject, depth + 1);
                case JArray jArray:
                    return SerializeJArray(jArray, depth + 1);
                case JToken token:
                    return SerializeJsonString(token.ToString(Formatting.None));
                case IDictionary dictionary:
                    return SerializeDictionary(dictionary, depth + 1);
                case IEnumerable enumerable:
                    return SerializeEnumerable(enumerable, depth + 1);
            }

            return SerializeObjectProperties(value, depth + 1);
        }

        private static string SerializeJObject(JObject obj, int depth)
        {
            var builder = new StringBuilder();
            builder.Append('{');
            bool first = true;
            var properties = new List<JProperty>();
            try
            {
                foreach (var property in obj.Properties())
                {
                    properties.Add(property);
                }
            }
            catch
            {
                return "{}";
            }

            foreach (var property in properties)
            {
                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonString(property.Name));
                builder.Append(':');
                builder.Append(SerializeJsonValue(property.Value, depth + 1));
            }
            builder.Append('}');
            return builder.ToString();
        }

        private static string SerializeJArray(JArray array, int depth)
        {
            var builder = new StringBuilder();
            builder.Append('[');
            bool first = true;
            var items = new List<JToken>();
            try
            {
                foreach (var item in array)
                {
                    items.Add(item);
                }
            }
            catch
            {
                return "[]";
            }

            foreach (var item in items)
            {
                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonValue(item, depth + 1));
            }
            builder.Append(']');
            return builder.ToString();
        }

        private static string SerializeDictionary(IDictionary dictionary, int depth)
        {
            var builder = new StringBuilder();
            builder.Append('{');
            bool first = true;
            foreach (DictionaryEntry entry in dictionary)
            {
                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonString(Convert.ToString(entry.Key, CultureInfo.InvariantCulture)));
                builder.Append(':');
                builder.Append(SerializeJsonValue(entry.Value, depth + 1));
            }
            builder.Append('}');
            return builder.ToString();
        }

        private static string SerializeEnumerable(IEnumerable enumerable, int depth)
        {
            var builder = new StringBuilder();
            builder.Append('[');
            bool first = true;
            foreach (var item in enumerable)
            {
                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonValue(item, depth + 1));
            }
            builder.Append(']');
            return builder.ToString();
        }

        private static string SerializeObjectProperties(object value, int depth)
        {
            var builder = new StringBuilder();
            builder.Append('{');
            bool first = true;
            Type type = value.GetType();

            foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (!property.CanRead || property.GetIndexParameters().Length != 0)
                {
                    continue;
                }

                object propertyValue;
                try { propertyValue = property.GetValue(value); }
                catch { continue; }

                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonString(property.Name));
                builder.Append(':');
                builder.Append(SerializeJsonValue(propertyValue, depth + 1));
            }

            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                object fieldValue;
                try { fieldValue = field.GetValue(value); }
                catch { continue; }

                if (!first) builder.Append(',');
                first = false;
                builder.Append(SerializeJsonString(field.Name));
                builder.Append(':');
                builder.Append(SerializeJsonValue(fieldValue, depth + 1));
            }

            builder.Append('}');
            return builder.ToString();
        }

        private static string SerializeJsonString(string value)
        {
            if (value == null)
            {
                return "null";
            }

            var builder = new StringBuilder(value.Length + 2);
            builder.Append('"');
            foreach (char c in value)
            {
                switch (c)
                {
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        if (char.IsControl(c))
                        {
                            builder.Append("\\u");
                            builder.Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            builder.Append(c);
                        }
                        break;
                }
            }
            builder.Append('"');
            return builder.ToString();
        }

        private static string ExtractString(JToken token)
        {
            if (token == null || token.Type == JTokenType.Null)
            {
                return null;
            }

            if (token is JValue value)
            {
                return value.Value?.ToString();
            }

            return token.ToString();
        }

        private static string ExtractJsonString(string json, string propertyName)
        {
            string raw = ExtractJsonRawValue(json, propertyName);
            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            raw = raw.Trim();
            if (raw.Length >= 2 && raw[0] == '"' && raw[^1] == '"')
            {
                return UnescapeJsonString(raw.Substring(1, raw.Length - 2));
            }

            if (string.Equals(raw, "null", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return raw;
        }

        private static JObject ExtractJsonObject(string json, string propertyName)
        {
            string raw = ExtractJsonRawValue(json, propertyName);
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.Trim();
            if (!raw.StartsWith("{") || !raw.EndsWith("}"))
            {
                return null;
            }

            return ParseFlatJsonObject(raw);
        }

        private static JObject ParseFlatJsonObject(string raw)
        {
            var obj = new JObject();
            int i = 1;
            while (i < raw.Length - 1)
            {
                while (i < raw.Length && (char.IsWhiteSpace(raw[i]) || raw[i] == ','))
                {
                    i++;
                }

                if (i >= raw.Length - 1 || raw[i] != '"')
                {
                    break;
                }

                int keyEnd = FindJsonStringEnd(raw, i);
                if (keyEnd < 0)
                {
                    break;
                }

                string key = UnescapeJsonString(raw.Substring(i + 1, keyEnd - i - 1));
                i = keyEnd + 1;
                while (i < raw.Length && char.IsWhiteSpace(raw[i]))
                {
                    i++;
                }
                if (i >= raw.Length || raw[i] != ':')
                {
                    break;
                }

                i++;
                while (i < raw.Length && char.IsWhiteSpace(raw[i]))
                {
                    i++;
                }
                if (i >= raw.Length)
                {
                    break;
                }

                int valueEnd;
                char first = raw[i];
                if (first == '"')
                {
                    valueEnd = FindJsonStringEnd(raw, i);
                }
                else if (first == '{' || first == '[')
                {
                    valueEnd = FindJsonContainerEnd(raw, i, first, first == '{' ? '}' : ']');
                }
                else
                {
                    valueEnd = i;
                    while (valueEnd < raw.Length && raw[valueEnd] != ',' && raw[valueEnd] != '}')
                    {
                        valueEnd++;
                    }
                    valueEnd--;
                }

                if (valueEnd < i)
                {
                    break;
                }

                string valueRaw = raw.Substring(i, valueEnd - i + 1).Trim();
                obj.Add(new JProperty(key, ParseFlatJsonValue(valueRaw)));
                i = valueEnd + 1;
            }

            return obj;
        }

        private static JToken ParseFlatJsonValue(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw) || string.Equals(raw, "null", StringComparison.OrdinalIgnoreCase))
            {
                return JValue.CreateNull();
            }

            raw = raw.Trim();
            if (raw.Length >= 2 && raw[0] == '"' && raw[^1] == '"')
            {
                return new JValue(UnescapeJsonString(raw.Substring(1, raw.Length - 2)));
            }

            if (string.Equals(raw, "true", StringComparison.OrdinalIgnoreCase))
            {
                return new JValue(true);
            }

            if (string.Equals(raw, "false", StringComparison.OrdinalIgnoreCase))
            {
                return new JValue(false);
            }

            if (raw.StartsWith("[") && raw.EndsWith("]"))
            {
                return ParseFlatJsonArray(raw);
            }

            if (raw.StartsWith("{") && raw.EndsWith("}"))
            {
                return ParseFlatJsonObject(raw);
            }

            if (long.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out long longValue))
            {
                return new JValue(longValue);
            }

            if (double.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
            {
                return new JValue(doubleValue);
            }

            return new JValue(raw);
        }

        private static JArray ParseFlatJsonArray(string raw)
        {
            var array = new JArray();
            int i = 1;
            while (i < raw.Length - 1)
            {
                while (i < raw.Length && (char.IsWhiteSpace(raw[i]) || raw[i] == ','))
                {
                    i++;
                }

                if (i >= raw.Length - 1)
                {
                    break;
                }

                int valueEnd;
                char first = raw[i];
                if (first == '"')
                {
                    valueEnd = FindJsonStringEnd(raw, i);
                }
                else if (first == '{' || first == '[')
                {
                    valueEnd = FindJsonContainerEnd(raw, i, first, first == '{' ? '}' : ']');
                }
                else
                {
                    valueEnd = i;
                    while (valueEnd < raw.Length && raw[valueEnd] != ',' && raw[valueEnd] != ']')
                    {
                        valueEnd++;
                    }
                    valueEnd--;
                }

                if (valueEnd < i)
                {
                    break;
                }

                array.Add(ParseFlatJsonValue(raw.Substring(i, valueEnd - i + 1)));
                i = valueEnd + 1;
            }

            return array;
        }

        private static string ExtractJsonRawValue(string json, string propertyName)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            string key = "\"" + propertyName + "\"";
            int keyIndex = json.IndexOf(key, StringComparison.Ordinal);
            if (keyIndex < 0)
            {
                return null;
            }

            int colonIndex = json.IndexOf(':', keyIndex + key.Length);
            if (colonIndex < 0)
            {
                return null;
            }

            int valueStart = colonIndex + 1;
            while (valueStart < json.Length && char.IsWhiteSpace(json[valueStart]))
            {
                valueStart++;
            }

            if (valueStart >= json.Length)
            {
                return null;
            }

            char first = json[valueStart];
            if (first == '"')
            {
                int end = FindJsonStringEnd(json, valueStart);
                return end > valueStart ? json.Substring(valueStart, end - valueStart + 1) : null;
            }

            if (first == '{' || first == '[')
            {
                int end = FindJsonContainerEnd(json, valueStart, first, first == '{' ? '}' : ']');
                return end > valueStart ? json.Substring(valueStart, end - valueStart + 1) : null;
            }

            int valueEnd = valueStart;
            while (valueEnd < json.Length && json[valueEnd] != ',' && json[valueEnd] != '}')
            {
                valueEnd++;
            }

            return json.Substring(valueStart, valueEnd - valueStart).Trim();
        }

        private static int FindJsonStringEnd(string json, int start)
        {
            bool escaping = false;
            for (int i = start + 1; i < json.Length; i++)
            {
                char c = json[i];
                if (escaping)
                {
                    escaping = false;
                    continue;
                }
                if (c == '\\')
                {
                    escaping = true;
                    continue;
                }
                if (c == '"')
                {
                    return i;
                }
            }
            return -1;
        }

        private static int FindJsonContainerEnd(string json, int start, char open, char close)
        {
            int depth = 0;
            bool inString = false;
            bool escaping = false;
            for (int i = start; i < json.Length; i++)
            {
                char c = json[i];
                if (inString)
                {
                    if (escaping)
                    {
                        escaping = false;
                    }
                    else if (c == '\\')
                    {
                        escaping = true;
                    }
                    else if (c == '"')
                    {
                        inString = false;
                    }
                    continue;
                }

                if (c == '"')
                {
                    inString = true;
                    continue;
                }

                if (c == open)
                {
                    depth++;
                }
                else if (c == close)
                {
                    depth--;
                    if (depth == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private static string UnescapeJsonString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var builder = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c != '\\' || i + 1 >= value.Length)
                {
                    builder.Append(c);
                    continue;
                }

                char next = value[++i];
                switch (next)
                {
                    case '"': builder.Append('"'); break;
                    case '\\': builder.Append('\\'); break;
                    case '/': builder.Append('/'); break;
                    case 'b': builder.Append('\b'); break;
                    case 'f': builder.Append('\f'); break;
                    case 'n': builder.Append('\n'); break;
                    case 'r': builder.Append('\r'); break;
                    case 't': builder.Append('\t'); break;
                    case 'u':
                        if (i + 4 < value.Length && int.TryParse(value.Substring(i + 1, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int code))
                        {
                            builder.Append((char)code);
                            i += 4;
                        }
                        break;
                    default:
                        builder.Append(next);
                        break;
                }
            }
            return builder.ToString();
        }

        private static bool IsValidJson(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || (text.StartsWith("[") && text.EndsWith("]")))
            {
                try
                {
                    JToken.Parse(text);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
