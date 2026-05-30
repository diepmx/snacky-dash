using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Features.Core.Scene
{
	public sealed class SceneService : ISceneService, IDisposable
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			public UniTaskCompletionSource hidden;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateGameSceneInternalAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneService _003C_003E4__this;

			public CancellationToken cancellationToken;

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
		private struct _003CHideAndReportAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneService _003C_003E4__this;

			private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

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
		private struct _003CLoadMainAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public SceneService _003C_003E4__this;

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
		private struct _003CLoadSceneAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string sceneName;

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
		private struct _003CReturnToMainInternalAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneService _003C_003E4__this;

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
		private struct _003CRunTransitionAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneService _003C_003E4__this;

			public CancellationToken cancellationToken;

			public Func<CancellationToken, UniTask> transition;

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
		private struct _003CUnloadSceneAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string sceneName;

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

		private const int DefaultAsyncUploadTimeSlice = 2;

		private readonly LifetimeInitSignal _lifetimeInitSignal;

		private readonly LoadingScreenController _loadingScreenController;

		private readonly GameInteractableReporter _reporter;

		private UniTaskCompletionSource _inFlight;

		private CancellationTokenSource _transitionCts;

		public bool IsTransitioning { get; private set; }

		public SceneService(LifetimeInitSignal lifetimeInitSignal, LoadingScreenController loadingScreenController, GameInteractableReporter reporter)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadMainAsync_003Ed__11))]
		public UniTask LoadMainAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public UniTask ActivateGameSceneAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public UniTask ReturnToMainAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CRunTransitionAsync_003Ed__15))]
		private UniTask RunTransitionAsync(Func<CancellationToken, UniTask> transition, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CActivateGameSceneInternalAsync_003Ed__16))]
		private UniTask ActivateGameSceneInternalAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHideAndReportAsync_003Ed__17))]
		private UniTask HideAndReportAsync()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CReturnToMainInternalAsync_003Ed__18))]
		private UniTask ReturnToMainInternalAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadSceneAsync_003Ed__19))]
		private static UniTask LoadSceneAsync(string sceneName, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnloadSceneAsync_003Ed__20))]
		private static UniTask UnloadSceneAsync(string sceneName, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public bool IsSceneActive(string sceneName)
		{
			return false;
		}

		private static bool IsSceneLoaded(string sceneName)
		{
			return false;
		}

		private void SetActiveScene(string sceneName)
		{
		}
	}
}
