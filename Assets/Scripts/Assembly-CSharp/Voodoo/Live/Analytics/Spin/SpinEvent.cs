using System.Collections.Generic;
using Voodoo.Live.Analytics.Offers;

namespace Voodoo.Live.Analytics.Spin
{
	public abstract class SpinEvent : BaseOfferStatusFilteredEvent
	{
		protected override List<string> Parameters => null;

		public override bool CanTrack(IBlackboard blackboard)
		{
			return false;
		}
	}
}
