using System;

namespace JuicedUp.Common.Save
{
	[Serializable]
	public class AdsData
	{
		public long InstallTimestampUtc;

		public long LastInterstitialTimestamp;

		public long LastRewardedVideoTimestamp;

		public int RewardedLifeRefillCount;

		public string RewardedLifeRefillDate;
	}
}
