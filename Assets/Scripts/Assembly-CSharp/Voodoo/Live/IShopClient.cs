using System;
using Voodoo.Live.Shop;

namespace Voodoo.Live
{
	public interface IShopClient : IReloadableClient, IClient, IDisposable
	{
		ShopProduct GetProductByIapId(string iapId);
	}
}
