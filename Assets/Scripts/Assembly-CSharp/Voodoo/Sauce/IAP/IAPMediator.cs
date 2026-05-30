using System;
using System.Collections.Generic;
using Voodoo.Sauce.Core;
using Voodoo.Sauce.Internal.IntegrationCheck;

namespace Voodoo.Sauce.IAP
{
	public class IAPMediator
	{
		private VoodooSettings _settings;

		private IAPDataBridge _iapDataBridge;

		private IAPAnalyticsTracker _analyticsTracker;

		private IAPCrashReporter _crashReporter;

		public void Initialize(Action onSubscriptionRefreshCallback = null)
		{
		}

		public List<IntegrationCheckMessage> IntegrationCheck()
		{
			return null;
		}

		public IAPStatus GetStatus()
		{
			return null;
		}

		public bool IsSubscribed(string productId)
		{
			return false;
		}

		public bool HasOngoingSubscriptions()
		{
			return false;
		}

		public void RefreshSubscriptionInfo()
		{
		}

		public void SubscribeToOnIAPStatusUpdate(Action<IAPStatus> callback)
		{
		}

		public void UnsubscribeToOnIAPStatusUpdate(Action<IAPStatus> onIAPStatusUpdate)
		{
		}

		public void AddPurchaseDelegate(IPurchaseDelegateWithInfo purchaseDelegate)
		{
		}

		public void RemovePurchaseDelegate(IPurchaseDelegateWithInfo purchaseDelegate)
		{
		}

		public void BuyIAPProduct(string productId, IPurchaseDelegateWithInfo caller = null, IPurchaseValidator customPurchaseValidator = null, Dictionary<string, object> contextProperties = null)
		{
		}

		public void BuyIAPProduct(Bundle bundle, IPurchaseDelegateWithInfo caller = null, IPurchaseValidator customPurchaseValidator = null)
		{
		}

		public void RestorePurchases(Action<RestorePurchasesResult> callback)
		{
		}

		public SubscriptionInfoContainer GetSubscriptionDetails(string productId)
		{
			return null;
		}

		public ProductReceivedInfo GetProductWithId(string productId)
		{
			return null;
		}

		public string GetLocalizedProductPrice(string productId)
		{
			return null;
		}

		public LocalizedPriceInfo GetLocalizedProductPriceInfo(string productId)
		{
			return null;
		}

		public List<ProductReceivedInfo> GetProducts()
		{
			return null;
		}

		public void TrackIAPRevenues(ProductReceivedInfo product, bool isRestoredPurchase)
		{
		}

		public void TrackNoAdsClick()
		{
		}

		public void SendPendingPurchases(IPurchaseDelegateWithInfo caller)
		{
		}
	}
}
