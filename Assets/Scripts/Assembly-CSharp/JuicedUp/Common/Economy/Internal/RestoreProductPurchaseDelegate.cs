using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Features.Segmentation;
using Voodoo.Sauce.IAP;

namespace JuicedUp.Common.Economy.Internal
{
	internal class RestoreProductPurchaseDelegate : IPurchaseDelegateWithInfo, IPurchaseDelegateBase
	{
		private readonly ICampaignAttributionService _campaignAttributionService;

		private readonly IEconomyService _economyService;

		private readonly IEnumerable<IProduct> _products;

		private readonly Action<IProduct> _purchaseRestored;

		public RestoreProductPurchaseDelegate(ICampaignAttributionService campaignAttributionService, IEconomyService economyService, IEnumerable<IProduct> products, Action<IProduct> purchaseRestored)
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
