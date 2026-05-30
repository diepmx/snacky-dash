using System;

namespace Voodoo.Live
{
	public class TransactionReceipt
	{
		public string purchaseId;

		public PriceDTO price;

		public ItemQuantityDTO[] rewards;

		public string uuid;

		public DateTime date;

		public TransactionReceipt(string purchaseId, PriceDTO price, ItemQuantityDTO[] rewards)
		{
		}

		public bool IsValid(out string error)
		{
			error = null;
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
