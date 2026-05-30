using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[CreateAssetMenu(fileName = "EconomySprites", menuName = "Economy/Sprites", order = 0)]
	internal class EconomySprites : ScriptableObject
	{
		[field: SerializeField]
		public CurrencyEconomySprite[] CurrencyEconomySprites { get; private set; }

		[field: SerializeField]
		public BoosterEconomySprite[] BoosterEconomySprites { get; private set; }

		[field: SerializeField]
		public EntitlementEconomySprite[] EntitlementEconomySprites { get; private set; }
	}
}
