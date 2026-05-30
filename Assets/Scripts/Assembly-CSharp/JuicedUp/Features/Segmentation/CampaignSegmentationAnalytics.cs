using System.Collections.Generic;

namespace JuicedUp.Features.Segmentation
{
	public static class CampaignSegmentationAnalytics
	{
		private const string CampaignProperty = "campaign";

		private const string SegmentProperty = "segment";

		private static readonly HashSet<string> ReportedUnknownCampaigns;

		public static void TrackCampaignCaptured(string campaign, SegmentType segment)
		{
		}

		public static void TrackFsAdDecision(SegmentType segment, string campaign, bool shown, bool isGracePeriod, bool isPastMinLevel)
		{
		}

		public static void TrackUnknownCampaign(string campaign, string reason)
		{
		}
	}
}
