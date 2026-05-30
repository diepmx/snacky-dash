using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class RewardService : IRewardService
	{
		private readonly ICurrencyLimitsProvider _currencyLimitsProvider;

		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IBoosterStorage _boosterStorage;

		private readonly IWallet _wallet;

		public RewardService(IWallet wallet, IBoosterStorage boosterStorage, IEntitlementStorage entitlementStorage, ICurrencyLimitsProvider currencyLimitsProvider)
		{
		}

		public void Grant(IEnumerable<IReward> rewards)
		{
		}

		public void Grant(IReward reward)
		{
		}

		private void GrantCurrency(IReward reward)
		{
		}

		private void GrantEntitlement(IReward reward)
		{
		}

		private void GrantBooster(IReward reward)
		{
		}
	}
}
