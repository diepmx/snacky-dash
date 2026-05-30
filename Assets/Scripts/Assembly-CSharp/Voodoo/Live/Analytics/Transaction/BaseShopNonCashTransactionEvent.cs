using System.Collections.Generic;
using Voodoo.Live.Analytics.Shop;

namespace Voodoo.Live.Analytics.Transaction
{
	public abstract class BaseShopNonCashTransactionEvent : BaseShopProductEvent
	{
		protected override List<string> Parameters => null;
	}
}
