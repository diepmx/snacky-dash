using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Internal.Controllers;

namespace JuicedUp.Common.Economy.Internal
{
	internal class RestorePurchaseInitializer : IAsyncInitializable, IDisposable
	{
		private readonly ICampaignAttributionService _campaignAttributionService;

		private readonly IRewardPopupViewController _rewardPopupViewController;

		private readonly IEnumerable<IProductsProvider> _productsProviders;

		private readonly IShopViewController _shopViewController;

		private readonly IEconomyService _economyService;

		private RestoreProductPurchaseDelegate _restoreProductPurchaseDelegate;

		public RestorePurchaseInitializer(ICampaignAttributionService campaignAttributionService, IRewardPopupViewController rewardPopupViewController, IEnumerable<IProductsProvider> productsProviders, IShopViewController shopViewController, IEconomyService economyService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnPurchaseRestored(IProduct product)
		{
		}

		private IEnumerable<IProduct> GetAllProducts()
		{
			return null;
		}
	}
}
