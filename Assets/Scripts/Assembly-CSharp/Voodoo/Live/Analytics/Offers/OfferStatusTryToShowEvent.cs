using System.Collections.Generic;
using Voodoo.Live.Analytics.OfferSource;

namespace Voodoo.Live.Analytics.Offers
{
	public class OfferStatusTryToShowEvent : BaseOfferStatusFilteredEvent
	{
		private readonly ISourceParameters _sourceProvider;

		public override string EventName => null;

		public override string ExpectedStatus => null;

		protected override List<string> Parameters => null;
	}
}
