using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public interface IBoosterTutorialRepository
	{
		event Action<BoosterId, bool> FirstFreeAvailabilityChanged;

		bool HasClaimedStarterReward(BoosterId id);

		void MarkStarterRewardClaimed(BoosterId id);

		bool IsFirstFreeAvailable(BoosterId id);

		void ConsumeFirstFree(BoosterId id);

		bool HasSeenForcedTutorial(BoosterId id);

		void MarkForcedTutorialSeen(BoosterId id);
	}
}
