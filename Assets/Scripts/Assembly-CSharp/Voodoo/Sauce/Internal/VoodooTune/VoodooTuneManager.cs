using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Voodoo.Sauce.Internal.Analytics;
using Voodoo.Tune.Core;

namespace Voodoo.Sauce.Internal.VoodooTune
{
	public static class VoodooTuneManager
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public bool hasTimedOut;

			public string url;

			public HttpResponseMessage response;

			public Stopwatch watch;

			public bool initFinishedInvoked;

			internal void _003CLoadConfiguration_003Eb__1()
			{
			}

			internal void _003CLoadConfiguration_003Eb__0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadConfiguration_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			private HttpClient _003Cclient_003E5__2;

			private CancellationTokenSource _003Ccts_003E5__3;

			private Task _003CuiTimeoutTask_003E5__4;

			private Task<HttpResponseMessage> _003CresponseTask_003E5__5;

			private Task _003CcompletedTask_003E5__6;

			private ConfiguredTaskAwaitable<Task>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const string TAG = "VoodooTuneManager";

		private const int DEFAULT_INIT_TIMEOUT_IN_MILLISECONDS_WITHOUT_CACHE = 3000;

		private static readonly VoodooTuneConfigurationManager _configurationManager;

		private static bool _initCalled;

		private static bool _initFinished;

		private static Action _initFinishedCallback;

		private static bool _initFinishedCallbackInvoked;

		internal static VoodooTuneInitAnalyticsInfoLog LastVoodooTuneInitInfo;

		private static VoodooTuneAbTestsTracker abTestTracker;

		private static VoodooTuneSegmentationManager segmentationManager;

		private static bool HasCache => false;

		private static bool IsAbTestValid => false;

		public static int CurrentTimeoutInMilliseconds { get; private set; }

		public static void Initialize(Action initFinishedCallback)
		{
		}

		private static void SetTimeout()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadConfiguration_003Ed__20))]
		private static Task LoadConfiguration()
		{
			return null;
		}

		private static void CancelInitRequestInternetReachability(string errorMessage, int callDuration)
		{
		}

		private static void CancelInitRequestTimeout(string errorMessage, int callDuration)
		{
		}

		private static void SaveConfiguration(ConfigResponse config, RsConfigStatusOrigin origin, bool hasTimedOut)
		{
		}

		private static void HandleConfigResponseInvalid(ConfigResponse config, RsConfigStatusOrigin origin, bool hasTimeOut)
		{
		}

		private static void HandleConfigResponseSuccessTimeout(ConfigResponse config, RsConfigStatusOrigin origin)
		{
		}

		private static void HandleConfigResponseSuccess(ConfigResponse config, RsConfigStatusOrigin origin)
		{
		}

		private static void TrackValidApplyConfigEvent(RsConfigStatusOrigin origin)
		{
		}

		private static void TrackInvalidApplyConfigEvent(bool hasTimeOut)
		{
		}

		private static void TrackLastInitConfigStatusEvent(RsConfigStatusOrigin origin, string errorMessage = "")
		{
		}

		private static void LogRequestDuration(double requestDuration, string message)
		{
		}

		private static bool IsResponseValid(string response, long responseCode)
		{
			return false;
		}

		private static long SaveAndApplyConfig(string response)
		{
			return 0L;
		}

		private static string BuildErrorMessage(string response, long responseCode, string error)
		{
			return null;
		}

		private static void TrackAbTestModifications(string response)
		{
		}

		private static void UpdateLastInitInfo(ConfigResponse config, bool hasTimedOut, long? deserializationDuration, string message)
		{
		}

		private static void UpdateLastInitInfoAsTimeout(string errorMessage, double durationMs)
		{
		}

		private static void TrackPreBuildConfig()
		{
		}

		private static void RaiseInitializationFinishedCallback()
		{
		}

		public static List<T> GetSubclassesItems<T>() where T : class, new()
		{
			return null;
		}

		public static List<T> GetItems<T>() where T : class, new()
		{
			return null;
		}

		public static List<T> GetItemsOrDefaults<T>() where T : class, new()
		{
			return null;
		}

		public static T GetItem<T>() where T : class, new()
		{
			return null;
		}

		public static T GetItemOrDefault<T>() where T : class, new()
		{
			return null;
		}

		public static string GetConfigurationId()
		{
			return null;
		}

		public static string GetSegmentationUuid()
		{
			return null;
		}

		public static List<string> GetSegmentationUuidsAsList()
		{
			return null;
		}

		public static string GetMainAbTestUuid()
		{
			return null;
		}

		public static List<string> GetAbTestUuidsAsList()
		{
			return null;
		}

		public static string GetAbTestUuids()
		{
			return null;
		}

		public static string GetMainAbTestCohortName()
		{
			return null;
		}

		public static string GetMainAbTestCohortUuid()
		{
			return null;
		}

		public static List<string> GetAbTestCohortUuidsAsList()
		{
			return null;
		}

		public static string GetAbTestCohortUuids()
		{
			return null;
		}

		public static string GetAbTestTreatmentUuids()
		{
			return null;
		}

		public static List<string> GetAbTestTreatmentUuidsAsList()
		{
			return null;
		}

		public static List<string> GetAbTestCohortNamesAsList()
		{
			return null;
		}

		public static string GetAbTestCohortNames()
		{
			return null;
		}

		public static string GetAbTestVersionUuid()
		{
			return null;
		}

		public static bool GetDebuggerAuthorization()
		{
			return false;
		}

		public static string GetRawConfiguration()
		{
			return null;
		}

		public static Dictionary<string, string> GetItemsJson()
		{
			return null;
		}

		public static string GetNextSessionConfigurationUrl()
		{
			return null;
		}
	}
}
