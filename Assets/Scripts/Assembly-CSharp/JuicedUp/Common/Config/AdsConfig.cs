using System;

namespace JuicedUp.Common.Config
{
	[Serializable]
	public class AdsConfig
	{
		public int MinimumLevelForInterstitial;

		public int InterstitialFrequencySeconds;

		public int RewardedToInterstitialFrequencySeconds;

		public int RewardedVideoRewardMultiplier;

		public int MaxRewardedLifeRefillsPerDay;

		public bool RewardedLifeRefillEnabled;

		public int RefillAllLivesCost;
	}
}
