using JuicedUp.Common.Economy.Internal.Views;

namespace JuicedUp.Common.Economy.Internal.Pools
{
	internal interface IRewardViewPool
	{
		RewardView Rent();

		void Return(RewardView rewardView);
	}
}
