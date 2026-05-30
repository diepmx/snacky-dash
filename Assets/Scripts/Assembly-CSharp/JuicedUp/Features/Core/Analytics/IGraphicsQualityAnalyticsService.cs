namespace JuicedUp.Features.Core.Analytics
{
	public interface IGraphicsQualityAnalyticsService
	{
		void TrackGraphicsQualityApplied(int tier, int targetFrameRate, float renderScale, bool wasRenderScaleOverridden, bool hapticThrottleEnabled);

		void TrackGraphicsQualityApplyFailed(string reason);
	}
}
