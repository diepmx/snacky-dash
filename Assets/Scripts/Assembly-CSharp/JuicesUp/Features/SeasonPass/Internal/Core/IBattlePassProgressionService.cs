using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassProgressionService
	{
		ChainedOffer FreeProgressionNPO { get; }

		ChainedOffer PremiumProgressionNPO { get; }

		bool HasUnclaimedMilestones { get; }

		void RefreshProgressionOffers(string seasonKey);

		void AddTokens(int amount);

		void CheckCompletedMilestones();

		int GetRequiredTokens(ChainedOffer npo, int stepIndex);

		string GetSpecialMilestoneArtId(ChainedOffer npo, int stepIndex, out bool isSpecial);

		string GetSpecialArtIdForFreeMilestone(int stepIndex, out bool isSpecial);

		string GetSpecialArtIdForPremiumMilestone(int stepIndex, out bool isSpecial);

		int GetCurrentFreeMilestoneIndex();

		int GetTotalFreeMilestones();

		int GetCurrentPremiumMilestoneIndex();

		int GetTotalPremiumMilestones();

		int GetNextClaimableFreeMilestoneIndex();

		int GetNextClaimablePremiumMilestoneIndex();

		int GetUnclaimedMilestoneCount();

		int GetUnclaimedMilestoneCount(int tokens);

		void ClaimFreeMilestone(int stepIndex, Action<bool> onComplete = null);

		void ClaimPremiumMilestone(int stepIndex, Action<bool> onComplete = null);

		List<BattlePassReward> AutoClaimAllRewards();

		List<BattlePassReward> GetUnclaimedRewardsList();

		void TrackUnclaimedRewardsTransactions();

		List<BattlePassReward> GetRewardsForStep(ChainedOffer npo, int stepIndex);

		List<BattlePassReward> GetAllMilestoneRewards(bool isPremiumTrack);

		List<BattlePassReward> GetAllMilestoneAggregateRewards(bool isPremiumTrack);

		List<BattlePassReward> GetMilestoneRewardsPerTrack(bool isPremiumTrack, int index, out bool isSpecial, out string milestoneArtId);
	}
}
