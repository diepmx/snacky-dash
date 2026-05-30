using System.Collections.Generic;

namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class CustomPerformanceTrackingManager : PerformanceTrackingManager
	{
		private readonly Dictionary<string, FrameCounter> _activeFrameCounters;

		private const string TAG = "CustomPerformanceTrackingManager";

		private readonly FrameCounterService _frameCounterService;

		internal CustomPerformanceTrackingManager(FrameCounterService frameCounterService)
			: base(default(PerformanceTrackingMeasurementType))
		{
		}

		internal void StartTracking(string key)
		{
		}

		internal void StopTracking(string key)
		{
		}

		internal void Dispose()
		{
		}
	}
}
