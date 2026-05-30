namespace JuicedUp.Features.Core
{
	public class LevelRunStats : ILevelRunStats
	{
		public int PendingCoins { get; set; }

		public int GrantedCoinsPendingPresentation { get; set; }

		public void Reset()
		{
		}
	}
}
