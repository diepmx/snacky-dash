using System.Collections.Generic;

namespace Voodoo.Live
{
	public sealed class RewardDTO
	{
		public string type;

		public string hashId;

		public ItemQuantityDTO[] items;

		public RewardWeightDTO[] rewardsWeights;

		public List<string> tags;

		public bool IsValid => false;

		private bool IsValidStandard()
		{
			return false;
		}

		private bool IsValidRandom()
		{
			return false;
		}
	}
}
