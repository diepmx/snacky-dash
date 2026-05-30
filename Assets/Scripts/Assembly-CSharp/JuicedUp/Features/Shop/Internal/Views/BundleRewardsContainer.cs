using JuicedUp.Features.Shop.Internal.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	internal class BundleRewardsContainer : MonoBehaviour
	{
		[SerializeField]
		private ShopItemGridController _shopItemGridController;

		[SerializeField]
		private TextMeshProUGUI _rewardsAmount;

		[SerializeField]
		private Image _background;

		[field: SerializeField]
		public Transform RewardsContainer { get; private set; }

		public void UpdateGridSettings(int containersCount, int rewardsCount)
		{
		}

		public void SetRewardsAmount(string amount)
		{
		}

		public void SetBottomBackgroundColor(Color color)
		{
		}
	}
}
