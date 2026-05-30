using JuicedUp.Common.Economy.Public.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.Economy.Internal.Views
{
	public abstract class RewardHudView : MonoBehaviour, IRewardHudView
	{
		[SerializeField]
		private TextMeshProUGUI _rewardAmount;

		[SerializeField]
		private Image _rewardIcon;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _impactAnimation;

		[field: SerializeField]
		public Transform RewardFlyTarget { get; private set; }

		public abstract void Show();

		public abstract void Hide();

		public void SetRewardAmount(string amount)
		{
		}

		public void SetRewardIcon(Sprite icon)
		{
		}

		public void ActivateImpactAnimation()
		{
		}
	}
}
