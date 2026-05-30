using System;
using JuicedUp.Core.Bootstrap.Builder;

namespace JuicedUp.Core.Bootstrap.Analytics
{
	public interface IBootstrapAnalytics
	{
		void TrackStageStarted(BuildStage stage, int sequentialCount, int parallelCount);

		void TrackStageCompleted(BuildStage stage, long durationMs);

		void TrackStepStarted(BuildStage stage, string stepName, bool isParallel);

		void TrackStepCompleted(BuildStage stage, string stepName, bool isParallel, long durationMs);

		void TrackStepFailed(BuildStage stage, string stepName, bool isParallel, long durationMs, Exception ex);

		void TrackLoadingScreenShown();

		void TrackLoadingPhase(string phase, long elapsedMsSinceShown);

		void TrackVsInitialized(long elapsedMs, bool isLate, string status, long? elapsedMsSinceHidden = null);

		void TrackLoadingScreenHidden(long elapsedMs, bool wasVsReady);
	}
}
