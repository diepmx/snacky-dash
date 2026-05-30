using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IHudIconSyncService
	{
		void SyncAllActiveHuds();

		void SyncRewardHud(IRewardHudView rewardHudView);
	}
}
