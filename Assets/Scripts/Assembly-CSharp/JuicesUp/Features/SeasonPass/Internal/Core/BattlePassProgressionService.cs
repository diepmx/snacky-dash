using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;
using VContainer;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	[Preserve]
	internal class BattlePassProgressionService : IBattlePassProgressionService
	{
		private const string ChainedOfferCurrentStepKey = "CurrentStep";

		private readonly IBattlePassManager _manager;

		private readonly IBattlePassAnalytics _analytics;

		public ChainedOffer FreeProgressionNPO { get; private set; }

		public ChainedOffer PremiumProgressionNPO { get; private set; }

		public bool HasUnclaimedMilestones => false;

		public BattlePassProgressionService(IBattlePassManager manager, IBattlePassAnalytics analytics)
		{
		}

		public void RefreshProgressionOffers(string seasonKey)
		{
		}

		private ChainedOffer FindNpoByTags(string tag1, string tag2)
		{
			return null;
		}

		private void RestoreProgressFromLocalState()
		{
		}

		private void AdvanceNpoProgress(ChainedOffer npo, int targetStep)
		{
		}

		private bool SetNpoCurrentStep(ChainedOffer npo, int targetStep)
		{
			return false;
		}

		public void AddTokens(int amount)
		{
		}

		public void CheckCompletedMilestones()
		{
		}

		private static int GetRequiredTokensForMilestone(ChainedOffer npo, int stepIndex)
		{
			return 0;
		}

		public int GetRequiredTokens(ChainedOffer npo, int stepIndex)
		{
			return 0;
		}

		public string GetSpecialMilestoneArtId(ChainedOffer npo, int stepIndex, out bool isSpecial)
		{
			isSpecial = default(bool);
			return null;
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

		private int CountFreeUnclaimedRewards(int tokens)
		{
			return 0;
		}

		private int CountPremiumUnclaimedRewards(int tokens)
		{
			return 0;
		}

		public List<BattlePassReward> GetUnclaimedRewardsList()
		{
			return null;
		}

		public void TrackUnclaimedRewardsTransactions()
		{
		}

		private void ForEachUnclaimedStep(Action<ChainedOffer, int, bool> action)
		{
		}

		private void TrackRewardsForStep(ChainedOffer npo, int stepIndex, bool isFreeTrack)
		{
		}

		public void ClaimFreeMilestone(int stepIndex, Action<bool> onComplete = null)
		{
		}

		public void ClaimPremiumMilestone(int stepIndex, Action<bool> onComplete = null)
		{
		}

		private void ClaimMilestone(ChainedOffer npo, int stepIndex, bool isFreeTrack, Action<bool> onComplete)
		{
		}

		private void OnMilestoneClaimSuccess(ChainedOffer npo, int claimedStep, bool isFreeTrack)
		{
		}

		public List<BattlePassReward> AutoClaimAllRewards()
		{
			return null;
		}

		private List<BattlePassReward> ClaimAllAvailableFree()
		{
			return null;
		}

		private List<BattlePassReward> ClaimAllAvailablePremium()
		{
			return null;
		}

		private bool ClaimMilestoneSync(ChainedOffer npo, int stepIndex, bool isFreeTrack)
		{
			return false;
		}

		public List<BattlePassReward> GetRewardsForStep(ChainedOffer npo, int stepIndex)
		{
			return null;
		}

		public List<BattlePassReward> GetAllMilestoneRewards(bool isPremiumTrack)
		{
			return null;
		}

		public List<BattlePassReward> GetMilestoneRewardsPerTrack(bool isPremiumTrack, int index, out bool isSpecial, out string milestoneArtId)
		{
			isSpecial = default(bool);
			milestoneArtId = null;
			return null;
		}

		public List<BattlePassReward> GetAllMilestoneAggregateRewards(bool isPremiumTrack)
		{
			return null;
		}
	}
}
