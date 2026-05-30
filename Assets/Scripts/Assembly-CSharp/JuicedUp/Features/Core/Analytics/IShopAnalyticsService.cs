namespace JuicedUp.Features.Core.Analytics
{
	public interface IShopAnalyticsService
	{
		void TrackShopClick(ShopPayload payload);

		void TrackShopOpened(ShopPayload payload);

		void TrackShopClosed(ShopPayload payload);

		void TrackShopInitFailed(ShopPayload payload);

		void TrackShopOpenFailed(ShopPayload payload);

		void TrackShopLoseConnection(ShopPayload payload);
	}
}
