using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Providers
{
	public interface IRewardSpriteTypeProvider
	{
		SpriteType GetSpriteType(IReward reward);
	}
}
