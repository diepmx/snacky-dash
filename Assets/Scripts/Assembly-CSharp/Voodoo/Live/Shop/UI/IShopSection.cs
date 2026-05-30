using System;
using UnityEngine;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Shop.UI
{
	public interface IShopSection
	{
		void Init(ShopSection shopSection, Action showLoadingScreen, GameShop gameShop, RectTransform scrollViewRect, SpriteDictionarySO spriteDictionarySo);
	}
}
