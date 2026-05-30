using System.Collections.Generic;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Storages;

namespace JuicedUp.Common.Economy.Internal
{
	internal sealed class CurrencyRewardHudParticleTickHandler : IRewardHudParticleTickHandler
	{
		private readonly IActiveRewardHudViewProvider _hudViewProvider;

		private readonly IWallet _wallet;

		private readonly Dictionary<CurrencyId, int> _displayValues;

		public CurrencyRewardHudParticleTickHandler(IActiveRewardHudViewProvider hudViewProvider, IWallet wallet)
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
