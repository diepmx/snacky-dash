namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	internal class FrameCounter
	{
		private bool _isRunning;

		private float? _timeout;

		private float _timer;

		private float _minMs;

		private float _maxMs;

		private float _numFrames;

		private float _sumFps;

		private float _sumFpsSquared;

		private int _badFrames;

		private int _terribleFrames;

		private int _lowMemWarnings;

		private FrameCounterService _frameCounterService;

		internal FrameCounter(FrameCounterService frameCounterService)
		{
		}

		internal bool IsRunning()
		{
			return false;
		}

		private void OnMemoryWarning()
		{
		}

		internal void Start()
		{
		}

		internal void Stop()
		{
		}

		internal virtual void Reset()
		{
		}

		internal void OnUpdate(float frameLength, float instantFps, float instantFpsSquare, bool isBadFrame, bool isTerribleFrame)
		{
		}

		protected void SetTimeout(float timeout)
		{
		}

		protected virtual void OnTimeout()
		{
		}

		internal ContinuousMetrics GetContinuousMetricsSnapshot()
		{
			return default(ContinuousMetrics);
		}

		internal void Dispose()
		{
		}
	}
}
