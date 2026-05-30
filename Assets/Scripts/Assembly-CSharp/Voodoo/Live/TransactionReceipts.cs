using System.Collections.Generic;

namespace Voodoo.Live
{
	public class TransactionReceipts
	{
		public List<TransactionReceipt> pendingTransactions;

		public List<TransactionReceipt> archivedTransactions;

		public bool HasPurchasePendingWithId(string purchaseId)
		{
			return false;
		}

		public void Add(TransactionReceipt receipt)
		{
		}

		public void Archive(TransactionReceipt receipt)
		{
		}
	}
}
