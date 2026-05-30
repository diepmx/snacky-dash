using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	public interface IRewardHudParticleTickHandler
	{
		bool CanHandle(IReward reward);

		void OnParticleTick(IReward reward, int delta);

		void OnRewardFlyCompleted(IReward reward);
	}
}
