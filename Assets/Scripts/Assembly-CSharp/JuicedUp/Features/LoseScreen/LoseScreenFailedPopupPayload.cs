using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Features.LoseScreen
{
	public class LoseScreenFailedPopupPayload : IPopupPayload
	{
		public LoseFlowAnalyticsContext AnalyticsContext { get; }

		public LoseScreenFailedPopupPayload(LoseFlowAnalyticsContext analyticsContext)
		{
		}
	}
}
