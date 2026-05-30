using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Core.Analytics
{
	public interface ICoreGameAnalyticsService
	{
		void TrackGameStart();

		void TrackGameFinished(bool isWin, DefeatType? defeatTypeOverride = null);

		void TrackGameClick(PlacementId placement);

		void TrackItemTransaction(ItemTransactionData payload);

		void TrackItemTransactions(IEnumerable<ItemTransactionData> payloads);

		void TrackLoseFlowImpression(LoseFlowImpressionData payload);

		void TrackLoseFlowAction(LoseFlowActionData payload);

		void TrackOutOfCoins(PlacementId placement);

		void TrackOutOfLives(PlacementId placement);

		void TrackOutOfBoosters(PlacementId placement);

		void TrackBoosterActivation(BoosterId boosterId);

		void TrackTutorialStepCompleted(string stepName, int stepIndex, float durationSeconds, int swipeCount);

		void TrackPlayerStuckDetected(PlayerStuckData payload);

		void TrackEgpTriggered(EgpTriggeredData payload);

		void TrackTailBridgeCollision(TailBridgeCollisionData payload);
	}
}
