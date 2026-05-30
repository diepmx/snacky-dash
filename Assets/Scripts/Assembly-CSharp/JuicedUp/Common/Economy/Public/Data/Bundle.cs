using System.Collections.Generic;

namespace JuicedUp.Common.Economy.Public.Data
{
	public class Bundle : IBundle
	{
		public IEnumerable<IReward> Rewards { get; }

		public RarityType Rarity { get; }

		public Bundle(IEnumerable<IReward> rewards, RarityType rarity = RarityType.Normal)
		{
		}
	}
}
