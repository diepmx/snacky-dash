namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class SceneBasedPerformanceTrackingManager : PerformanceTrackingManager
	{
		private readonly FrameCounter _frameCounter;

		private string _currentSceneName;

		internal SceneBasedPerformanceTrackingManager(FrameCounterService frameCounterService)
			: base(default(PerformanceTrackingMeasurementType))
		{
		}

		internal void StartSceneTracking(string sceneName)
		{
		}

		internal void StopSceneTracking()
		{
		}

		internal void Dispose()
		{
		}
	}
}
