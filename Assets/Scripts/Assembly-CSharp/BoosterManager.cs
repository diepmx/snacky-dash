using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Boosters.Config;
using JuicedUp.Features.Boosters.PreUseAnimation;
using JuicedUp.Features.Boosters.Tutorial;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using UnityEngine;
using VContainer;

public class BoosterManager : MonoBehaviour, IAsyncInitializable, IBoosterCatalog
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CPlayPreUseThenAsync_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public BoosterManager _003C_003E4__this;

		public BoosterId type;

		public Action<BoosterId> onComplete;

		private CancellationToken _003CcancellationToken_003E5__2;

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

	private const int MaxShrinkUsesPerLevel = 3;

	public static BoosterManager instance;

	public static Action<BoosterId, int, bool> OnBoosterCountChanged;

	public static Action OnBoosterStatusRefresh;

	public static Action<BoosterId, bool> OnFirstFreeAvailabilityChanged;

	public static Action<BoosterId> OnTriggerBoosterFocus;

	public static Action<BoosterId> OnCancelBoosterFocus;

	public static Action<BoosterId> OnTriggeringBooster;

	public static Action OnTriggeringRevive;

	public List<BoosterData> boostersData;

	public int priceRevive;

	[Header("Forced Tutorial")]
	[SerializeField]
	[Tooltip("Optional ScriptableObject holding per-booster forced tutorial flow type and thresholds. Null-safe: BoosterForcedTutorialController will no-op when missing.")]
	private BoosterConfigSO _forcedTutorialConfig;

	public BoosterBuyUI boosterBuyUI;

	private SwipeController _swipecontroller;

	[Tooltip("2 mode to buy booster, one, you press and open a window where you can buy boosters only--> indirect mode, the direct mode is you press the booster button, it triggers the focus, then you can use it if you have money,  ")]
	public bool directPriceMode;

	private IGameStateEvents _gameStateEvents;

	private IBoosterStorage _boosterStorage;

	private RemoteConfigService _remoteConfigService;

	private IEconomyService _economyService;

	private ICoreGameAnalyticsService _analyticsService;

	private IBoosterTutorialRepository _tutorialRepository;

	private BoosterTutorialState _tutorialState;

	private IBoosterPreUseAnimationCoordinator _preUseAnimationCoordinator;

	private int _shrinkUsesThisLevel;

	private int[] _revivePrices;

	private int _reviveDefeatCountThisLevel;

	private int _revivePricingTrackedLevel;

	private bool _tunnelTraversalAnimationActive;

	public BoosterConfigSO ForcedTutorialConfig => null;

	public bool IsCancelBlocked => false;

	[Inject]
	public void Construct(SwipeController swipeController, RemoteConfigService remoteConfigService, IEconomyService economyService, IBoosterStorage boosterStorage, ICoreGameAnalyticsService analyticsService, IBoosterTutorialRepository tutorialRepository, BoosterTutorialState tutorialState, IGameStateEvents gameStateEvents, IBoosterPreUseAnimationCoordinator preUseAnimationCoordinator)
	{
	}

	public UniTask InitAsync(CancellationToken cancellationToken)
	{
		return default(UniTask);
	}

	private void ForwardBoosterCount(BoosterId boosterId, int count)
	{
	}

	private void ForwardFirstFreeAvailability(BoosterId boosterId, bool isAvailable)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public int GetBoosterCount(BoosterId boosterId)
	{
		return 0;
	}

	public bool IsBoosterUnlocked(BoosterId type)
	{
		return false;
	}

	public bool HasClaimedUnlockStarterReward(BoosterId id)
	{
		return false;
	}

	public void NotifyUnlockStarterRewardClaimed(BoosterId id)
	{
	}

	public bool IsFirstFreeAvailable(BoosterId id)
	{
		return false;
	}

	public bool IsBoosterUsable(BoosterId id)
	{
		return false;
	}

	public void BuyRevive()
	{
	}

	public void FinalizeRevivePurchase()
	{
	}

	public BoosterData GetBoosterData(BoosterId boosterType)
	{
		return null;
	}

	public bool TryGetBoosterUnlockingAt(int level, out BoosterId boosterId)
	{
		boosterId = default(BoosterId);
		return false;
	}

	public void TriggerBooster_ShuffleRespawn()
	{
	}

	public void TriggerBooster_CannonDelivery(int index)
	{
	}

	public void TriggerBooster_Shrink()
	{
	}

	public void TriggerBooster_Freeze()
	{
	}

	public void TriggerBooster_Tunnel()
	{
	}

	public void TriggerBooster(BoosterId type)
	{
	}

	private bool ShouldGatePreUseAnimation(BoosterId type)
	{
		return false;
	}

	private void FireActivationSignals(BoosterId type)
	{
	}

	private void ConsumeFirstFreeAndGrantInventory(BoosterId type)
	{
	}

	public bool IsForcedTutorialPending(BoosterId type)
	{
		return false;
	}

	public void CancelBoosterFocus(BoosterId type)
	{
	}

	public bool TryToBuy(BoosterId boosterType)
	{
		return false;
	}

	public bool CanClickBooster(BoosterId type)
	{
		return false;
	}

	private void OnTunnelTraversalEnter(bool isBoosterTunnel)
	{
	}

	private void OnTunnelTraversalExit(bool isBoosterTunnel)
	{
	}

	public void RegisterTimesUpDefeatForRevivePricing()
	{
	}

	private void OnGameStateChangedForRevivePricing(GameState state, DefeatType defeatType)
	{
	}

	private void SyncRevivePricingTrackedLevel()
	{
	}

	private void EnsureRevivePricingLevelAligned()
	{
	}

	private void ApplyRevivePriceForCurrentDefeat()
	{
	}

	private void RefreshDisplayedRevivePriceFromProgress()
	{
	}

	private void OnLevelBuilt(LevelDataSO _, LevelMeta __)
	{
	}

	public bool HasBooster(BoosterId type)
	{
		return false;
	}

	private bool HasReachedLevelUsageLimit(BoosterId type)
	{
		return false;
	}

	private void RegisterLevelUsage(BoosterId type)
	{
	}

	private void UseBooster(BoosterId type)
	{
	}

	private void OnBoosterClicked(BoosterId type)
	{
	}

	private bool ShouldGateFocusOpenForPreUseAnimation(BoosterId type)
	{
		return false;
	}

	private void FireFocusSignals(BoosterId type)
	{
	}

	[AsyncStateMachine(typeof(_003CPlayPreUseThenAsync_003Ed__78))]
	private UniTaskVoid PlayPreUseThenAsync(BoosterId type, Action<BoosterId> onComplete)
	{
		return default(UniTaskVoid);
	}

	private void OpenBoosterBuyPanel(BoosterId type)
	{
	}

	private bool CanAffordDirect(BoosterId type)
	{
		return false;
	}

	private void ApplyRemoteConfigOverrides()
	{
	}

	private void ApplyBoosterPrice(BoosterId boosterType, int price)
	{
	}

	private void OnRemoteConfigInitialized()
	{
	}
}
