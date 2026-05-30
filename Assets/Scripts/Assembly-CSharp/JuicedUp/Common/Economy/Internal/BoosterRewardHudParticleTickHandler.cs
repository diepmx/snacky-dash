using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;

namespace JuicedUp.Common.Economy.Internal
{
	internal sealed class BoosterRewardHudParticleTickHandler : IRewardHudParticleTickHandler
	{
		private readonly IActiveRewardHudViewProvider _hudViewProvider;

		public BoosterRewardHudParticleTickHandler(IActiveRewardHudViewProvider hudViewProvider)
		{
		}

		public bool CanHandle(IReward reward)
		{
			return false;
		}

		public void OnParticleTick(IReward reward, int delta)
		{
		}

		public void OnRewardFlyCompleted(IReward reward)
		{
		}
	}
}
