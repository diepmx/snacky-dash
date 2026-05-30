using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	public interface IRewardHudParticleTickBinder
	{
		void OnSingleParticleArrivedWithDelta(IReward reward, int delta);

		void OnRewardArrived(IReward reward);
	}
}
