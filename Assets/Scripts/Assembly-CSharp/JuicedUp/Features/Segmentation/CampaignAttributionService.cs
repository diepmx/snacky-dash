using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicedUp.Features.Segmentation
{
	public class CampaignAttributionService : IAsyncInitializable, ICampaignAttributionService
	{
		private const string OrganicInstall = "organic";

		private readonly CampaignSegmentationPersistence _persistence;

		private readonly RemoteConfigService _remoteConfig;

		private long _installHour;

		public string Campaign { get; private set; }

		public bool IsCaptured { get; private set; }

		public bool IsPayer { get; private set; }

		public CampaignAttributionService(CampaignSegmentationPersistence persistence, RemoteConfigService remoteConfig)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public int GetHoursSinceInstall()
		{
			return 0;
		}

		public void DebugOverride(string campaignName, long installHour)
		{
		}

		public void SetUserAsPayer(bool isPayer)
		{
		}

		public void DebugClear()
		{
		}

		private void OnAttributionChanged(AttributionAnalyticsInfo info)
		{
		}
	}
}
