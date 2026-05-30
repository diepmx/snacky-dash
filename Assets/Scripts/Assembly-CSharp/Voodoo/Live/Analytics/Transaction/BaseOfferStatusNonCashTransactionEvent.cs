using System.Collections.Generic;
using Voodoo.Live.Analytics.OfferSource;
using Voodoo.Live.Analytics.Offers;

namespace Voodoo.Live.Analytics.Transaction
{
	public abstract class BaseOfferStatusNonCashTransactionEvent : BaseOfferStatusFilteredEvent
	{
		private readonly ISourceParameters _sourceProvider;

		public readonly string NonCashTransactionKey;

		protected override List<string> Parameters => null;

		public override bool CanTrack(IBlackboard blackboard)
		{
			return false;
		}
	}
}
