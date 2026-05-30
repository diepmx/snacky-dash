namespace JuicedUp.Features.Segmentation
{
	public interface ICampaignAttributionService
	{
		string Campaign { get; }

		bool IsCaptured { get; }

		bool IsPayer { get; }

		int GetHoursSinceInstall();

		void SetUserAsPayer(bool isPayer);
	}
}
