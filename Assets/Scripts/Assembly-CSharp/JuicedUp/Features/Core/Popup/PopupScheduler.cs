using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace JuicedUp.Features.Core.Popup
{
	public class PopupScheduler : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CScheduleDelayed_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public PopupScheduler _003C_003E4__this;

			public ScheduledPopupEntry entry;

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

		private readonly IPopupService _popupService;

		private readonly List<ScheduledPopupEntry> _entries;

		private CancellationTokenSource _delayCts;

		public PopupScheduler(IPopupService popupService)
		{
		}

		public void Register(ScheduledPopupEntry entry)
		{
		}

		public void Unregister(PopupId id)
		{
		}

		public void Evaluate(PopupContext ctx)
		{
		}

		public void EvaluateBest(PopupContext ctx)
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CScheduleDelayed_003Ed__9))]
		private UniTaskVoid ScheduleDelayed(ScheduledPopupEntry entry)
		{
			return default(UniTaskVoid);
		}
	}
}
