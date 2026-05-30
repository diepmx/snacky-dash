using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;

namespace JuicedUp.Features.CloudContent
{
	public sealed class CloudFunnelManager : IFunnelLevelSource, ILevelDownloader
	{
		private readonly ICloudContentService _cloudContentService;

		private readonly ILevelDownloader _levelDownloader;

		private readonly RemoteConfigService _remoteConfigService;

		public CloudFunnelData FunnelData => default(CloudFunnelData);

		public CloudFunnelManager(ICloudContentService cloudContentService, ILevelDownloader levelDownloader, RemoteConfigService remoteConfigService)
		{
		}

		public string GetLevelPath(int contentIndex)
		{
			return null;
		}

		public UniTask<LevelDataSO> DownloadLevelAsync(string ccdPath, CancellationToken ct)
		{
			return default(UniTask<LevelDataSO>);
		}
	}
}
