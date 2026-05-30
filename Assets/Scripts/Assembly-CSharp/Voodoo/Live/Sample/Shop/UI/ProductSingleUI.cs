using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Shop;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample.Shop.UI
{
	public class ProductSingleUI : ProductUI
	{
		[SerializeField]
		private TextMeshProUGUI rewardNameTxt;

		[SerializeField]
		private TextMeshProUGUI rewardAmountTxt;

		[SerializeField]
		private Image rewardImg;

		public override void Init(ShopProduct product, GameShop gameShop, Action showLoadingScreen, RectTransform scrollViewRect, SpriteDictionarySO spriteDictionarySo)
		{
		}
	}
}
