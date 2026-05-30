using JuicedUp.Common.Economy.Internal.Data;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Providers
{
	internal class EconomySpritesProvider : IEconomySpritesProvider
	{
		private readonly EconomySprites _economySprites;

		public EconomySpritesProvider(EconomySprites economySprites)
		{
		}

		public Sprite GetSprite(IReward reward, SpriteType type)
		{
			return null;
		}

		public Sprite GetCurrencySprite(CurrencyId currencyId, SpriteType type)
		{
			return null;
		}

		public Sprite GetBoosterSprite(BoosterId boosterId, SpriteType type)
		{
			return null;
		}

		public Sprite GetEntitlementSprite(EntitlementId entitlementId, SpriteType type)
		{
			return null;
		}
	}
}
