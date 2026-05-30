using System.Collections.Generic;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Live;

namespace JuicedUp.Features.Shop.Internal.Providers
{
	public interface IShopProductsProvider : IProductsProvider
	{
		IEnumerable<IProduct> BundleSectionProducts { get; }

		IEnumerable<IProduct> CoinsSectionProducts { get; }

		IEnumerable<IProduct> ThirdPartyOffersSectionProducts { get; }

		void Initialize(IEnumerable<ProductDTO> bundleSectionProducts, IEnumerable<ProductDTO> coinsSectionProducts, IEnumerable<ProductDTO> thirdPartyOffersSectionProducts);

		IEnumerable<IProduct> GetAllShopProducts();
	}
}
