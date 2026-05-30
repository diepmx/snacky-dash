using Voodoo.Live.Shop;

namespace Voodoo.Live.Analytics.Shop
{
	public interface IShopEventDataFactory
	{
		ShopEventData CreateFromShop(GameShop shop);

		ProductShopEventData CreateFromProduct(Product product);

		ShopSourceEventData CreateFromSource(ShopSource source);
	}
}
