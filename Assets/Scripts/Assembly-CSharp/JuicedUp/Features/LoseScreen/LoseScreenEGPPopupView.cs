using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Economy.Scripts.Public.Filters;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.Purchase;
using JuicedUp.Features.Core.Lives;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Internal.Delegates;
using JuicedUp.Features.Shop.Internal.Providers;
using JuicedUp.Features.Shop.Internal.Views;
using JuicedUp.Features.Shop.Scripts.Public;
using JuicedUp.Features.WeeklyMissions.Public;
using KiraganGames.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseScreenEGPPopupView : BasePopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnBgPanelPressedDownAsync_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public LoseScreenEGPPopupView _003C_003E4__this;

			private CancellationTokenSource _003CholdCancellationTokenSource_003E5__2;

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

		private const string RewardPopupTitleKey = "lose_screen_egp_reward_popup_title";

		private const string FreeReviveLabelKey = "refill_lives_cost_free";

		[SerializeField]
		private CurrencyRewardHudView _coinsCurrencyRewardHudView;

		[SerializeField]
		private CurrencyRewardHudView _livesCurrencyRewardHudView;

		[SerializeField]
		private UnityEngine.UI.Button _playOnReviveButton;

		[SerializeField]
		private UnityEngine.UI.Button _cancelButton;

		[SerializeField]
		private List<TextMeshProUGUI> _revivePriceTexts;

		[Header("Lives Timer")]
		[SerializeField]
		private TMP_Text _timerText;

		[SerializeField]
		private Image _imageInfinite;

		[Header("Hold to Show BG Params")]
		[SerializeField]
		private KiraganGames.Ui.Button _backgroundPanel;

		[SerializeField]
		private Transform _scaleOnHold;

		[Space(6f)]
		[SerializeField]
		private float _scale;

		[SerializeField]
		private float _holdDuration;

		[Space]
		[SerializeField]
		private BundleShopItemView _bundleShopItemViewPrefab;

		private IEconomySpritesProvider _economySpritesProvider;

		private IRewardViewFactory _rewardViewFactory;

		private IRewardPopupViewController _rewardPopupViewController;

		private ProductPurchaseDelegate _productPurchaseDelegate;

		private IShopProductsProvider _shopProductsProvider;

		private IEconomyService _economyService;

		private IProductsFilter _productsFilter;

		private IPopupService _popupService;

		private IWallet _wallet;

		private IRewardHudRegister _rewardHudRegister;

		private LoseFlowAnalyticsContext _analyticsContext;

		private ICampaignAttributionService _campaignAttributionService;

		private IProductPurchaseGlobalNotifier _productPurchaseGlobalNotifier;

		private IMissionExecutor _missionExecutor;

		private bool _isFreeEgp;

		private CancellationTokenSource _holdCancellationTokenSource;

		private PurchaseLoadingController _purchaseLoadingController;

		private IProduct _purchasedProduct;

		protected override void OnSetup(IPopupPayload payload)
		{
		}

		private void WalletOnCurrencyChanged(CurrencyId _, int __)
		{
		}

		private void OnBgPanelPressedUp()
		{
		}

		private void OnBgPanelPressedDown()
		{
		}

		[AsyncStateMachine(typeof(_003COnBgPanelPressedDownAsync_003Ed__36))]
		private UniTaskVoid OnBgPanelPressedDownAsync()
		{
			return default(UniTaskVoid);
		}

		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void HandleLivesServiceReady(LivesService service)
		{
		}

		private void HandleLivesChanged(int current, int max)
		{
		}

		private void RenderTimer(int secondsRemaining)
		{
		}

		private void CancelAndDisposeTokenSource()
		{
		}

		private void OnPlayOnReviveClicked()
		{
		}

		private void OnCancelClicked()
		{
		}

		private void RefreshReviveState()
		{
		}

		private void ApplyFreeEgpOverrides()
		{
		}

		private void HideIapBundle()
		{
		}

		private void ApplyFreeReviveLabel()
		{
		}

		private bool CanAffordRevive()
		{
			return false;
		}

		private void InitializeEgpOffer()
		{
		}

		private void InitializePurchases()
		{
		}

		private void OnPurchaseCompleted(IProduct product)
		{
		}

		private void OnPurchaseFailed(IProduct product, VoodooPurchaseFailureReason reason)
		{
		}

		private void OnSuccessfulPurchasePopupClosed()
		{
		}

		private void OnFailedPurchasePopupClosed()
		{
		}

		private void InitBundleShopItemView(IProduct product)
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
	}
}
