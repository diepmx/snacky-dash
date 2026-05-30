using JuicedUp.Common.Economy.Internal.Components;

namespace JuicedUp.Common.Economy.Internal.Pools
{
	internal interface IRewardFlyParticlePool
	{
		RewardFlyParticle Rent();

		void Return(RewardFlyParticle particle);
	}
}
