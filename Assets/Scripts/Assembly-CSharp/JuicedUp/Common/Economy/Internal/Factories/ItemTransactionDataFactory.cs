using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Features.Core.Analytics;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicedUp.Common.Economy.Internal.Factories
{
	internal class ItemTransactionDataFactory : IItemTransactionDataFactory
	{
		private IEntitlementStorage _entitlementStorage;

		private IBoosterStorage _boosterStorage;

		private IWallet _wallet;

		public ItemTransactionDataFactory(IEntitlementStorage entitlementStorage, IBoosterStorage boosterStorage, IWallet wallet)
		{
		}

		public IEnumerable<ItemTransactionData> CreateItemTransactionData(IEnumerable<IReward> rewards, EconomySource source)
		{
			return null;
		}

		public IEnumerable<ItemTransactionData> CreateItemTransactionData(IEnumerable<ICost> costs, EconomySource source)
		{
			return null;
		}

		public IEnumerable<ItemTransactionData> CreateItemTransactionData(IProduct product, EconomySource source, string purchaseUuid = null)
		{
			return null;
		}

		public ItemTransactionData CreateItemTransactionData(IReward reward, EconomySource source)
		{
			return default(ItemTransactionData);
		}

		public ItemTransactionData CreateItemTransactionData(IReward reward, EconomySource source, int levelOverride, string levelDifficultyOverride)
		{
			return default(ItemTransactionData);
		}

		private ItemTransactionData BuildItemTransactionData(IReward reward, TransactionType transactionType, string IapId, EconomySource source, string purchaseUuid = null)
		{
			return default(ItemTransactionData);
		}

		private ItemTransactionData BuildItemTransactionData(IReward reward, TransactionType transactionType, string IapId, EconomySource source, int levelOverride, string levelDifficultyOverride, string purchaseUuid = null)
		{
			return default(ItemTransactionData);
		}

		private ItemTransactionData BuildItemTransactionData(ICost cost, EconomySource source)
		{
			return default(ItemTransactionData);
		}

		private int GetBalance(IReward reward)
		{
			return 0;
		}
	}
}
