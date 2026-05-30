using System;

namespace JuicedUp.Common.Config
{
	[Serializable]
	public class GraphicsQualityConfig
	{
		public bool IsEnabled;

		public int Tier;

		public int TargetFrameRate;

		public float RenderScaleOverride;

		public bool IsHapticThrottlingEnabled;
	}
}
