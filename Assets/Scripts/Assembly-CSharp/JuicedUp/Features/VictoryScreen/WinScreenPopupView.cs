using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.VictoryScreen
{
	public class WinScreenPopupView : BasePopupView
	{
		public const string RewardedVideoPlacement = "level_complete_reward";

		[Header("Reward")]
		[SerializeField]
		private GameObject _rewardContentRoot;

		[SerializeField]
		private TextMeshProUGUI _rewardText;

		[SerializeField]
		private TextMeshProUGUI _multiplierHintText;

		[SerializeField]
		private GameObject _victoryTextRoot;

		[Header("Actions")]
		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private Button _watchAdButton;

		[SerializeField]
		private GameObject _watchAdButtonRoot;

		[Header("Feature Progress")]
		[SerializeField]
		private GameObject _featureRoot;

		[SerializeField]
		private GameObject[] _featureUnlockTextRoot;

		[SerializeField]
		private Image _featureIcon;

		[SerializeField]
		private TextMeshProUGUI _featureNameText;

		[SerializeField]
		private GameObject _featureSliderRoot;

		[SerializeField]
		private Slider _featureProgressSlider;

		[SerializeField]
		private Image _sliderFeatureIcon;

		private WinScreenPayload _payload;

		private bool _rewardMultiplied;

		private Tween _rewardTextTween;

		private Tween _featureProgressTween;

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

		private void OnContinueClicked()
		{
		}

		private void OnWatchAdClicked()
		{
		}

		private void RefreshRewardLabel()
		{
		}

		private void SetRewardLabel(int rewardCoins)
		{
		}

		private void AnimateRewardLabel(int from, int to)
		{
		}

		private void RefreshWatchAdButton()
		{
		}

		private void SetupFeatureProgress()
		{
		}

		private void AnimateFeatureProgress()
		{
		}
	}
}
