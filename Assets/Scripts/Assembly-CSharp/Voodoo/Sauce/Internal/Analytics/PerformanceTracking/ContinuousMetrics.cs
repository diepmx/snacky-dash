namespace Voodoo.Sauce.Internal.Analytics.PerformanceTracking
{
	public struct ContinuousMetrics
	{
		public float Duration;

		public float MinFps;

		public float MaxFps;

		public float AvgFps;

		public float VarFps;

		public int BadFrames;

		public int TerribleFrames;

		public int LowMemoryWarnings;
	}
}
