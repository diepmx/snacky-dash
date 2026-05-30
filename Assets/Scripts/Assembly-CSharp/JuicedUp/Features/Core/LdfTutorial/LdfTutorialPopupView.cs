using System.Collections.Generic;
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

namespace JuicedUp.Features.Core.LdfTutorial
{
	public sealed class LdfTutorialPopupView : BasePopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnShowAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LdfTutorialPopupView _003C_003E4__this;

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

		private const float TapToContinueDelaySeconds = 2f;

		[SerializeField]
		private List<TextMeshProUGUI> _titleText;

		[SerializeField]
		private List<TextMeshProUGUI> _subtitleText;

		[SerializeField]
		private List<TextMeshProUGUI> _descriptionText;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Button _tapToDismissButton;

		[SerializeField]
		private GameObject _tapToContinueLabel;

		private LdfTutorialPopupPayload _payload;

		protected override void OnSetup(IPopupPayload payload)
		{
		}

		[AsyncStateMachine(typeof(_003COnShowAsync_003Ed__9))]
		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void OnTapDismiss()
		{
		}
	}
}
