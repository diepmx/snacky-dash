using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Features.Shop.Internal.Views;
using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Controllers
{
	internal class CoinSectionController : IDisposable
	{
		private readonly CoinPackShopItemView _coinPackShopItemViewPrefab;

		private readonly IEconomySpritesProvider _economySpritesProvider;

		private readonly ShopSectionView _shopSectionView;

		private readonly List<CoinPackShopItemView> _instances;

		private readonly IEnumerable<IProduct> _products;

		private Action _commonBuyButtonAction;

		public CoinSectionController(CoinPackShopItemView coinPackShopItemViewPrefab, ShopSectionView shopSectionView, IEnumerable<IProduct> products, IEconomySpritesProvider economySpritesProvider, Action commonBuyButtonAction)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		private void InitAllCoinShopItemViews()
		{
		}

		private void CreateCoinShopItemView(IProduct product, Transform parent)
		{
		}

		private void InitMainReward(ShopMainRewardView mainRewardView, IProduct product)
		{
		}

		private void InitPurchaseButton(ShopItemView shopItemView, IProduct product)
		{
		}

		private void OnBuyButtonClicked(string productId)
		{
		}
	}
}
