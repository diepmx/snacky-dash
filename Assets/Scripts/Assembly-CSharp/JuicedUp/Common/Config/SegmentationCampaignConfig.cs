using System;
using System.Collections.Generic;
using JuicedUp.Features.Segmentation;

namespace JuicedUp.Common.Config
{
	[Serializable]
	public class SegmentationCampaignConfig
	{
		private const string OrganicCampaign = "organic";

		private const string MatchReasonOrganic = "organic";

		private const string MatchReasonExactMatch = "exact_match";

		private const string MatchReasonKey = "key";

		private const string MatchReasonNoMatch = "no_match";

		public bool IsActive;

		public string CampaignKeysJson;

		public string CampaignMappingsJson;

		public bool IsAdForIAPForced;

		public int OrganicSegment;

		public bool IsVerboseLoggingEnabled;

		public int IaaFsStartLevel;

		public int IapFsStartLevel;

		public int BlendedStartLevel;

		public int IaaGracePeriodHours;

		public int IapGracePeriodHours;

		public int BlendedGracePeriodHours;

		public Dictionary<string, SegmentType> CampaignMappings { get; private set; }

		public CampaignKeysMappingData CampaignKeysData { get; private set; }

		public void EnsureParsed()
		{
		}

		public SegmentType GetSegment(string campaign)
		{
			return default(SegmentType);
		}

		public SegmentType GetSegment(string campaign, out string matchReason)
		{
			matchReason = null;
			return default(SegmentType);
		}

		public static void ParseCampaignKeys(SegmentationCampaignConfig config)
		{
		}

		public static void ParseCampaignMappings(SegmentationCampaignConfig config)
		{
		}
	}
}
