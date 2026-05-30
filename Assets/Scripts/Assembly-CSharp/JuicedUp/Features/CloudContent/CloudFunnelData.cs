namespace JuicedUp.Features.CloudContent
{
	public readonly struct CloudFunnelData
	{
		public readonly SerializedCohortManifest Manifest;

		public readonly bool IsLoop;

		public readonly int LoopStartIndex;

		public bool IsValid => false;

		public CloudFunnelData(SerializedCohortManifest manifest)
		{
			Manifest = null;
			IsLoop = false;
			LoopStartIndex = 0;
		}
	}
}
