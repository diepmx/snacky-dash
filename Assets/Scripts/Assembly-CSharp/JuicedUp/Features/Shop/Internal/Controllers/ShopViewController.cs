using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Economy.Scripts.Public.Filters;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.Ftue;
using JuicedUp.Common.Network;
using JuicedUp.Common.Purchase;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Internal.Delegates;
using JuicedUp.Features.Shop.Internal.Notifiers;
using JuicedUp.Features.Shop.Internal.Providers;
using JuicedUp.Features.Shop.Internal.Repositories;
using JuicedUp.Features.Shop.Internal.Views;
using JuicedUp.Features.Shop.Scripts.Public;

namespace JuicedUp.Features.Shop.Internal.Controllers
{
	internal class ShopViewController : IShopViewController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateAsync_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ShopViewController _003C_003E4__this;

			public Action<IProduct> onClose;

			public Action onPurchaseClaimed;

			public bool enableCloseButton;

			public ShopSource source;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitConnectivityAndIAP_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public ShopViewController _003C_003E4__this;

			public CancellationToken token;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const int ConnectivityTimeoutMs = 10000;

		private readonly IProductPurchaseGlobalNotifier _productPurchaseGlobalNotifier;

		private readonly IShopViewControllerNotifier _shopViewControllerNotifier;

		private readonly IRewardPopupViewController _rewardPopupViewController;

		private readonly INetworkConnectionProvider _networkConnectionProvider;

		private readonly IEconomySpritesProvider _economySpritesProvider;

		private readonly ICampaignAttributionService _campaignAttributionService;

		private readonly IShopProductsProvider _shopProductsProvider;

		private readonly IShopAnalyticsService _shopAnalyticsService;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly IRewardHudRegister _rewardHudRegister;

		private readonly IFtueRepository _ftueRepository;

		private readonly IEconomyService _economyService;

		private readonly IProductsFilter _productsFilter;

		private readonly IShopRepository _shopRepository;

		private readonly IPopupService _popupService;

		private readonly IShopView _shopView;

		private readonly IGameStateReader _gameStateReader;

		private CoinSectionController _coinSectionController;

		private BundleSectionController _bundleSectionController;

		private ProductPurchaseDelegate _productPurchaseDelegate;

		private CancellationTokenSource _activationCts;

		private readonly PurchaseLoadingController _purchaseLoadingController;

		private bool _isActive;

		private bool _isFullyInitialized;

		private IProduct _purchasedProduct;

		private Action<IProduct> _onCloseAction;

		private Action _onPurchaseClaimed;

		public ShopViewController(IProductPurchaseGlobalNotifier productPurchaseGlobalNotifier, IShopViewControllerNotifier shopViewControllerNotifier, IRewardPopupViewController rewardPopupViewController, INetworkConnectionProvider networkConnectionProvider, IEconomySpritesProvider economySpritesProvider, IShopProductsProvider shopProductsProvider, ICampaignAttributionService campaignAttributionService, IShopAnalyticsService shopAnalyticsService, IRewardHudRegister rewardHudRegister, IRewardViewFactory rewardViewFactory, IFtueRepository ftueRepository, IEconomyService economyService, IProductsFilter productsFilter, IShopRepository shopRepository, IPopupService popupService, IShopView shopView, IGameStateReader gameStateReader)
		{
		}

		public void Activate(ShopSource source, bool enableCloseButton = false, Action<IProduct> onClose = null, Action onPurchaseClaimed = null)
		{
		}

		[AsyncStateMachine(typeof(_003CActivateAsync_003Ed__30))]
		private UniTaskVoid ActivateAsync(ShopSource source, bool enableCloseButton, Action<IProduct> onClose, Action onPurchaseClaimed)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CAwaitConnectivityAndIAP_003Ed__31))]
		private UniTask<bool> AwaitConnectivityAndIAP(CancellationToken token)
		{
			return default(UniTask<bool>);
		}

		private void ShowNoConnectionPopup()
		{
		}

		private void OnNoConnectionPopupClosed()
		{
		}

		public void Deactivate()
		{
		}

		private void InitializePurchases()
		{
		}

		private void InitializeAllBundleViews()
		{
		}

		private void InitializeAllCoinPackViews()
		{
		}

		private void OnRestoreButtonClicked()
		{
		}

		private void OnCloseButtonClicked()
		{
		}

		private void CommonBuyButtonClickAction()
		{
		}

		private void OnPurchaseCompleted(IProduct product)
		{
		}

		private void OnPurchaseFailed(IProduct product, VoodooPurchaseFailureReason reason)
		{
		}

		private void OnRewardPopupClosed()
		{
		}

		private void OnFailedPurchasePopupClosed()
		{
		}

		private void OnSuccessfulPurchasePopupClosed()
		{
		}

		private void OnRestorePurchaseFinished(RestorePurchasesResult result)
		{
		}
	}
}
