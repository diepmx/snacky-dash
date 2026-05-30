using System.Collections.Generic;
using Voodoo.Sauce.Internal.Analytics;

namespace Voodoo.ADN.Internal
{
	internal class AdnAdsSignalsCollector
	{
		private const string FIRST_SESSION_ADS_KEY = "first_ad_sessions_key";

		private const string PREV_SESSION_ADS_KEY = "prev_ad_session_key";

		private const string TOTAL_ADS_REVENUE_KEY = "total_ads_revenue_key";

		private const string FS_CLICK_COUNT_KEY = "fs_click_count_key";

		private const string RV_CLICK_COUNT_KEY = "rv_click_count_key";

		private readonly List<AdnAdData> _firstSessionAdsList;

		private readonly Queue<AdnAdData> _activeSessionAdsQueue;

		private readonly List<Dictionary<string, object>> _prevSessionAdsList;

		private readonly object _syncRoot;

		private string _fsReviewCreativeId;

		private string _rvReviewCreativeId;

		private bool _isPremiumUser;

		private List<Dictionary<string, object>> _userPurchase;

		private bool _isRvSkipped;

		private readonly AdnAdsClick _adClick;

		private readonly AdnAdsCount _adClickCount;

		private readonly AdnAdsAmount _sessionRevenue;

		private readonly AdnAdsAmount _totalRevenue;

		private readonly AdnAdsAmount _lastCpm;

		private readonly IAnalyticStorage _analyticStorage;

		internal int LoadRequestCount { get; private set; }

		internal AdnAdsIndex AdLoadedIndex { get; }

		internal AdnImpressionIds AdImpressionIds { get; }

		internal List<Dictionary<string, object>> FirstSessionsAds()
		{
			return null;
		}

		internal List<Dictionary<string, object>> ActiveSessionAds()
		{
			return null;
		}

		internal List<Dictionary<string, object>> PreviousSessionAds()
		{
			return null;
		}

		internal List<Dictionary<string, object>> UserPurchases()
		{
			return null;
		}

		internal int InterstitialCountSinceInstall()
		{
			return 0;
		}

		internal int RewardedVideoCountSinceInstall()
		{
			return 0;
		}

		internal int InterstitialClickCountSinceInstall()
		{
			return 0;
		}

		internal int RewardedVideoClickCountSinceInstall()
		{
			return 0;
		}

		internal int IsPremiumUser()
		{
			return 0;
		}

		internal int HaSkippedRv()
		{
			return 0;
		}

		internal Dictionary<string, object> AdsClick()
		{
			return null;
		}

		internal Dictionary<string, object> AdsSessionRevenue()
		{
			return null;
		}

		internal Dictionary<string, object> AdsRevenueSinceInstall()
		{
			return null;
		}

		internal void UpdateAdImpressionInfo(ImpressionAnalyticsInfo info)
		{
		}

		internal void UpdateAdClickInfo(string placement, AdClickEventAnalyticsInfo info)
		{
		}

		internal void UpdateAdShownInfo(string placement, AdShownEventAnalyticsInfo info)
		{
		}

		internal void UpdateLoadRequestInfo(string placement, AdAnalyticsInfo info)
		{
		}

		internal void UpdateAdReviewInfo(string placement, AdReviewAnalyticsInfo info)
		{
		}

		internal void UpdateAdLoadedInfo(string placement, AdLoadedEventAnalyticsInfo info)
		{
		}

		internal void UpdateAdCloseInfo(string placement, AdClosedEventAnalyticsInfo info)
		{
		}

		private void UpdateActiveSessionAds(AdnAdData adData)
		{
		}

		private void SaveTotalAdsRevenue()
		{
		}

		private void SaveAdsClicks(string placement)
		{
		}

		private void UpdateFirstSessionAds(AdnAdData adData)
		{
		}

		private void UpdateUserPurchaseInfo()
		{
		}
	}
}
