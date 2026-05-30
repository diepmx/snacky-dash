using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Data;
using Voodoo.Live.Offers;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal class BattlePassAnalytics : IBattlePassAnalytics
	{
		private readonly IBattlePassAppBridge _appBridge;

		public BattlePassAnalytics(IBattlePassAppBridge appBridge)
		{
		}

		public void TrackEventJoined(BattlePassState state)
		{
		}

		public void TrackImpression(BattlePassState state, ImpressionTrigger trigger, float barProgression, int rewardsDisplayed)
		{
		}

		public void TrackMilestoneCompleted(BattlePassState state, int stepIndex, int requiredTokens)
		{
		}

		public void TrackItemTransaction(BattlePassState state, int stepIndex, bool isFreeTrack, string itemName, int quantity)
		{
		}

		public void TrackEventCompleted(BattlePassState state, int maxMilestoneLevel)
		{
		}

		public void TrackIAPRewarded(BattlePassState state, int milestoneLevel, IFeature offer, IIAPRewardedInfo iapInfo, string placement)
		{
		}

		public void TrackIAPRewardedFallback(BattlePassState state, int milestoneLevel, IFeature offer, string transactionId)
		{
		}

		private void AddBoosterBalances(Dictionary<string, object> props)
		{
		}

		private int GetSecondsRemaining(BattlePassState state)
		{
			return 0;
		}

		private string FormatRunId(BattlePassState state)
		{
			return null;
		}

		private static string FormatRunId(DateTime seasonStartDate)
		{
			return null;
		}

		private static string FormatImpressionTrigger(ImpressionTrigger trigger)
		{
			return null;
		}
	}
}
