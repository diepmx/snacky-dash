using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Economy.Scripts.Public.Filters;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Internal.Providers;
using JuicedUp.Features.Shop.Scripts.Public;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseScreenEGPPopupPayload : IPopupPayload
	{
		public IRewardPopupViewController RewardPopupViewController { get; }

		public IEconomySpritesProvider EconomySpritesProvider { get; }

		public IRewardViewFactory RewardViewFactory { get; }

		public IShopProductsProvider ShopProductsProvider { get; }

		public IEconomyService EconomyService { get; }

		public IProductsFilter ProductsFilter { get; }

		public IPopupService PopupService { get; }

		public IWallet Wallet { get; }

		public IRewardHudRegister RewardHudRegister { get; }

		public LoseFlowAnalyticsContext AnalyticsContext { get; }

		public ICampaignAttributionService CampaignAttributionService { get; }

		public IProductPurchaseGlobalNotifier ProductPurchaseGlobalNotifier { get; }

		public IMissionExecutor MissionExecutor { get; }

		public bool IsFreeEgp { get; }

		public LoseScreenEGPPopupPayload(IEconomyService economyService, IWallet wallet, IShopProductsProvider shopProductsProvider, IPopupService popupService, IRewardPopupViewController rewardPopupViewController, IEconomySpritesProvider economySpritesProvider, IRewardViewFactory rewardViewFactory, IProductsFilter productsFilter, IRewardHudRegister rewardHudRegister, LoseFlowAnalyticsContext analyticsContext, ICampaignAttributionService campaignAttributionService, IProductPurchaseGlobalNotifier productPurchaseGlobalNotifier, IMissionExecutor missionExecutor, bool isFreeEgp = false)
		{
		}
	}
}
