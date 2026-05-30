using System.Collections.Generic;

namespace JuicedUp.Common.Economy.Public.Data
{
	public interface IBundle
	{
		IEnumerable<IReward> Rewards { get; }

		RarityType Rarity { get; }
	}
}
