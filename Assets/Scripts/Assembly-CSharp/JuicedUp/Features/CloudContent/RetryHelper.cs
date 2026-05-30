using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace JuicedUp.Features.CloudContent
{
	public static class RetryHelper
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecuteWithRetryAsync_003Ed__0<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public int initialDelayMs;

			public Func<CancellationToken, UniTask<T>> operation;

			public CancellationToken ct;

			public int maxAttempts;

			public int maxDelayMs;

			private int _003Cdelay_003E5__2;

			private Exception _003ClastException_003E5__3;

			private int _003Cattempt_003E5__4;

			private UniTask<T>.Awaiter _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CExecuteWithRetryAsync_003Ed__0<>))]
		public static UniTask<T> ExecuteWithRetryAsync<T>(Func<CancellationToken, UniTask<T>> operation, int maxAttempts, CancellationToken ct, int initialDelayMs = 1000, int maxDelayMs = 32000)
		{
			return default(UniTask<T>);
		}
	}
}
