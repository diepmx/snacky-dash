using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Features.Core;
using JuicedUp.Features.Shop.Internal.Views;
using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Controllers
{
	internal class BundleSectionController : IDisposable
	{
		private readonly IEconomySpritesProvider _economySpritesProvider;

		private readonly BundleShopItemView _bundleShopItemViewPrefab;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly ShopSectionView _shopSectionView;

		private readonly ShopItemView _shopItemViewPrefab;

		private readonly IGameStateReader _gameStateReader;

		private readonly List<BundleShopItemView> _bundleInstances;

		private readonly IEnumerable<IProduct> _products;

		private ShopItemView _noAdsShopItemView;

		private Action _commonBuyButtonAction;

		public BundleSectionController(BundleShopItemView bundleShopItemViewPrefab, ShopItemView shopItemViewPrefab, ShopSectionView shopSectionView, IEnumerable<IProduct> products, IEconomySpritesProvider economySpritesProvider, IRewardViewFactory rewardViewFactory, Action commonBuyButtonAction, IGameStateReader gameStateReader)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		private void InitNoAdsShopItemView(Transform parent)
		{
		}

		private void InitAllBundleShopItemViews(Transform parent)
		{
		}

		private void CreateBundleShopItemView(IProduct product, Transform parent)
		{
		}

		private void InitBundlePresentation(BundleShopItemView bundleShopItemView, IProduct product)
		{
		}

		private void InitBundleBottomLayer(BundleBottomLayerView bundleBottomLayerView, IProduct product)
		{
		}

		private void InitBundleTopLayer(BundleTopLayerView bundleTopLayerView, IProduct product)
		{
		}

		private void InitMainReward(ShopMainRewardView mainRewardView, IProduct product)
		{
		}

		private void InitLabel(ProductLabelView labelView, IProduct product)
		{
		}

		private void InitPurchaseButton(ShopItemView shopItemView, IProduct product)
		{
		}

		private void OnBuyButtonClicked(string productId)
		{
		}

		private void ClearAllBundleShopItemViews()
		{
		}

		private void ClearNoAdsShopItemView()
		{
		}
	}
}
