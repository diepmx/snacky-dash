using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	public interface IRewardParticlesPolicy
	{
		int GetParticlesCount(IReward reward);
	}
}
