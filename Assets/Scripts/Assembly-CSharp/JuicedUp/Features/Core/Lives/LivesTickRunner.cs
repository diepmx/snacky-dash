using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Time;

namespace JuicedUp.Features.Core.Lives
{
	public sealed class LivesTickRunner : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunLoop_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CancellationToken ct;

			public LivesTickRunner _003C_003E4__this;

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

		private readonly LivesRepository _repository;

		private readonly IServerTimeProvider _serverTimeProvider;

		private LivesState _state;

		private CancellationTokenSource _cts;

		private int _lastSeconds;

		public Func<int> GetDisplayedLifeCount;

		public Action BeforeReconcile;

		public Action<int> AfterReconcile;

		public event Action OnStateChanged
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

		public event Action<int> OnSecondsToNextChanged
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

		public event Action<int, int> RaiseLivesChanged
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

		public LivesTickRunner(LivesRepository repository, IServerTimeProvider serverTimeProvider)
		{
		}

		public void Start(LivesState state)
		{
		}

		public void Stop()
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CRunLoop_003Ed__21))]
		private UniTaskVoid RunLoop(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}

		private void Tick()
		{
		}

		private void ProcessTamper()
		{
		}

		private void OnFocusChanged(bool hasFocus)
		{
		}
	}
}
