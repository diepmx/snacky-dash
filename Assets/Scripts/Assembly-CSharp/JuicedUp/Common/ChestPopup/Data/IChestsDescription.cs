using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.ChestPopup.Data
{
	public interface IChestsDescription
	{
		ChestDescription GetDescriptionByRarityType(RarityType rarity);
	}
}
