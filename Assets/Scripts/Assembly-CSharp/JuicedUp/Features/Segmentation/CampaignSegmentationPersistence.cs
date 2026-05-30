using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Segmentation
{
	public class CampaignSegmentationPersistence
	{
		private readonly IDataRepository<CampaignSegmentationData> _repository;

		public CampaignSegmentationPersistence(IDataRepository<CampaignSegmentationData> repository)
		{
		}

		public bool IsCaptured()
		{
			return false;
		}

		public string GetCampaignName()
		{
			return null;
		}

		public long GetInstallHour()
		{
			return 0L;
		}

		public bool IsPayer()
		{
			return false;
		}

		public void Save(string campaignName, long installHour, bool isCaptured)
		{
		}

		public void SaveInstallHour(long installHour)
		{
		}

		public void SavePayer(bool isPayer)
		{
		}

		public void Clear()
		{
		}

		public static long GetCurrentHour()
		{
			return 0L;
		}
	}
}
