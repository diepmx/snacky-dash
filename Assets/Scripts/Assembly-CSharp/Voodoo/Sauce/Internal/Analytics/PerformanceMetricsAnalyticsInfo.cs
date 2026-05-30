using Voodoo.Sauce.Internal.Analytics.PerformanceTracking;

namespace Voodoo.Sauce.Internal.Analytics
{
	public struct PerformanceMetricsAnalyticsInfo
	{
		public PerformanceTrackingMeasurementType MeasurementType;

		public string MeasurementContext;

		public float MeasurementDuration;

		public float BatteryLevel;

		public int Volume;

		public double AverageMemoryUsagePercentage;

		public FloatMetric Fps;

		public FloatMetric MemoryUsage;

		public float SystemMemoryUsage;

		public double SystemMemoryUsagePercentage;

		public int LowMemoryWarnings;

		public int BadFrames;

		public int TerribleFrames;

		public int ThermalState;

		public string GetBatteryLevelAsString()
		{
			return null;
		}
	}
}
