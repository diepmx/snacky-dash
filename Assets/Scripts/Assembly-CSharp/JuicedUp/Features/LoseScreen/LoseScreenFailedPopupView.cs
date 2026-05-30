using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseScreenFailedPopupView : BasePopupView
	{
		[SerializeField]
		private Button _tryAgainButton;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private Image _heartBrokenImage;

		[SerializeField]
		private Image _heartInfinityImage;

		[SerializeField]
		private TMP_Text _timerText;

		[SerializeField]
		private Color _labelColor;

		[SerializeField]
		private Color _timerValueColor;

		private LoseFlowAnalyticsContext _analyticsContext;

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

		private void OnTryAgainClicked()
		{
		}

		private void OnCancelClicked()
		{
		}
	}
}
