using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class NoAdsPopupView : BasePopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnShowAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public NoAdsPopupView _003C_003E4__this;

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

		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _noAdsExplosionClip;

		[AsyncStateMachine(typeof(_003COnShowAsync_003Ed__2))]
		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}
	}
}
