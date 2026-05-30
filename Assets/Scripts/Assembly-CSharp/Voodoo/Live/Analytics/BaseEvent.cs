using System.Collections.Generic;

namespace Voodoo.Live.Analytics
{
	public abstract class BaseEvent : IAnalyticsEvent, ITrackableEvent
	{
		public abstract string EventName { get; }

		protected virtual List<string> Parameters => null;

		public Dictionary<string, object> GetParameters(IBlackboard blackboard)
		{
			return null;
		}

		public virtual void Track(IBlackboard blackboard)
		{
		}

		public virtual bool CanTrack(IBlackboard blackboard)
		{
			return false;
		}
	}
}
