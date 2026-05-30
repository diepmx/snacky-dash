using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	[Serializable]
	public class BundleConfig
	{
		public RewardConfig[] Rewards;

		public RarityType Rarity;
	}
}
