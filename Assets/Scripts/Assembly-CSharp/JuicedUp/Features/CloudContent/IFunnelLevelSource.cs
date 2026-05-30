namespace JuicedUp.Features.CloudContent
{
	public interface IFunnelLevelSource : ILevelDownloader
	{
		CloudFunnelData FunnelData { get; }

		string GetLevelPath(int contentIndex);
	}
}
