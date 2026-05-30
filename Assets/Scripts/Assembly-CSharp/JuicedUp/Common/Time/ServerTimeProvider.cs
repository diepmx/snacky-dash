using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Network;
using JuicedUp.Core.Bootstrap;
using UnityEngine.Networking;

namespace JuicedUp.Common.Time
{
	public class ServerTimeProvider : IServerTimeProvider, IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ServerTimeProvider _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

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
		private struct _003CLoadServerTime_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ServerTimeProvider _003C_003E4__this;

			private UnityWebRequest _003Creq_003E5__2;

			private UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter _003C_003Eu__1;

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

		private const string ParseFormat = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";

		private const string ServerUrl = "https://www.google.com";

		private const string DateHeader = "Date";

		public static bool IsDebugModeActive;

		private readonly INetworkConnectionProvider _networkConnectionProvider;

		private DateTime _lastServerTimeUtc;

		private float _lastSyncRealtime;

		private bool _useDebugOffset;

		private TimeSpan _debugOffset;

		private IDisposable _networkStatusSubscription;

		public ServerTimeProvider(INetworkConnectionProvider networkConnectionProvider)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__11))]
		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		public DateTime UtcTime()
		{
			return default(DateTime);
		}

		public DateTime LocalTime()
		{
			return default(DateTime);
		}

		public void DebugAddDay(int days)
		{
		}

		public void ResetDebugOffset()
		{
		}

		private void OnApplicationFocusChanged(bool hasFocus)
		{
		}

		private void OnNetworkStatusChanged(bool isOnline)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadServerTime_003Ed__19))]
		private UniTask LoadServerTime()
		{
			return default(UniTask);
		}
	}
}
