using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Scripts.Public;
using Voodoo.Sauce.IAP;

namespace JuicedUp.Features.Shop.Internal.Delegates
{
	internal class ProductPurchaseDelegate : IPurchaseDelegateWithInfo, IPurchaseDelegateBase
	{
		private readonly ICampaignAttributionService _campaignAttributionService;

		private readonly IProductPurchaseGlobalNotifier _productPurchaseGlobalNotifier;

		private readonly IEconomyService _economyService;

		private readonly EconomySource _economySource;

		private readonly IEnumerable<IProduct> _products;

		private readonly Action<IProduct> _purchaseCompleted;

		private readonly Action<IProduct, VoodooPurchaseFailureReason> _purchaseFailed;

		public ProductPurchaseDelegate(IEconomyService economyService, ICampaignAttributionService campaignAttributionService, IProductPurchaseGlobalNotifier productPurchaseGlobalNotifier, EconomySource source, IEnumerable<IProduct> products, Action<IProduct> purchaseCompleted, Action<IProduct, VoodooPurchaseFailureReason> purchaseFailed)
		{
		}

		public void OnInitializeSuccess()
		{
		}

		public void OnInitializeFailure(VoodooInitializationFailureReason reason)
		{
		}

		public bool OnPurchaseComplete(ProductReceivedInfo productReceivedInfo, PurchaseValidation purchaseValidation)
		{
			return false;
		}

		public void OnPurchaseFailure(VoodooPurchaseFailureReason reason, ProductReceivedInfo productReceivedInfo, string description)
		{
		}
	}
}
