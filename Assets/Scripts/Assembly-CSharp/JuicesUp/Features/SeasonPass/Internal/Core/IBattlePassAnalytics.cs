using JuicesUp.Features.SeasonPass.Internal.Data;
using Voodoo.Live.Offers;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassAnalytics
	{
		void TrackEventJoined(BattlePassState state);

		void TrackImpression(BattlePassState state, ImpressionTrigger trigger, float barProgression, int rewardsDisplayed);

		void TrackMilestoneCompleted(BattlePassState state, int stepIndex, int requiredTokens);

		void TrackItemTransaction(BattlePassState state, int stepIndex, bool isFreeTrack, string itemName, int quantity);

		void TrackEventCompleted(BattlePassState state, int maxMilestoneLevel);

		void TrackIAPRewarded(BattlePassState state, int milestoneLevel, IFeature offer, IIAPRewardedInfo iapInfo, string placement);

		void TrackIAPRewardedFallback(BattlePassState state, int milestoneLevel, IFeature offer, string transactionId);
	}
}
