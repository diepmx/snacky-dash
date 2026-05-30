using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Network;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Features.CloudContent
{
	public sealed class CloudContentService : ICloudContentService, IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAttemptInitCycleAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CloudContentService _003C_003E4__this;

			public CancellationToken ct;

			private object _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

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
		private struct _003CInitializeCloudAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CloudContentService _003C_003E4__this;

			public CancellationToken ct;

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
		private struct _003CRunInitAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CloudContentService _003C_003E4__this;

			public CancellationToken ct;

			private string _003CmanifestPath_003E5__2;

			private UniTask<string>.Awaiter _003C_003Eu__1;

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
		private struct _003CRunRecoveryLoopAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CloudContentService _003C_003E4__this;

			public CancellationToken ct;

			private int _003Cdelay_003E5__2;

			private int _003Cattempt_003E5__3;

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
		private struct _003CWaitForReadyAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CloudContentService _003C_003E4__this;

			public CancellationToken ct;

			public TimeSpan timeout;

			private CancellationTokenSource _003Ccts_003E5__2;

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

		private const int MaxRecoveryAttempts = 5;

		private const int RecoveryInitialDelayMs = 1000;

		private const int RecoveryMaxDelayMs = 32000;

		private readonly INetworkConnectionProvider _networkProvider;

		private readonly RemoteConfigService _remoteConfigService;

		private readonly CloudContentLevelDownloader _levelDownloader;

		private readonly UniTaskCompletionSource _terminalState;

		private CancellationTokenSource _lifetimeCts;

		private IDisposable _onlineSubscription;

		private CloudContentState _state;

		private CloudFunnelData _funnelData;

		private bool _isRecovering;

		public CloudContentState State => default(CloudContentState);

		public CloudFunnelData FunnelData => default(CloudFunnelData);

		public CloudContentService(INetworkConnectionProvider networkProvider, RemoteConfigService remoteConfigService, CloudContentLevelDownloader levelDownloader)
		{
		}

		[AsyncStateMachine(typeof(_003CWaitForReadyAsync_003Ed__17))]
		public UniTask WaitForReadyAsync(TimeSpan timeout, CancellationToken ct)
		{
			return default(UniTask);
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CInitializeCloudAsync_003Ed__20))]
		private UniTaskVoid InitializeCloudAsync(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CAttemptInitCycleAsync_003Ed__21))]
		private UniTask AttemptInitCycleAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRunInitAsync_003Ed__22))]
		private UniTask RunInitAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRunRecoveryLoopAsync_003Ed__23))]
		private UniTask RunRecoveryLoopAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		private void TryBeginRecovery()
		{
		}
	}
}
