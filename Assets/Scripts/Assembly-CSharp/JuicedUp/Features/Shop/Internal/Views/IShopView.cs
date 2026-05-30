using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Views;

namespace JuicedUp.Features.Shop.Internal.Views
{
	internal interface IShopView
	{
		CurrencyRewardHudView CurrencyRewardHudPrefab { get; }

		ShopSectionView OffersShopSection { get; }

		ShopSectionView BundlesShopSection { get; }

		ShopSectionView CoinsShopSection { get; }

		BundleShopItemView BundleShopItemPrefab { get; }

		CoinPackShopItemView CoinPackShopItemPrefab { get; }

		ShopItemView NoAdsShopItemPrefab { get; }

		event Action RestoreButtonClicked;

		event Action CloseButtonClicked;

		UniTask Show(bool enableCloseButton, CancellationToken token);

		UniTask Hide(CancellationToken token);

		void ShowOfflinePlaceholder();

		void HideOfflinePlaceholder();
	}
}
