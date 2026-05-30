using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IHudValueSyncService
	{
		void SyncImmediately(IEnumerable<IReward> rewards);

		void SyncRewardWithHud(IReward reward);

		void SyncHudWithStorage(IRewardHudView rewardHudView);

		void SyncAllValues();
	}
}
