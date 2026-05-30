using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Scripts.Public
{
	public interface IRewardViewSetuper
	{
		void Setup(IRewardView rewardView, IReward reward, bool withText = true);
	}
}
