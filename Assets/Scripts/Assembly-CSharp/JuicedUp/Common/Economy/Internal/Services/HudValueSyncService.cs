using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class HudValueSyncService : IHudValueSyncService
	{
		private readonly IActiveRewardHudViewProvider _activeRewardHudViewProvider;

		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IBoosterStorage _boosterStorage;

		private readonly IWallet _wallet;

		public HudValueSyncService(IActiveRewardHudViewProvider activeRewardHudViewProvider, IEntitlementStorage entitlementStorage, IBoosterStorage boosterStorage, IWallet wallet)
		{
		}

		public void SyncImmediately(IEnumerable<IReward> rewards)
		{
		}

		public void SyncHudWithStorage(IRewardHudView rewardHudView)
		{
		}

		public void SyncRewardWithHud(IReward reward)
		{
		}

		public void SyncAllValues()
		{
		}

		private void SyncHud(int value, IRewardHudView rewardHudView)
		{
		}
	}
}
