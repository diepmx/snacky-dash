using System.Collections.Generic;

public class WatchAppHarbrAds
{
	public List<WatchAppHarbrBannerAd> BannerAdUnitIds { get; }

	public List<WatchAppHarbrBannerAd> MRecAdUnitIds { get; }

	public List<string> InterstitialAdUnitIds { get; }

	public List<string> RewardedAdUnitIds { get; }

	public List<string> RewardedInterstitialAdUnitIds { get; }

	public WatchAppHarbrAds(List<WatchAppHarbrBannerAd> bannerAdUnitIds = null, List<WatchAppHarbrBannerAd> mRecAdUnitIds = null, List<string> interstitialAdUnitIds = null, List<string> rewardedAdUnitIds = null, List<string> rewardedInterstitialAdUnitIds = null)
	{
	}
}
