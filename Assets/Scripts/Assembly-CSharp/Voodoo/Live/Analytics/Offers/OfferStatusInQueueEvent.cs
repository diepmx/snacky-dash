using System.Collections.Generic;

namespace Voodoo.Live.Analytics.Offers
{
	public class OfferStatusInQueueEvent : BaseOfferStatusFilteredEvent
	{
		public override string EventName => null;

		public override string ExpectedStatus => null;

		protected override List<string> Parameters => null;
	}
}
