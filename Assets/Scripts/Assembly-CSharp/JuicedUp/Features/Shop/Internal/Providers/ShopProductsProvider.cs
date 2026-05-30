using System.Collections.Generic;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Converters;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Live;

namespace JuicedUp.Features.Shop.Internal.Providers
{
	internal class ShopProductsProvider : IShopProductsProvider, IProductsProvider
	{
		private readonly IEconomyConverter _economyConverter;

		private IEnumerable<IProduct> _bundleSectionProducts;

		private IEnumerable<IProduct> _coinsSectionProducts;

		private IEnumerable<IProduct> _thirdPartyOffersSectionProducts;

		public IEnumerable<IProduct> BundleSectionProducts => null;

		public IEnumerable<IProduct> CoinsSectionProducts => null;

		public IEnumerable<IProduct> ThirdPartyOffersSectionProducts => null;

		public ShopProductsProvider(IEconomyConverter economyConverter)
		{
		}

		public void Initialize(IEnumerable<ProductDTO> bundleSectionProducts, IEnumerable<ProductDTO> coinsSectionProducts, IEnumerable<ProductDTO> thirdPartyOffersSectionProducts)
		{
		}

		public IEnumerable<IProduct> GetAllShopProducts()
		{
			return null;
		}

		public IEnumerable<IProduct> GetAll()
		{
			return null;
		}
	}
}
