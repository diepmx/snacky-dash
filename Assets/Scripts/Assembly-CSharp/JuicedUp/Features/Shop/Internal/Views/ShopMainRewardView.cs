using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	[Serializable]
	internal class ShopMainRewardView
	{
		[SerializeField]
		private Image _rewardIcon;

		[SerializeField]
		private TextMeshProUGUI _rewardAmount;

		public void SetAmount(string amount)
		{
		}

		public void SetRewardSprite(Sprite sprite)
		{
		}
	}
}
