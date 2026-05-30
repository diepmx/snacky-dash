namespace JuicedUp.Features.Core
{
	public interface ILevelRunStats
	{
		int PendingCoins { get; set; }

		int GrantedCoinsPendingPresentation { get; set; }

		void Reset();
	}
}
