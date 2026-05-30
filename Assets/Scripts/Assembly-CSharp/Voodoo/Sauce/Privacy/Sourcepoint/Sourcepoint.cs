using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ConsentManagementProvider;
using UnityEngine.Scripting;
using Voodoo.Sauce.Core.Model;
using Voodoo.Sauce.Privacy.UI;

namespace Voodoo.Sauce.Privacy.Sourcepoint
{
	[Preserve]
	public class Sourcepoint : IConsentManagementProvider
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass26_0
		{
			public bool waitUserConsent;

			public CmpConsent cmpConsent;

			public Sourcepoint _003C_003E4__this;

			public bool consentUpdated;

			internal void _003CShowPrivacyScreen_003Eb__0(SpConsents spConsents)
			{
			}

			internal void _003CShowPrivacyScreen_003Eb__1()
			{
			}

			internal void _003CShowPrivacyScreen_003Eb__2(Exception exception)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAskConsent_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<CmpConsent> _003C_003Et__builder;

			public Sourcepoint _003C_003E4__this;

			private TaskAwaiter<CmpConsent> _003C_003Eu__1;

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
		private struct _003CShowPrivacyScreen_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<CmpConsent> _003C_003Et__builder;

			public Sourcepoint _003C_003E4__this;

			public Action openPrivacyScreen;

			private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

			private Action<SpConsents> _003ConConsentReady_003E5__2;

			private Action _003ConConsentUIReady_003E5__3;

			private Action<Exception> _003ConConsentError_003E5__4;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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
		private struct _003CVoodoo_002DSauce_002DPrivacy_002DIConsentManagementProvider_002DGetConsent_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<CmpConsent> _003C_003Et__builder;

			public PrivacyEnvironment environment;

			public Sourcepoint _003C_003E4__this;

			public Action<bool> onPrivacyShown;

			private TaskAwaiter<CmpConsent> _003C_003Eu__1;

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
		private struct _003CVoodoo_002DSauce_002DPrivacy_002DIConsentManagementProvider_002DOpenPrivacySettings_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<CmpConsent> _003C_003Et__builder;

			public Sourcepoint _003C_003E4__this;

			private TaskAwaiter<CmpConsent> _003C_003Eu__1;

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

		private const string TAG = "Sourcepoint";

		private const string PLAYER_PREF_PROPERTY_ID = "Voodoo.Sauce.Privacy.Sourcepoint.PropertyId";

		private List<CAMPAIGN_TYPE> _allCampaignTypesToLoad;

		private MESSAGE_LANGUAGE _language;

		private Action _onConsentUIReady;

		private Action<SpAction> _onConsentAction;

		private Action<Exception> _onConsentError;

		private Action _onConsentUIFinished;

		private Action<SpConsents> _onConsentReady;

		private Action<bool> _onPrivacyShown;

		private SourcepointBehaviour _sourcepointBehaviour;

		private GdprConsent _gdprConsent;

		private int _accountId;

		private int _propertyId;

		private int _privacyManagerId;

		private string _propertyName;

		private long _messageTimeoutInSeconds;

		private static readonly ICmpSdk _cmp;

		private bool _isInitialized;

		public string GetName()
		{
			return null;
		}

		public string GetConfiguration()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CVoodoo_002DSauce_002DPrivacy_002DIConsentManagementProvider_002DGetConsent_003Ed__21))]
		Task<CmpConsent> IConsentManagementProvider.GetConsent(PrivacyEnvironment environment, Action<bool> onPrivacyShown)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CVoodoo_002DSauce_002DPrivacy_002DIConsentManagementProvider_002DOpenPrivacySettings_003Ed__22))]
		Task<CmpConsent> IConsentManagementProvider.OpenPrivacySettings()
		{
			return null;
		}

		void IConsentManagementProvider.ClearCache()
		{
		}

		private void Initialize(Action<bool> onPrivacyShown, CAMPAIGN_ENV environment)
		{
		}

		[AsyncStateMachine(typeof(_003CAskConsent_003Ed__25))]
		private Task<CmpConsent> AskConsent()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CShowPrivacyScreen_003Ed__26))]
		private Task<CmpConsent> ShowPrivacyScreen(Action openPrivacyScreen)
		{
			return null;
		}

		private PrivacyConsent GetPrivacyConsent(bool consent)
		{
			return null;
		}

		private void SetConfiguration(SourcepointConfiguration configuration)
		{
		}

		private void InstantiateBehaviour()
		{
		}

		private void InitializeCMP(CAMPAIGN_ENV environment)
		{
		}

		private void OnConsentUIReadyDebugLog()
		{
		}

		private void OnConsentActionDebugLog(SpAction action)
		{
		}

		private void OnConsentErrorDebugLog(Exception exception)
		{
		}

		private void OnConsentUIFinishedDebugLog()
		{
		}

		private void OnConsentReadyDebugLog(SpConsents consents)
		{
		}

		private void SavePropertyId(int propertyId)
		{
		}

		private int GetPropertyId()
		{
			return 0;
		}
	}
}
