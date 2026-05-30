namespace Voodoo.Live.Analytics.Offers
{
	public abstract class BaseOfferStatusFilteredEvent : BaseOfferEvent, IStatusFilteredEvent
	{
		public readonly string StatusKey;

		public virtual string ExpectedStatus => null;

		public override bool CanTrack(IBlackboard blackboard)
		{
			return false;
		}
	}
}
