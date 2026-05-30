namespace JuicedUp.Features.Core.Analytics
{
	public struct ShopPayload
	{
		public ShopSource ShopSource { get; }

		public AnalyticsScene Scene { get; }

		public ShopPayload(ShopSource shopSource, AnalyticsScene scene)
		{
			ShopSource = default(ShopSource);
			Scene = default(AnalyticsScene);
		}
	}
}
