using System;
using System.Collections.Generic;
using System.Linq;
using MCPForUnity.Editor.Clients;
using MCPForUnity.Editor.Helpers;
using MCPForUnity.Editor.Models;

namespace MCPForUnity.Editor.Services
{
    /// <summary>
    /// Implementation of client configuration service
    /// </summary>
    public class ClientConfigurationService : IClientConfigurationService
    {
        private readonly List<IMcpClientConfigurator> configurators;

        public ClientConfigurationService()
        {
            configurators = McpClientRegistry.All.ToList();
        }

        public IReadOnlyList<IMcpClientConfigurator> GetAllClients() => configurators;

        public void ConfigureClient(IMcpClientConfigurator configurator)
        {
            // When using a local server path, clean stale build artifacts first.
            // This prevents old deleted .py files from being picked up by Python's auto-discovery.
            if (AssetPathUtility.IsLocalServerPath())
            {
                AssetPathUtility.CleanLocalServerBuildArtifacts();
            }

            ConfigureWithTransportCoercion(configurator);
        }

        public ClientConfigurationSummary ConfigureAllDetectedClients()
        {
            // When using a local server path, clean stale build artifacts once before configuring all clients.
            if (AssetPathUtility.IsLocalServerPath())
            {
                AssetPathUtility.CleanLocalServerBuildArtifacts();
            }

            var summary = new ClientConfigurationSummary();
            foreach (var configurator in configurators)
            {
                if (!configurator.IsInstalled)
                {
                    summary.SkippedCount++;
                    continue;
                }
                try
                {
                    // Always re-run configuration so core fields stay current
                    configurator.CheckStatus(attemptAutoRewrite: false);
                    ConfigureWithTransportCoercion(configurator);
                    summary.SuccessCount++;
                    summary.Messages.Add($"✓ {configurator.DisplayName}: Configured successfully");
                }
                catch (Exception ex)
                {
                    summary.FailureCount++;
                    summary.Messages.Add($"⚠ {configurator.DisplayName}: {ex.Message}");
                }
            }

            return summary;
        }

        private static void ConfigureWithTransportCoercion(IMcpClientConfigurator configurator)
        {
            try
            {
                EditorConfigurationCache.Instance.SetUseHttpTransport(true);
                CoerceTransportFor(configurator);
                configurator.Configure();
            }
            finally
            {
                EditorConfigurationCache.Instance.SetUseHttpTransport(true);
            }
        }

        public bool CheckClientStatus(IMcpClientConfigurator configurator, bool attemptAutoRewrite = true)
        {
            var previous = configurator.Status;
            var current = configurator.CheckStatus(attemptAutoRewrite);
            return current != previous;
        }

        private static void CoerceTransportFor(IMcpClientConfigurator configurator)
        {
            var supported = configurator.SupportedTransports;
            if (supported == null || supported.Count == 0) return;

            var requested = ConfiguredTransport.Http;

            // Accept any HTTP variant (Http, HttpRemote) when the user wants HTTP — a client that
            // only supports HttpRemote should not get coerced to stdio just because Http isn't
            // explicitly listed.
            if (SupportsRequested(supported, requested)) return;

            // Stdio is disabled for this project, so never coerce client setup away from HTTP.
            ConfiguredTransport chosen = PickFallback(supported, requested);
            bool needHttp = IsHttpVariant(chosen);
            if (!needHttp)
            {
                McpLog.Info(
                    $"[{configurator.DisplayName}] skipped stdio fallback because stdio transport is disabled.");
                return;
            }

            if (EditorConfigurationCache.Instance.UseHttpTransport != needHttp)
            {
                EditorConfigurationCache.Instance.SetUseHttpTransport(true);
                McpLog.Info(
                    $"[{configurator.DisplayName}] auto-selected {chosen} transport (client does not support {requested}).");
            }
        }

        private static bool IsHttpVariant(ConfiguredTransport t)
            => t == ConfiguredTransport.Http || t == ConfiguredTransport.HttpRemote;

        private static bool SupportsRequested(IReadOnlyList<ConfiguredTransport> supported, ConfiguredTransport requested)
        {
            if (requested == ConfiguredTransport.Http)
            {
                foreach (var t in supported)
                    if (IsHttpVariant(t)) return true;
                return false;
            }
            return supported.Contains(requested);
        }

        private static ConfiguredTransport PickFallback(IReadOnlyList<ConfiguredTransport> supported, ConfiguredTransport requested)
        {
            if (requested == ConfiguredTransport.Http)
            {
                foreach (var t in supported)
                    if (IsHttpVariant(t)) return t;
            }
            return supported[0];
        }
    }
}
