using System.Diagnostics;
using Lofelt.NiceVibrations;

namespace JuicedUp.Common.Haptics
{
	public class HapticService : IHapticService
	{
		private const int PerformanceThrottleFrames = 6;

		private const int UXThrottleFrames = 4;

		private int _lastPerformanceThrottledFrame;

		private int _lastUXThrottledFrame;

		private bool _isPerformanceThrottleEnabled;

		public void Selection()
		{
		}

		public void LightImpact()
		{
		}

		public void MediumImpact()
		{
		}

		public void HeavyImpact()
		{
		}

		public void Success()
		{
		}

		public void ButtonTap()
		{
		}

		public void ProgressTick()
		{
		}

		public void ComboReward()
		{
		}

		[Conditional("UNITY_EDITOR")]
		private static void LogEditor(string hapticName)
		{
		}

		internal void SetPerformanceThrottleEnabled(bool isEnabled)
		{
		}

		private void PlayPreset(HapticPatterns.PresetType preset)
		{
		}

		private void PlayEmphasis(float amplitude, float frequency)
		{
		}

		private bool ShouldSkip()
		{
			return false;
		}

		private bool ShouldPerformanceThrottle()
		{
			return false;
		}

		private bool ShouldUXThrottle()
		{
			return false;
		}

		private float PresetToAmplitude(HapticPatterns.PresetType preset)
		{
			return 0f;
		}
	}
}
