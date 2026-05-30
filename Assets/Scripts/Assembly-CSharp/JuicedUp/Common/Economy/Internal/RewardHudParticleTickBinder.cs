using System.Collections.Generic;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Internal
{
	internal sealed class RewardHudParticleTickBinder : IRewardHudParticleTickBinder
	{
		private readonly IReadOnlyList<IRewardHudParticleTickHandler> _handlers;

		public RewardHudParticleTickBinder(IEnumerable<IRewardHudParticleTickHandler> handlers)
		{
		}

		public void OnSingleParticleArrivedWithDelta(IReward reward, int delta)
		{
		}

		public void OnRewardArrived(IReward reward)
		{
		}
	}
}
