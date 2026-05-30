using System;
using UnityEngine;
using Voodoo.Live.Shop;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample.Shop.UI
{
	public class ProductBundleUI : ProductUI
	{
		[SerializeField]
		private Transform rewardsContainer;

		[SerializeField]
		private ProductRewardUI _productRewardUIPrefab;

		public override void Init(ShopProduct product, GameShop gameShop, Action showLoadingScreen, RectTransform scrollViewRect, SpriteDictionarySO spriteDictionarySo)
		{
		}
	}
}
