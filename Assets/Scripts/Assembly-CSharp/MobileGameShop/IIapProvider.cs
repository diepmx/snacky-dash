using System;
using System.Collections.Generic;

namespace MobileGameShop
{
	public interface IIapProvider
	{
		bool IsInitialized { get; }

		void Initialize(IEnumerable<string> productIds, Action<bool, string> onDone);

		string GetLocalizedPrice(string productId);

		void Purchase(string productId, Action<PurchaseResult> onDone);

		void Restore(Action<bool, string> onDone);

		bool HasReceipt(string productId);
	}
}
