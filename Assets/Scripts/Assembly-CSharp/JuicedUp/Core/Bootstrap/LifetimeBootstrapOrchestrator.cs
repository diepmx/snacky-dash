using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JetBrains.Annotations;
using JuicedUp.Core.Bootstrap.Analytics;
using JuicedUp.Core.Bootstrap.Builder;
using VContainer;
using VContainer.Unity;

namespace JuicedUp.Core.Bootstrap
{
	[UsedImplicitly]
	public sealed class LifetimeBootstrapOrchestrator : ILifetimeBootstrapOrchestrator
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LifetimeBootstrapOrchestrator _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask.Awaiter _003C_003Eu__1;

			private CancellationTokenSource _003CstageCancellationTokenSource_003E5__2;

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

		private readonly IInitStageDefinition _bootStage;

		private readonly IInitStageDefinition _coreStage;

		private readonly IInitStageDefinition _metaStage;

		private readonly IInitStageDefinition _backgroundStage;

		private readonly InitStageRunner _initStageRunner;

		private readonly LifetimeInitSignal _lifetimeInitSignal;

		private readonly LifetimeScope _lifetimeScope;

		public event Action<BuildStage> OnStageCompleted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public LifetimeBootstrapOrchestrator(IObjectResolver container, LifetimeScope lifetimeScope, LifetimeInitSignal lifetimeInitSignal, IBootstrapAnalytics bootstrapAnalytics)
		{
		}

		[AsyncStateMachine(typeof(_003CRunAsync_003Ed__11))]
		public UniTask RunAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void LogBootstrapFailure(string stageName, Exception e)
		{
		}
	}
}
