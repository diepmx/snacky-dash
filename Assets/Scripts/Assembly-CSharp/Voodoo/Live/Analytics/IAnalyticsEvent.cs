using System.Collections.Generic;

namespace Voodoo.Live.Analytics
{
	public interface IAnalyticsEvent
	{
		string EventName { get; }

		Dictionary<string, object> GetParameters(IBlackboard blackboard);
	}
}
