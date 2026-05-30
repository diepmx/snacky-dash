using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using Voodoo.Sauce.Core;
using Voodoo.Sauce.Internal.DebugScreen;
using Voodoo.Sauce.Privacy;
using Voodoo.Tune.Core;

namespace Voodoo.Sauce.Debugger
{
	public class EnvironmentDebugScreen : Screen, IConditionalScreen
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFetchAndSaveNewVersion_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public Status status;

			private TaskAwaiter<VersionMetadata> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CVoodooTuneSwitchVersion_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Status version;

			public EnvironmentDebugScreen _003C_003E4__this;

			public bool isOn;

			private Status _003Cformer_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		private const string TAG = "EnvironmentDebugScreen";

		private const string NEW_SERVER_MESSAGE = "Your {0} server is set to {1}, restart the application to apply the modifications.";

		private const string NEW_VOODOO_TUNE_VERSION_MESSAGE = "Your VoodooTune version is set to {0}, restart the application to apply the modifications.";

		private const string LOADING_MESSAGE = "\n\nUpdating the environment, please wait...\n\n";

		private const string GENERAL_ERROR_MESSAGE = "An error happened while trying to update the environment.\nPlease check your connection and retry";

		[SerializeField]
		private DebugPopup _debugPopup;

		private readonly Dictionary<EnvironmentSettings.Server, string> _server;

		private VoodooTuneServerType _voodooTuneServer;

		private Dictionary<VoodooTuneServerType, DebugToggleButton> _vtToggle;

		private Status _voodooTuneVersion;

		private Dictionary<Status, DebugToggleButton> _versionToggle;

		private EnvironmentSettings.Server _analyticsServer;

		private Dictionary<EnvironmentSettings.Server, DebugToggleButton> _analyticsToggle;

		private PrivacyCore _privacyCore;

		private PrivacyEnvironment _privacyServer;

		private Dictionary<PrivacyEnvironment, DebugToggleButton> _privacyToggle;

		public bool CanDisplay => false;

		private string VtNewVersion => null;

		private void Start()
		{
		}

		private void InitProxyServerSection(VoodooSettings settings)
		{
		}

		private void InitVoodooTune(VoodooSettings settings)
		{
		}

		private void InitVoodooTuneServerButtons()
		{
		}

		private void InitVoodooTuneVersionButtons()
		{
		}

		private void VoodooTuneServerSwitch(bool isOn, VoodooTuneServerType server)
		{
		}

		[AsyncStateMachine(typeof(_003CVoodooTuneSwitchVersion_003Ed__26))]
		private Task VoodooTuneSwitchVersion(bool isOn, Status version)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFetchAndSaveNewVersion_003Ed__27))]
		private Task<bool> FetchAndSaveNewVersion(Status status)
		{
			return null;
		}

		private void DisplayErrorUpdatingEnvironmentMessage()
		{
		}

		private void DisplayNewVersionUpdatedMessage()
		{
		}

		private void DisplayUpdatingEnvironmentMessage()
		{
		}

		private void InitAnalytics(VoodooSettings settings)
		{
		}

		private void InitAnalyticsServerButtons()
		{
		}

		private void AnalyticsServerSwitch(bool isOn, EnvironmentSettings.Server server)
		{
		}

		private void InitPrivacy()
		{
		}

		private void InitPrivacyServerButtons()
		{
		}

		private void SwitchPrivacyServer(bool isOn, PrivacyEnvironment server)
		{
		}

		private void DisplayPopup(string message)
		{
		}
	}
}
