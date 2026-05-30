using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using UniRx;
using UnityEngine.Networking;

namespace JuicedUp.Common.Network
{
	public class NetworkConnectionProvider : INetworkConnectionProvider, IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCheckInternetConnection_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public CancellationToken token;

			private UnityWebRequest _003Crequest_003E5__2;

			private UniTask<UnityWebRequest>.Awaiter _003C_003Eu__1;

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
		private struct _003CPollLoop_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public NetworkConnectionProvider _003C_003E4__this;

			public CancellationToken token;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		private const string ServerUrl = "https://clients3.google.com/generate_204";

		private const float DelayTimeInSeconds = 3f;

		private const int RequestTimeoutMs = 5000;

		private const int MaxFailedChecks = 2;

		private const int ExpectedResponseCode = 204;

		private CancellationTokenSource _cancellationTokenSource;

		private int _failedChecks;

		public ReactiveProperty<bool> IsOnline { get; }

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CPollLoop_003Ed__12))]
		private UniTaskVoid PollLoop(CancellationToken token)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CCheckInternetConnection_003Ed__13))]
		private UniTask<bool> CheckInternetConnection(CancellationToken token)
		{
			return default(UniTask<bool>);
		}
	}
}
