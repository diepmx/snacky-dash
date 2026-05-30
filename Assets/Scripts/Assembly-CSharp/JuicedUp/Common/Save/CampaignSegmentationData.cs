using System;

namespace JuicedUp.Common.Save
{
	[Serializable]
	public class CampaignSegmentationData
	{
		public string CampaignName;

		public long InstallHour;

		public bool Captured;

		public bool IsUserPayer;
	}
}
