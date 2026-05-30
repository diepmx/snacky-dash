using System.Collections.Generic;

namespace Voodoo.Sauce.Internal.Analytics
{
	public class RsConfigStatusEvent
	{
		public RsConfigStatusStep Step { get; }

		public RsConfigStatusOrigin Origin { get; }

		public Dictionary<string, object> Data { get; }

		public Dictionary<string, object> Context { get; }

		public RsConfigStatusEvent(RsConfigStatusStep step, RsConfigStatusOrigin origin, string url)
		{
		}

		public RsConfigStatusEvent(RsConfigStatusStep step, RsConfigStatusOrigin origin, bool hasTimeout)
		{
		}

		public RsConfigStatusEvent(RsConfigStatusStep step, RsConfigStatusOrigin origin, VoodooTuneInitAnalyticsInfo info, string errorMessage = "")
		{
		}

		private void StoreStepAndOriginInContext()
		{
		}
	}
}
