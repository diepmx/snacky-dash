using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap;
using JuicesUp.Features.SeasonPass.Internal.Data;
using JuicesUp.Features.SeasonPass.Internal.Providers;
using JuicesUp.Features.SeasonPass.Internal.Repositories;
using JuicesUp.Features.SeasonPass.Internal.Views;
using UniRx;
using VContainer;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	[Preserve]
	internal class BattlePassManager : IDisposable, IAsyncInitializable, IBattlePassManager, IBattlePassGameDataProvider
	{
		private readonly IBattlePassRemoteConfigsProvider _remoteConfigsProvider;

		private readonly IBattlePassAnalytics _analytics;

		private readonly IBattlePassStateRepository _repositoryService;

		private readonly IBattlePassAppBridge _appBridge;

		private BattlePassState _cachedState;

		private readonly IBattlePassSeasonService _seasonService;

		private readonly IBattlePassProgressionService _progressionService;

		private readonly IBattlePassPurchaseService _purchaseService;

		private readonly IBattlePassPerksService _perksService;

		private readonly ReactiveProperty<bool?> _isSeasonActiveAfterInit;

		private readonly Subject<Unit> _mainMenuLoaded;

		public IReadOnlyReactiveProperty<bool?> IsSeasonActiveAfterInit => null;

		public IObservable<Unit> MainMenuLoaded => null;

		public IBattlePassPerksService PerksService => null;

		public BattlePassState State => null;

		public int LastGameTokensEarned => 0;

		public IFeature MainOffer => null;

		public ChainedOffer FreeProgressionNPO => null;

		public ChainedOffer PremiumProgressionNPO => null;

		public bool IsSeasonActive => false;

		public bool IsInGracePeriod => false;

		public bool ShouldShowGracePeriodScreen => false;

		private bool IsProperlyConfigured => false;

		private bool HasUnclaimedMilestones => false;

		public bool HasUnclaimedRewards => false;

		public bool CanPurchasePremium => false;

		public void OnMainMenuLoaded()
		{
		}

		public BattlePassManager(IBattlePassRemoteConfigsProvider remoteConfigsProvider, IBattlePassAnalytics analytics, IBattlePassStateRepository repositoryService, IBattlePassAppBridge appBridge)
		{
		}

		private void OnLevelChanged(int level)
		{
		}

		public void ClearState()
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void InitializeServices()
		{
		}

		public void SaveState()
		{
		}

		public void CompleteGracePeriod()
		{
		}

		public TimeSpan GetTimeRemaining()
		{
			return default(TimeSpan);
		}

		public void CheckSeasonStatus()
		{
		}

		public void RefreshSeasonDetection()
		{
		}

		public void AddTokens(int amount)
		{
		}

		public void CheckCompletedAnalytics()
		{
		}

		public void ClaimMilestone(BattlePassType type, int stepIndex, Action<bool> onComplete = null)
		{
		}

		public void ClaimFreeMilestone(int stepIndex, Action<bool> onComplete = null)
		{
		}

		public void ClaimPremiumMilestone(int stepIndex, Action<bool> onComplete = null)
		{
		}

		public int GetCurrentFreeMilestoneIndex()
		{
			return 0;
		}

		public int GetTotalFreeMilestones()
		{
			return 0;
		}

		public int GetCurrentPremiumMilestoneIndex()
		{
			return 0;
		}

		public int GetTotalPremiumMilestones()
		{
			return 0;
		}

		public int GetNextClaimableFreeMilestoneIndex()
		{
			return 0;
		}

		public int GetNextClaimablePremiumMilestoneIndex()
		{
			return 0;
		}

		public int GetUnclaimedMilestoneCount()
		{
			return 0;
		}

		public int GetUnclaimedMilestoneCount(int tokens)
		{
			return 0;
		}

		public int GetUnclaimedRewardsCount()
		{
			return 0;
		}

		public string GetPremiumPrice()
		{
			return null;
		}

		public IFeature PurchasePremium(string placement, Action<bool> onComplete = null)
		{
			return null;
		}

		public List<BattlePassReward> AutoClaimAllRewards()
		{
			return null;
		}

		public List<BattlePassReward> GetUnclaimedRewardsList()
		{
			return null;
		}

		public void TrackUnclaimedRewardsTransactions()
		{
		}

		public List<BattlePassReward> GetRewardsForFreeStep(int stepIndex)
		{
			return null;
		}

		public List<BattlePassReward> GetRewardsForPremiumStep(int stepIndex)
		{
			return null;
		}

		public List<BattlePassReward> GetAllMilestoneAggregateRewards(bool isPremiumTrack)
		{
			return null;
		}

		public List<BattlePassReward> GetMilestoneRewardsPerTrack(bool isPremiumTrack, int index, out bool isSpecial, out string milestoneArtId)
		{
			isSpecial = default(bool);
			milestoneArtId = null;
			return null;
		}

		public int GetRequiredTokensForFreeMilestone(int stepIndex)
		{
			return 0;
		}

		public int GetAllMilestonesTokensRequired()
		{
			return 0;
		}

		public string GetSpecialArtIdForFreeMilestone(int stepIndex, out bool isSpecial)
		{
			isSpecial = default(bool);
			return null;
		}

		public string GetSpecialArtIdForPremiumMilestone(int stepIndex, out bool isSpecial)
		{
			isSpecial = default(bool);
			return null;
		}

		private void ValidateConfiguration()
		{
		}

		public void Dispose()
		{
		}
	}
}
