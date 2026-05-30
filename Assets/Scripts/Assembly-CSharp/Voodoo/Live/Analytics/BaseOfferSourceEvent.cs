using System.Collections.Generic;
using Voodoo.Live.Analytics.OfferSource;
using Voodoo.Live.Analytics.Offers;

namespace Voodoo.Live.Analytics
{
	public abstract class BaseOfferSourceEvent : BaseOfferEvent
	{
		private readonly ISourceParameters _sourceProvider;

		protected override List<string> Parameters => null;
	}
}
