using System.Collections.Generic;

namespace Voodoo.Live.Shop
{
	public class GameShop
	{
		public string sourceId;

		public string sourceName;

		public readonly string id;

		public readonly string name;

		public readonly bool isDefaultStore;

		public List<ShopSection> Sections { get; private set; }

		public List<ShopProduct> ShopProducts { get; private set; }

		public GameShop(GameShopDTO dataTransferObject, List<ShopSection> sections)
		{
		}

		public ShopSection GetSectionByProductId(string productId)
		{
			return null;
		}

		public void SetSource(string sourceId, string sourceName)
		{
		}
	}
}
