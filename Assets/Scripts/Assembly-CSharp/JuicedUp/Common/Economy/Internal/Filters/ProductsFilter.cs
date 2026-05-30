using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Filters;
using JuicedUp.Features.Shop.Internal.Repositories;

namespace JuicedUp.Common.Economy.Internal.Filters
{
	internal class ProductsFilter : IProductsFilter
	{
		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IShopRepository _shopRepository;

		public ProductsFilter(IEntitlementStorage entitlementStorage, IShopRepository shopRepository)
		{
		}

		public IEnumerable<IProduct> GlobalFilter(IEnumerable<IProduct> products)
		{
			return null;
		}

		public IProduct GlobalFilter(IProduct product)
		{
			return null;
		}

		public IProduct FilterNoAdsRewardsFromBundle(IProduct product)
		{
			return null;
		}

		public IEnumerable<IProduct> FilterEverythingRelatedToNoAds(IEnumerable<IProduct> products)
		{
			return null;
		}

		private static IProduct StripNoAdsEntitlementRewards(IProduct product)
		{
			return null;
		}

		private IEnumerable<IProduct> RemoveProductByProductId(IEnumerable<IProduct> products, string productId)
		{
			return null;
		}
	}
}
