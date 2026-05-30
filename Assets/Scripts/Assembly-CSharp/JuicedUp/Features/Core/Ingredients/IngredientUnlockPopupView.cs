using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockPopupView : BasePopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayDelayedSoundAsync_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

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
		private Image _iconImage;

		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private Button _okButton;

		private IngredientUnlockPopupPayload _payload;

		protected override void OnSetup(IPopupPayload payload)
		{
		}

		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void OnOkClicked()
		{
		}

		[AsyncStateMachine(typeof(_003CPlayDelayedSoundAsync_003Ed__8))]
		private static UniTaskVoid PlayDelayedSoundAsync(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}
	}
}
