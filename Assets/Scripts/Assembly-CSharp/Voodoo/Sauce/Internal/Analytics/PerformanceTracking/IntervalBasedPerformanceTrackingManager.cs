namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class IntervalBasedPerformanceTrackingManager : PerformanceTrackingManager
	{
		private readonly FixedIntervalFrameCounter _frameCounter;

		private readonly string _eventContext;

		internal IntervalBasedPerformanceTrackingManager(FrameCounterService frameCounterService, float intervalInSeconds)
			: base(default(PerformanceTrackingMeasurementType))
		{
		}

		private void SendEvent(ContinuousMetrics continuousMetrics, FixedPointMetrics fixedPointMetrics)
		{
		}

		internal void Dispose()
		{
		}
	}
}
