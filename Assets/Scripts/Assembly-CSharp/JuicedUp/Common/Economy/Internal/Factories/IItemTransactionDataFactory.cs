using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Common.Economy.Internal.Factories
{
	internal interface IItemTransactionDataFactory
	{
		IEnumerable<ItemTransactionData> CreateItemTransactionData(IEnumerable<IReward> rewards, EconomySource source);

		IEnumerable<ItemTransactionData> CreateItemTransactionData(IEnumerable<ICost> costs, EconomySource source);

		IEnumerable<ItemTransactionData> CreateItemTransactionData(IProduct product, EconomySource source, string purchaseUuid = null);

		ItemTransactionData CreateItemTransactionData(IReward reward, EconomySource source);

		ItemTransactionData CreateItemTransactionData(IReward reward, EconomySource source, int levelOverride, string levelDifficultyOverride);
	}
}
