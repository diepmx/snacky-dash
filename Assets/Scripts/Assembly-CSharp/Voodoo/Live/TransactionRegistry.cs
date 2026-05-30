using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Voodoo.Live.Utils;

namespace Voodoo.Live
{
	public static class TransactionRegistry
	{
		private const string TransactionDataFileName = "voodoolive_local_transactions.json";

		private const string TransactionDataPath = "VoodooLive/voodoolive_local_transactions.json";

		private static CacheSystem _cache;

		private static string _cachePayload;

		private static List<Transaction> _onGoingTransactions;

		private static TransactionReceipts _receipts;

		private static Func<Transaction, bool> rewardingFunc;

		private static IInventory _inventory;

		public static bool initializedProperly;

		public static bool HasPendingTransactions => false;

		public static int PendingTransactionCount => 0;

		public static string CacheData => null;

		public static string CacheFilePath => null;

		public static List<TransactionReceipt> PendingTransactions => null;

		public static List<TransactionReceipt> ArchivedTransactions => null;

		public static event Action transactionStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<TransactionReceipt, bool> transactionCompleted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		static TransactionRegistry()
		{
		}

		public static void Initialize(Func<Transaction, bool> rewardingFunc, IInventory inventory)
		{
		}

		private static void RelaunchPendingTransactions()
		{
		}

		private static void AddPending(Transaction transaction, bool addToCache = true)
		{
		}

		public static void Start(Transaction transaction)
		{
		}

		public static void Restore(Transaction transaction)
		{
		}

		private static void OnTransactionCompleted(Transaction transaction, bool success)
		{
		}

		private static void Archive(Transaction transaction)
		{
		}

		private static void RemoveDuplicateTransaction(string productId)
		{
		}

		public static Transaction GetTransactionByPurchaseId(string purchaseId)
		{
			return null;
		}

		public static Transaction GetTransactionBySKU(string productId)
		{
			return null;
		}

		public static void Dispose()
		{
		}
	}
}
