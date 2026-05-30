using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Views
{
	internal class CoinPackShopItemView : ShopItemView
	{
		[field: SerializeField]
		public ShopMainRewardView MainReward { get; private set; }
	}
}
