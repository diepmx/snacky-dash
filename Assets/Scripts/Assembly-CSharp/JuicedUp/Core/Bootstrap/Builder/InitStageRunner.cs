using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap.Analytics;
using VContainer;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public sealed class InitStageRunner
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass3_0
		{
			public InitStageRunner _003C_003E4__this;

			public IInitStageDefinition stage;

			public CancellationTokenSource cts;

			internal UniTask _003CRunAsync_003Eb__0(Type item)
			{
				return default(UniTask);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public InitStageRunner _003C_003E4__this;

			public IInitStageDefinition stage;

			public CancellationToken cancellationToken;

			private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

			private Stopwatch _003Cstopwatch_003E5__2;

			private IEnumerable<UniTask> _003CparallelTasks_003E5__3;

			private Type[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

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
		private struct _003CRunItemAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Type item;

			public InitStageRunner _003C_003E4__this;

			public BuildStage stage;

			public bool isParallel;

			public CancellationToken cancellationToken;

			private Stopwatch _003Cstopwatch_003E5__2;

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

		private readonly IObjectResolver _resolver;

		private readonly IBootstrapAnalytics _analytics;

		public InitStageRunner(IObjectResolver resolver, IBootstrapAnalytics analytics)
		{
		}

		[AsyncStateMachine(typeof(_003CRunAsync_003Ed__3))]
		public UniTask RunAsync(IInitStageDefinition stage, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRunItemAsync_003Ed__4))]
		private UniTask RunItemAsync(BuildStage stage, Type item, bool isParallel, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}
