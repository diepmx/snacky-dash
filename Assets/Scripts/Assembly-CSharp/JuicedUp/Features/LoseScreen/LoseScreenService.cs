using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Economy.Scripts.Public.Filters;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Hud;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Core.Scene;
using JuicedUp.Features.LoseTutorial;
using JuicedUp.Features.Segmentation;
using JuicedUp.Features.Shop.Internal.Controllers;
using JuicedUp.Features.Shop.Internal.Providers;
using JuicedUp.Features.Shop.Scripts.Public;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseScreenService : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHandleEgpBuyFlow_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTaskCompletionSource tcs;

			public CancellationToken cancellationToken;

			public LoseScreenService _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHandleShopFlow_003Ed__40 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LoseScreenService _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunLoseFlowAsync_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public LoseScreenService _003C_003E4__this;

			public CancellationToken cancellationToken;

			public DefeatType defeatType;

			private bool _003CisFreeEgp_003E5__2;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CShowScreenFailedPopup_003Ed__41 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public LoseScreenService _003C_003E4__this;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__1;

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

		private const string ScreenLoseFlowInitial = "LoseFlow_Initial";

		private const string ScreenLoseFlowOutOfCoins = "LoseFlow_OutOfCoins";

		private const string ScreenLoseFlowTryAgain = "LoseFlow_TryAgain";

		private readonly IShopProductsProvider _shopProductsProvider;

		private readonly IRewardPopupViewController _rewardPopupViewController;

		private readonly IEconomySpritesProvider _economySpritesProvider;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly IShopViewController _shopViewController;

		private readonly IPopupService _popupService;

		private readonly IDataRepository<PlayerProgressData> _progressRepository;

		private readonly IEconomyService _economyService;

		private readonly IWallet _wallet;

		private readonly IRewardHudRegister _rewardHudRegister;

		private readonly ICoreGameAnalyticsService _analyticsService;

		private readonly IProductsFilter _productsFilter;

		private readonly ILevelRunStats _levelRunStats;

		private readonly RemoteConfigService _remoteConfig;

		private readonly StuckDetectionTracker _stuckDetectionTracker;

		private readonly ICampaignAttributionService _campaignAttributionService;

		private readonly InGameHudView _inGameHudView;

		private readonly ISceneService _sceneService;

		private readonly IGameStateReader _gameStateReader;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly IProductPurchaseGlobalNotifier _productPurchaseGlobalNotifier;

		private readonly LoseTutorialController _loseTutorialController;

		private readonly IMissionExecutor _missionExecutor;

		private bool _flowInProgress;

		private bool _retryLoseFlow;

		private CancellationTokenSource _lifetimeCts;

		private string _flowId;

		private int _stepIndex;

		private HashSet<string> _seenScreens;

		public LoseScreenService(IPopupService popupService, IDataRepository<PlayerProgressData> progressRepository, IEconomyService economyService, IWallet wallet, IShopProductsProvider shopProductsProvider, IRewardPopupViewController rewardPopupViewController, IEconomySpritesProvider economySpritesProvider, IRewardViewFactory rewardViewFactory, IRewardHudRegister rewardHudRegister, ICoreGameAnalyticsService analyticsService, IShopViewController shopViewController, IProductsFilter productsFilter, ILevelRunStats levelRunStats, RemoteConfigService remoteConfig, StuckDetectionTracker stuckDetectionTracker, ICampaignAttributionService campaignAttributionService, InGameHudView inGameHudView, ISceneService sceneService, IGameStateReader gameStateReader, IGameStateEvents gameStateEvents, IProductPurchaseGlobalNotifier productPurchaseGlobalNotifier, LoseTutorialController loseTutorialController, IMissionExecutor missionExecutor)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnGameStateChanged(GameState state, DefeatType defeatType)
		{
		}

		[AsyncStateMachine(typeof(_003CRunLoseFlowAsync_003Ed__36))]
		private UniTaskVoid RunLoseFlowAsync(DefeatType defeatType, CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		private void TrackLoseFlowImpression(string screenName)
		{
		}

		private LoseFlowAnalyticsContext CreateAnalyticsContext(string screenName)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleEgpBuyFlow_003Ed__39))]
		private UniTask HandleEgpBuyFlow(UniTaskCompletionSource tcs, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHandleShopFlow_003Ed__40))]
		private UniTask HandleShopFlow()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CShowScreenFailedPopup_003Ed__41))]
		private UniTask ShowScreenFailedPopup(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void CompleteFailedLevelAndReload(bool shouldGoDirectlyToLevel)
		{
		}
	}
}
