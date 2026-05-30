namespace JuicedUp.Features.Core.Analytics
{
	public interface IOffersAnalyticsService
	{
		void TrackOfferClick(OfferPayload payload);

		void TrackOfferShown(OfferPayload payload);
	}
}
