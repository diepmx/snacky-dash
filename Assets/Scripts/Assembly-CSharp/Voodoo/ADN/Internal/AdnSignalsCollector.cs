using System.Collections.Generic;
using Voodoo.Sauce.Internal.Analytics;

namespace Voodoo.ADN.Internal
{
	internal class AdnSignalsCollector
	{
		private bool _isInitialized;

		private bool _canCollectSignals;

		private AdnAppSignalsCollector _appSignalsCollector;

		private AdnAdsSignalsCollector _adsSignalsCollector;

		public string LastCollectedSignals { get; private set; }

		public void Initialize(bool consent, bool isCcpaApplicable)
		{
		}

		private void RegisterEvents()
		{
		}

		private void OnGameFinished(GameFinishedParameters parameters)
		{
		}

		private void OnImpressionTrackedEvent(ImpressionAnalyticsInfo info)
		{
		}

		private void OnInterstitialClickedEvent(AdClickEventAnalyticsInfo info)
		{
		}

		private void OnInterstitialShownEvent(AdShownEventAnalyticsInfo info)
		{
		}

		private void OnInterstitialDismissedEvent(AdClosedEventAnalyticsInfo info)
		{
		}

		private void OnRewardedVideoClickedEvent(AdClickEventAnalyticsInfo info)
		{
		}

		private void OnRewardedVideoShownEvent(AdShownEventAnalyticsInfo info)
		{
		}

		private void OnRewardedVideoClosedEvent(AdClosedEventAnalyticsInfo info)
		{
		}

		private void OnInterstitialLoadRequestEvent(AdAnalyticsInfo info)
		{
		}

		private void OnInterstitialLoadedEvent(AdLoadedEventAnalyticsInfo info)
		{
		}

		private void OnRewardedLoadRequestEvent(AdAnalyticsInfo info)
		{
		}

		private void OnRewardedVideoLoadedEvent(AdLoadedEventAnalyticsInfo info)
		{
		}

		private void OnRewardedVideoAdReviewEvent(AdReviewAnalyticsInfo info)
		{
		}

		private void OnInterstitialAdReviewEvent(AdReviewAnalyticsInfo info)
		{
		}

		private void OnAttributionChangedEvent(AttributionAnalyticsInfo info)
		{
		}

		private void OnLoadRequestEvent(string placement, AdAnalyticsInfo info)
		{
		}

		private void OnAdLoadedEvent(string placement, AdLoadedEventAnalyticsInfo info)
		{
		}

		private void TrackPerformanceMetrics(PerformanceMetricsAnalyticsInfo metrics)
		{
		}

		private void SendSignals()
		{
		}

		private Dictionary<string, object> BuildSignalsWithConsent()
		{
			return null;
		}

		private static Dictionary<string, object> BuildSignalsWithoutConsent()
		{
			return null;
		}
	}
}
