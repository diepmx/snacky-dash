using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class HudIconSyncService : IHudIconSyncService
	{
		private readonly IEconomySpritesProvider _spritesProvider;

		private readonly IActiveRewardHudViewProvider _hudViewProvider;

		public HudIconSyncService(IEconomySpritesProvider spritesProvider, IActiveRewardHudViewProvider hudViewProvider)
		{
		}

		public void SyncAllActiveHuds()
		{
		}

		public void SyncRewardHud(IRewardHudView rewardHudView)
		{
		}
	}
}
