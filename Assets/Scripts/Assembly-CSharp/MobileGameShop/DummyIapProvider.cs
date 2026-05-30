using System;
using System.Collections.Generic;

namespace MobileGameShop
{
	public class DummyIapProvider : IIapProvider
	{
		public bool IsInitialized { get; private set; }

		public void Initialize(IEnumerable<string> productIds, Action<bool, string> onDone)
		{
		}

		public string GetLocalizedPrice(string productId)
		{
			return null;
		}

		public void Purchase(string productId, Action<PurchaseResult> onDone)
		{
		}

		public void Restore(Action<bool, string> onDone)
		{
		}

		public bool HasReceipt(string productId)
		{
			return false;
		}
	}
}
