using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public static class PurchaseFactory
	{
		public static IInventory inventory;

		public static Action<string, Dictionary<string, object>> purchaseIAP;

		public static IPayment Create(IPrice price)
		{
			return null;
		}

		public static IPayment Create(PriceDTO dto)
		{
			return null;
		}

		private static void PurchaseIAP(string productId, Dictionary<string, object> parameters)
		{
		}
	}
}
