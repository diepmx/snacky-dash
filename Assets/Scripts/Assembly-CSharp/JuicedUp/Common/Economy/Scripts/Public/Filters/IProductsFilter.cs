using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Scripts.Public.Filters
{
	public interface IProductsFilter
	{
		IEnumerable<IProduct> GlobalFilter(IEnumerable<IProduct> products);

		IProduct GlobalFilter(IProduct product);

		IProduct FilterNoAdsRewardsFromBundle(IProduct product);

		IEnumerable<IProduct> FilterEverythingRelatedToNoAds(IEnumerable<IProduct> products);
	}
}
