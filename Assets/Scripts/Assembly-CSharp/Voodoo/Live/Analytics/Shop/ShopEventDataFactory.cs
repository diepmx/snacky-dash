using Voodoo.Live.Shop;

namespace Voodoo.Live.Analytics.Shop
{
	public class ShopEventDataFactory : IShopEventDataFactory
	{
		public ShopEventData CreateFromShop(GameShop shop)
		{
			return null;
		}

		public ProductShopEventData CreateFromProduct(Product product)
		{
			return null;
		}

		public ShopSourceEventData CreateFromSource(ShopSource source)
		{
			return null;
		}
	}
}
