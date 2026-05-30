using JuicedUp.Common.Economy.Public.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class RewardView : MonoBehaviour, IRewardView
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private TextMeshProUGUI _amount;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _showAnimation;

		[SerializeField]
		private AnimationClip _hideAnimation;

		public GameObject GameObject => null;

		public void SetReward(Sprite sprite, string amount)
		{
		}

		public void ActivateShowAnimation()
		{
		}

		public void ActivateHideAnimation()
		{
		}
	}
}
