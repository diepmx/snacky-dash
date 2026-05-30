using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	[Serializable]
	public class RewardConfig : IReward
	{
		public RewardType Type { get; set; }

		public int ItemId { get; set; }

		public int Amount { get; set; }

		public bool ReplaceInsteadOfAdd { get; set; }
	}
}
