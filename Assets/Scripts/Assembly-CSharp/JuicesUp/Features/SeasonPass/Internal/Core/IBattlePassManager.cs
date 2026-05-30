using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;
using JuicesUp.Features.SeasonPass.Internal.Views;
using UniRx;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassManager
	{
		IReadOnlyReactiveProperty<bool?> IsSeasonActiveAfterInit { get; }

		IObservable<Unit> MainMenuLoaded { get; }

		IBattlePassPerksService PerksService { get; }

		BattlePassState State { get; }

		IFeature MainOffer { get; }

		ChainedOffer FreeProgressionNPO { get; }

		ChainedOffer PremiumProgressionNPO { get; }

		bool IsSeasonActive { get; }

		bool IsInGracePeriod { get; }

		bool ShouldShowGracePeriodScreen { get; }

		bool HasUnclaimedRewards { get; }

		bool CanPurchasePremium { get; }

		void ClearState();

		void OnMainMenuLoaded();

		void SaveState();

		void CompleteGracePeriod();

		TimeSpan GetTimeRemaining();

		void CheckSeasonStatus();

		void RefreshSeasonDetection();

		void AddTokens(int amount);

		void CheckCompletedAnalytics();

		void ClaimMilestone(BattlePassType type, int stepIndex, Action<bool> onComplete = null);

		void ClaimFreeMilestone(int stepIndex, Action<bool> onComplete = null);

		void ClaimPremiumMilestone(int stepIndex, Action<bool> onComplete = null);

		int GetCurrentFreeMilestoneIndex();

		int GetTotalFreeMilestones();

		int GetCurrentPremiumMilestoneIndex();

		int GetTotalPremiumMilestones();

		int GetNextClaimableFreeMilestoneIndex();

		int GetNextClaimablePremiumMilestoneIndex();

		int GetUnclaimedMilestoneCount();

		int GetUnclaimedMilestoneCount(int tokens);

		int GetUnclaimedRewardsCount();

		string GetPremiumPrice();

		IFeature PurchasePremium(string placement, Action<bool> onComplete = null);

		List<BattlePassReward> AutoClaimAllRewards();

		List<BattlePassReward> GetUnclaimedRewardsList();

		void TrackUnclaimedRewardsTransactions();

		List<BattlePassReward> GetRewardsForFreeStep(int stepIndex);

		List<BattlePassReward> GetRewardsForPremiumStep(int stepIndex);

		int GetRequiredTokensForFreeMilestone(int stepIndex);

		int GetAllMilestonesTokensRequired();

		string GetSpecialArtIdForFreeMilestone(int stepIndex, out bool isSpecial);

		string GetSpecialArtIdForPremiumMilestone(int stepIndex, out bool isSpecial);

		List<BattlePassReward> GetAllMilestoneAggregateRewards(bool isPremiumTrack);

		List<BattlePassReward> GetMilestoneRewardsPerTrack(bool isPremiumTrack, int index, out bool isSpecial, out string milestoneArtId);
	}
}
