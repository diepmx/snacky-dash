using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Common.Purchase
{
	internal sealed class PurchaseLoadingController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStart_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public PurchaseLoadingController _003C_003E4__this;

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

		private const int TimeoutMs = 30000;

		private readonly IPopupService _popupService;

		private CancellationTokenSource _cts;

		private bool _hasTimedOut;

		internal PurchaseLoadingController(IPopupService popupService)
		{
		}

		[AsyncStateMachine(typeof(_003CStart_003Ed__5))]
		internal UniTaskVoid Start()
		{
			return default(UniTaskVoid);
		}

		internal bool Cancel()
		{
			return false;
		}
	}
}
