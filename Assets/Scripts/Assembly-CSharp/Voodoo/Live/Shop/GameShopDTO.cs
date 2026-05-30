using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Shop
{
	[Serializable]
	public class GameShopDTO
	{
		public string id;

		public string name;

		public bool isDefaultStore;

		public List<ShopSectionDTO> sections;

		public ItemDTO[] items;

		public NonConsumableProductToItems nonConsumableProductToItems;
	}
}
