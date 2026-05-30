using Voodoo.Sauce.Internal.Ads;

namespace Voodoo.Sauce.Internal.Analytics
{
	public class AdLoadedEventAnalyticsInfo : ImpressionAnalyticsInfo
	{
		public int GameCount;

		public double? InterstitialCpm;

		public double? RewardedVideoCpm;

		public AdLoadedEventAnalyticsInfo(VoodooAdInfo adInfo)
		{
		}
	}
}
