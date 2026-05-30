using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace JuicedUp.Common.Time
{
	public class TimerHandler
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivate_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public TimerHandler _003C_003E4__this;

			public float remainingTimeInSeconds;

			public CancellationToken token;

			private DateTime _003Cdeadline_003E5__2;

			private TimeSpan _003Cremaining_003E5__3;

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

		private readonly IServerTimeProvider _serverTimeProvider;

		private CancellationTokenSource _linkedTokenSource;

		private bool _isStoped;

		public event Action TimerEnded
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

		public event Action<TimeSpan> Ticked
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

		public TimerHandler(IServerTimeProvider serverTimeProvider)
		{
		}

		[AsyncStateMachine(typeof(_003CActivate_003Ed__10))]
		public UniTask Activate(float remainingTimeInSeconds, CancellationToken token)
		{
			return default(UniTask);
		}

		public void Stop()
		{
		}

		public void Continue()
		{
		}

		public void Deactivate()
		{
		}
	}
}
