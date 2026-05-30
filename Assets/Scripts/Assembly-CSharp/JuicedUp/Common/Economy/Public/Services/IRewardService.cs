using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IRewardService
	{
		void Grant(IEnumerable<IReward> rewards);

		void Grant(IReward reward);
	}
}
