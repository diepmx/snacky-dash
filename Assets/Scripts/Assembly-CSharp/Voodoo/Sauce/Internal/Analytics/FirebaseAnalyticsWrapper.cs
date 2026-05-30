using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Voodoo.Sauce.Privacy;

namespace Voodoo.Sauce.Internal.Analytics
{
	public static class FirebaseAnalyticsWrapper
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTrackFirebaseInstallAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private const string TAG = "FirebaseAnalyticsWrapper";

		private const string FIREBASE_INSTALL_EVENT_SENT_KEY = "FIREBASE_INSTALL_EVENT_SENT";

		private const string FIREBASE_INSTALL_EVENT_NAME = "firebase_install";

		private static bool _isFirebaseInitialized;

		private static bool _isEnabled;

		private static readonly Queue<FirebaseAnalyticsEvent> EventsQueue;

		internal static void SubscribeToFirebaseInitialization(PrivacyCore.GdprConsent consent, Action<bool> callback)
		{
		}

		internal static void TrackEvent(string eventName, Dictionary<string, object> properties = null)
		{
		}

		internal static void TrackPurchase(IIAPCommonInfo purchaseInfo)
		{
		}

		private static void SetAnalyticsCollection(bool consent)
		{
		}

		[AsyncStateMachine(typeof(_003CTrackFirebaseInstallAsync_003Ed__10))]
		private static Task TrackFirebaseInstallAsync()
		{
			return null;
		}
	}
}
