using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.UI;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	internal class ShopView : MonoBehaviour, IShopView, ISwipeUiTarget
	{
		[Space]
		[SerializeField]
		private Button _restoreButton;

		[Space]
		[SerializeField]
		private Button _closeButton;

		[Header("Offline")]
		[SerializeField]
		private GameObject _offlinePlaceholder;

		[SerializeField]
		private GameObject _shopContent;

		[SerializeField]
		private BottomHudPanel _bottomHud;

		[field: SerializeField]
		public CurrencyRewardHudView CurrencyRewardHudPrefab { get; private set; }

		[field: Header("Sections")]
		[field: SerializeField]
		public ShopSectionView OffersShopSection { get; private set; }

		[field: SerializeField]
		public ShopSectionView BundlesShopSection { get; private set; }

		[field: SerializeField]
		public ShopSectionView CoinsShopSection { get; private set; }

		[field: Header("Prefabs references")]
		[field: SerializeField]
		public BundleShopItemView BundleShopItemPrefab { get; private set; }

		[field: SerializeField]
		public CoinPackShopItemView CoinPackShopItemPrefab { get; private set; }

		[field: SerializeField]
		public ShopItemView NoAdsShopItemPrefab { get; private set; }

		public event Action RestoreButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CloseButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public UniTask Show(bool enableCloseButton, CancellationToken token)
		{
			return default(UniTask);
		}

		public void ShowOfflinePlaceholder()
		{
		}

		public void HideOfflinePlaceholder()
		{
		}

		public UniTask Hide(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnRestoreButtonClicked()
		{
		}

		private void OnCloseButtonClicked()
		{
		}

		public void OnSwipe(SwipeDirection direction)
		{
		}

		private void SetupRestoreButton()
		{
		}
	}
}
