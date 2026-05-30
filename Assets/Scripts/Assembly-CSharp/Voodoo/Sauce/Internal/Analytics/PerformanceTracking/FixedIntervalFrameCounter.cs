using System;

namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class FixedIntervalFrameCounter : FrameCounter
	{
		private readonly Action<ContinuousMetrics, FixedPointMetrics> _callback;

		internal FixedIntervalFrameCounter(FrameCounterService frameCounterService, float intervalInSeconds, Action<ContinuousMetrics, FixedPointMetrics> callback)
			: base(null)
		{
		}

		protected override void OnTimeout()
		{
		}
	}
}
