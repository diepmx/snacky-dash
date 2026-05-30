using System.Collections.Generic;

namespace Voodoo.Live.Analytics.Offers
{
	public abstract class BaseOfferEvent : BaseEvent
	{
		protected override List<string> Parameters => null;

		public override void Track(IBlackboard blackboard)
		{
		}
	}
}
