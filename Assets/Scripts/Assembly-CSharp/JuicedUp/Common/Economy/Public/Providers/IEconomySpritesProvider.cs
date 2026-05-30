using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Providers
{
	public interface IEconomySpritesProvider
	{
		Sprite GetSprite(IReward reward, SpriteType type);

		Sprite GetCurrencySprite(CurrencyId currencyId, SpriteType type);

		Sprite GetBoosterSprite(BoosterId boosterId, SpriteType type);

		Sprite GetEntitlementSprite(EntitlementId entitlementId, SpriteType type);
	}
}
