using System;
using Voodoo.Live;
using Voodoo.Live.Offers;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal class BattlePassPurchaseService : IBattlePassPurchaseService, IDisposable
	{
		private readonly IBattlePassManager _manager;

		private readonly IBattlePassSeasonService _seasonService;

		private readonly IBattlePassAppBridge _battlePassAppBridge;

		private readonly IBattlePassAnalytics _analytics;

		private string _purchasePlacement;

		private string _expectedProductId;

		public bool CanPurchasePremium => false;

		public BattlePassPurchaseService(IBattlePassManager battlePassManager, IBattlePassSeasonService seasonService, IBattlePassAppBridge battlePassAppBridge, IBattlePassAnalytics analytics)
		{
		}

		public void Dispose()
		{
		}

		public string GetPremiumPrice()
		{
			return null;
		}

		public IFeature PurchasePremium(string placement, Action<bool> onComplete = null)
		{
			return null;
		}

		private void OnPremiumPurchaseSuccess()
		{
		}

		private void OnIAPRewarded(IIAPRewardedInfo iapInfo)
		{
		}

		private void ActivatePremium()
		{
		}

		private void ProcessSeasonPassReward(ItemQuantity reward)
		{
		}
	}
}
