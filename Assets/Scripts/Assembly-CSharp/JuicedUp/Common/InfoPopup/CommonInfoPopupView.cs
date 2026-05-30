using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.InfoPopup.Data;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.InfoPopup
{
	public class CommonInfoPopupView : BasePopupView
	{
		[Space]
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _messageText;

		[SerializeField]
		private TextMeshProUGUI _greenButtonText;

		[Space]
		[SerializeField]
		private Button _greenButton;

		[SerializeField]
		private Button _closeButton;

		private CommonInfoPopupPayload _payload;

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

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void SetupTitle(string title)
		{
		}

		private void SetupMessage(string message)
		{
		}

		private void SetupGreenButtonText(string text)
		{
		}

		private void OnGreenButtonClicked()
		{
		}

		private void OnCloseButtonClicked()
		{
		}
	}
}
