using System.Collections.Generic;

namespace Voodoo.Live.Shop
{
	public class ShopFactory
	{
		private readonly IInventory _inventory;

		public ShopFactory(IInventory inventory)
		{
		}

		public GameShop CreateGameShop(GameShopDTO gameShopDTO)
		{
			return null;
		}

		public List<ShopSection> CreateShopSections(List<ShopSectionDTO> sectionDTOs)
		{
			return null;
		}

		public ShopSection CreateShopSection(ShopSectionDTO sectionDTO, int sectionIndex)
		{
			return null;
		}

		public List<ShopProduct> CreateShopProducts(List<ProductDTO> productDTOs, string sectionContext = null)
		{
			return null;
		}
	}
}
