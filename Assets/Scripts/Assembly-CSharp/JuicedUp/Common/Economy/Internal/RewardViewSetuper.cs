using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public;

namespace JuicedUp.Common.Economy.Internal
{
	internal class RewardViewSetuper : IRewardViewSetuper
	{
		private readonly IRewardSpriteTypeProvider _rewardSpriteTypeProvider;

		private readonly IEconomySpritesProvider _spritesProvider;

		public RewardViewSetuper(IRewardSpriteTypeProvider rewardSpriteTypeProvider, IEconomySpritesProvider spritesProvider)
		{
		}

		public void Setup(IRewardView rewardView, IReward reward, bool withText = true)
		{
		}
	}
}
