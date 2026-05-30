using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Features.Segmentation
{
	public class CampaignSegmentationService : IAsyncInitializable
	{
		private readonly ICampaignAttributionService _attributionService;

		private readonly RemoteConfigService _remoteConfig;

		private SegmentationCampaignConfig _config;

		public static CampaignSegmentationService Instance { get; private set; }

		private SegmentationCampaignConfig Config => null;

		public CampaignSegmentationService(ICampaignAttributionService attributionService, RemoteConfigService remoteConfig)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnRemoteConfigReady()
		{
		}

		private SegmentType GetUserSegment()
		{
			return default(SegmentType);
		}

		public bool ShouldShowRewardedVideo()
		{
			return false;
		}

		public bool ShouldShowFullScreenAd()
		{
			return false;
		}

		private static bool ComputeShouldShowFs(SegmentType segment, SegmentationCampaignConfig config, int hoursSinceInstall, int currentLevel, out bool isWithinGracePeriod, out bool isAfterFsStartLevel)
		{
			isWithinGracePeriod = default(bool);
			isAfterFsStartLevel = default(bool);
			return false;
		}

		private static int FsStartLevelForSegment(SegmentType segment, SegmentationCampaignConfig config)
		{
			return 0;
		}

		private static int GracePeriodForSegment(SegmentType segment, SegmentationCampaignConfig config)
		{
			return 0;
		}

		public void DebugResetSegment()
		{
		}

		public string GetDebugFeatureActive()
		{
			return null;
		}

		public string GetDebugCampaign()
		{
			return null;
		}

		public string GetDebugCaptured()
		{
			return null;
		}

		public string GetDebugSegment()
		{
			return null;
		}

		public string GetDebugHoursSinceInstall()
		{
			return null;
		}

		public string GetDebugGracePeriodFS()
		{
			return null;
		}

		public string GetDebugGracePeriodRV()
		{
			return null;
		}

		public string GetDebugInGracePeriodFS()
		{
			return null;
		}

		public string GetDebugInGracePeriodRV()
		{
			return null;
		}

		public string GetDebugShouldShowFS()
		{
			return null;
		}

		public string GetDebugOrganicSegment()
		{
			return null;
		}

		public string GetDebugForceAdsForIAP()
		{
			return null;
		}

		public string GetDebugCampaignMappings()
		{
			return null;
		}

		public string GetDebugCampaignKeys()
		{
			return null;
		}
	}
}
