using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Internal
{
	internal sealed class RewardParticlesPolicy : IRewardParticlesPolicy
	{
		public int GetParticlesCount(IReward reward)
		{
			return 0;
		}
	}
}
