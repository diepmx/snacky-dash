using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Views
{
	internal class BundleShopItemView : ShopItemView
	{
		[field: SerializeField]
		public BundleBottomLayerView BottomLayer { get; private set; }

		[field: Space]
		[field: SerializeField]
		public BundleTopLayerView TopLayer { get; private set; }

		[field: Space]
		[field: SerializeField]
		public ShopMainRewardView MainReward { get; private set; }

		[field: Space]
		[field: SerializeField]
		public ProductLabelView Label { get; private set; }
	}
}
