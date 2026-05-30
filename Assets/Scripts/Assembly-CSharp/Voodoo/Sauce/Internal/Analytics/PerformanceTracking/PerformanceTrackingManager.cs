namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	public abstract class PerformanceTrackingManager
	{
		private readonly PerformanceTrackingMeasurementType _measurementType;

		protected PerformanceTrackingManager(PerformanceTrackingMeasurementType measurementType)
		{
		}

		protected void SendEvent(string context, ContinuousMetrics continuousMetrics, FixedPointMetrics fixedPointMetrics)
		{
		}
	}
}
