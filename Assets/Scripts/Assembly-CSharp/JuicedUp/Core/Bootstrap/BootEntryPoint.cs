using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Scene;
using VContainer.Unity;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class BootEntryPoint : IAsyncStartable
	{
		private enum VoodooSauceWaitResult
		{
			Ready = 0,
			Timeout = 1
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass9_0
		{
			public UniTaskCompletionSource voodooSauceReadyCompletion;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunBootSceneFlowAsync_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BootEntryPoint _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask<VoodooSauceWaitResult> _003CvoodooSauceWaitTask_003E5__2;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<VoodooSauceWaitResult>.Awaiter _003C_003Eu__2;

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
		private struct _003CStartAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BootEntryPoint _003C_003E4__this;

			public CancellationToken cancellationToken;

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
		private struct _003CWaitForVoodooSauceOrTimeoutAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<VoodooSauceWaitResult> _003C_003Et__builder;

			public CancellationToken cancellationToken;

			private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

			private UniTask<int>.Awaiter _003C_003Eu__1;

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

		private const float VoodooSauceTimeoutSeconds = 5f;

		private readonly ILifetimeBootstrapOrchestrator _orchestrator;

		private readonly LoadingScreenController _loadingScreenController;

		private readonly LifetimeInitSignal _lifetimeInitSignal;

		private readonly ISceneService _sceneService;

		private readonly GameInteractableReporter _reporter;

		public BootEntryPoint(ILifetimeBootstrapOrchestrator orchestrator, LoadingScreenController loadingScreenController, LifetimeInitSignal lifetimeInitSignal, ISceneService sceneService, GameInteractableReporter reporter)
		{
		}

		[AsyncStateMachine(typeof(_003CStartAsync_003Ed__7))]
		public UniTask StartAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRunBootSceneFlowAsync_003Ed__8))]
		private UniTask RunBootSceneFlowAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CWaitForVoodooSauceOrTimeoutAsync_003Ed__9))]
		private UniTask<VoodooSauceWaitResult> WaitForVoodooSauceOrTimeoutAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<VoodooSauceWaitResult>);
		}
	}
}
