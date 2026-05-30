using System;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicedUp.Features.Core.Analytics
{
	public struct ItemTransactionData
	{
		public string ItemName { get; }

		public ItemType ItemType { get; }

		public TransactionType TransactionType { get; }

		public int NumberOfUnits { get; }

		public Enum CurrencyUsed { get; }

		public string IapLocalCurrency { get; }

		public EconomySource EconomySource { get; }

		public double BalanceAfterTransaction { get; }

		public string PurchaseUuid { get; }

		public int? LevelOverride { get; }

		public string LevelDifficultyOverride { get; }

		public ItemTransactionData(string itemName, ItemType itemType, TransactionType transactionType, int numberOfUnits, Enum currencyUsed, string iapLocalCurrency, EconomySource economySource, double balanceAfterTransaction, string purchaseUuid = null)
		{
			ItemName = null;
			ItemType = default(ItemType);
			TransactionType = default(TransactionType);
			NumberOfUnits = 0;
			CurrencyUsed = null;
			IapLocalCurrency = null;
			EconomySource = default(EconomySource);
			BalanceAfterTransaction = 0.0;
			PurchaseUuid = null;
			LevelOverride = null;
			LevelDifficultyOverride = null;
		}

		public ItemTransactionData(string itemName, ItemType itemType, TransactionType transactionType, int numberOfUnits, Enum currencyUsed, string iapLocalCurrency, EconomySource economySource, double balanceAfterTransaction, int levelOverride, string levelDifficultyOverride, string purchaseUuid = null)
		{
			ItemName = null;
			ItemType = default(ItemType);
			TransactionType = default(TransactionType);
			NumberOfUnits = 0;
			CurrencyUsed = null;
			IapLocalCurrency = null;
			EconomySource = default(EconomySource);
			BalanceAfterTransaction = 0.0;
			PurchaseUuid = null;
			LevelOverride = null;
			LevelDifficultyOverride = null;
		}
	}
}
