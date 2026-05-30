using System.Threading;

namespace JuicedUp.Features.Core.Home
{
	public interface IHomePanel
	{
		void OnPlayButtonClicked();

		void PresentPendingCoins(CancellationToken cancellationToken);

		void ShowHomeAndOfferRefill();
	}
}
