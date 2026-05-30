using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IEconomyService
	{
		bool CanSpend(ICost[] costs);

		bool TrySpend(ICost[] costs, EconomySource source);

		void Grant(IEnumerable<IReward> rewards, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true);

		void Grant(IProduct product, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true, string purchaseUuid = null);

		void Grant(IReward reward, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true);

		void GrantWithLevelContext(IReward reward, EconomySource source, int level, string levelDifficulty, RewardPresentationContext context = null, bool syncImmediately = true);

		bool TrySpendAndGrant(ICost[] costs, IEnumerable<IReward> rewards, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true);
	}
}
