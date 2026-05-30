using System.Collections.Generic;

namespace Voodoo.Live.Analytics.Transaction
{
	public class SubOfferStatusNonCashTransactionFailedEvent : BaseOfferStatusNonCashTransactionEvent
	{
		public override string EventName => null;

		public override string ExpectedStatus => null;

		protected override List<string> Parameters => null;
	}
}
