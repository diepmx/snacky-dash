using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.UI;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Core.Scene;
using JuicedUp.Features.Shop.Internal.Controllers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace JuicedUp.Features.Core.Home
{
	public class HomePanel : MonoBehaviour, IAsyncInitializable, ISwipeUiTarget, IHomePanel
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadLevelDataAndRefreshMap_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public HomePanel _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask<LevelResolution>.Awaiter _003C_003Eu__1;

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
		private struct _003CPresentPendingCoinsAfterInitAsync_003Ed__43 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public HomePanel _003C_003E4__this;

			public CancellationToken ct;

			private int _003CowedCoins_003E5__2;

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
		private struct _003CShowLifeRefillPopupAsync_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public HomePanel _003C_003E4__this;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		private const string PlayButtonTranslationKey = "play_button_level_number";

		public CanvasGroup canvasGroup;

		[SerializeField]
		private RewardHudView[] _rewardHudViews;

		[SerializeField]
		private GameObject _bottomHUDPanel;

		[SerializeField]
		private SagaMapUI _sagaMap;

		[SerializeField]
		private Transform _levelRewardsSpawnPoint;

		[SerializeField]
		private SerializableDictionary<LevelDifficulty, GameObject> _levelDifficultyButtons;

		[SerializeField]
		private BottomHudPanel _bottomHud;

		[SerializeField]
		private Button _playButton;

		[SerializeField]
		private TextMeshProUGUI[] _playButtonTexts;

		private Loading _loading;

		private RemoteConfigService _remoteConfig;

		private IPopupService _popupService;

		private IEconomyService _economyService;

		private IShopViewController _shopViewController;

		private ILevelRunStats _levelRunStats;

		private IRewardHudRegister _rewardHudRegister;

		private ILevelProvider _levelProvider;

		private ISceneService _sceneService;

		private IRewardPresentationService _rewardPresentationService;

		private IHudValueSyncService _hudValueSyncService;

		private IActiveRewardHudViewProvider _activeRewardHudViewProvider;

		private IWallet _wallet;

		private IGameStateReader _gameStateReader;

		private IRewardHudParticleTickBinder _rewardHudParticleTickBinder;

		private LevelDataSO _levelData;

		private ICoreGameAnalyticsService _analyticsService;

		private Dictionary<LevelDifficulty, GameObject> _difficultyButtonMapping;

		[Inject]
		public void Construct(Loading loading, RemoteConfigService remoteConfig, ICoreGameAnalyticsService analyticsService, IPopupService popupService, IEconomyService economyService, IShopViewController shopViewController, ILevelRunStats levelRunStats, IRewardHudRegister rewardHudRegister, ILevelProvider levelProvider, ISceneService sceneService, IRewardPresentationService rewardPresentationService, IHudValueSyncService hudValueSyncService, IRewardHudParticleTickBinder rewardHudParticleTickBinder, IActiveRewardHudViewProvider activeRewardHudViewProvider, IWallet wallet, IGameStateReader gameStateReader)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void PresentPendingCoins(CancellationToken cancellationToken)
		{
		}

		public void ShowHomeAndOfferRefill()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadLevelDataAndRefreshMap_003Ed__32))]
		private UniTask LoadLevelDataAndRefreshMap(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnLanguageChanged()
		{
		}

		public void OnPlayButtonClicked()
		{
		}

		private UniTask PlayGameAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void ShowHomeUI()
		{
		}

		[AsyncStateMachine(typeof(_003CShowLifeRefillPopupAsync_003Ed__39))]
		private UniTask ShowLifeRefillPopupAsync()
		{
			return default(UniTask);
		}

		private void PlayStartSound()
		{
		}

		private void RefreshSagaMap(int currentLevelIndex)
		{
		}

		private void SetDifficultyText(LevelDifficulty levelDifficulty)
		{
		}

		[AsyncStateMachine(typeof(_003CPresentPendingCoinsAfterInitAsync_003Ed__43))]
		private UniTask PresentPendingCoinsAfterInitAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		private void OnRewardArrived(IReward reward)
		{
		}

		private void OnSingleParticleArrivedWithDelta(IReward reward, int delta)
		{
		}

		private void StageActiveCoinFlyTarget(int amount)
		{
		}

		private void SyncCoinHudsToWallet()
		{
		}

		public void OnSwipe(SwipeDirection direction)
		{
		}

		private void UpdatePlayButtonText()
		{
		}
	}
}
