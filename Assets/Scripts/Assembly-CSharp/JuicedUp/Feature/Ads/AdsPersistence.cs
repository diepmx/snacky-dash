using System;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Feature.Ads
{
	public class AdsPersistence
	{
		private readonly IDataRepository<AdsData> _repository;

		public AdsPersistence(IDataRepository<AdsData> repository)
		{
		}

		public long GetInstallTimestamp()
		{
			return 0L;
		}

		public void SetInstallTimestamp(long unixSeconds)
		{
		}

		public long GetLastInterstitialTimestamp()
		{
			return 0L;
		}

		public void SetLastInterstitialTimestamp(long unixSeconds)
		{
		}

		public long GetLastRewardedVideoTimestamp()
		{
			return 0L;
		}

		public void SetLastRewardedVideoTimestamp(long unixSeconds)
		{
		}

		public int GetRewardedLifeRefillsToday()
		{
			return 0;
		}

		public void IncrementRewardedLifeRefills()
		{
		}

		public static long ToUnixSeconds(DateTime utc)
		{
			return 0L;
		}
	}
}
