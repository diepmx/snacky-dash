using System.Collections.Generic;
using Voodoo.Live.Analytics.Offers;

namespace Voodoo.Live.Analytics.Spin
{
	public class SpinRollResultEvent : SpinEvent
	{
		private OfferStatusProductClickedEvent _offerStatusProductClickedEvent;

		public override string EventName => null;

		public override string ExpectedStatus => null;

		protected override List<string> Parameters => null;

		public override void Track(IBlackboard blackboard)
		{
		}

		public bool ShouldTrackProductClickedEvent(IBlackboard blackboard)
		{
			return false;
		}
	}
}
