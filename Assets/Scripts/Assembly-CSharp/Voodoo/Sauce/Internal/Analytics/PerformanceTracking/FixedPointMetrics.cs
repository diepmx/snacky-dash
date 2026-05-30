using Voodoo.Sauce.ThermalState;

namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	public struct FixedPointMetrics
	{
		public float BatteryLevel;

		public int VolumeLevel;

		public int ThermalState;

		public long MemoryUsage;

		public float MemoryUsagePercent;

		public ulong SystemMemoryUsage;

		public float SystemMemoryUsagePercent;

		internal static ThermalStateService ThermalStateService;

		private const int THERMAL_STATE_DISABLED = -3;

		private const float ONE_MEGABYTE_IN_BYTES = 1048576f;

		internal static void InitThermalState(bool enableThermalState)
		{
		}

		internal static FixedPointMetrics GetSnapshot()
		{
			return default(FixedPointMetrics);
		}
	}
}
