using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Extensions
{
	public static class RewardsExtensions
	{
		private static readonly Dictionary<(RewardType, int), int> RewardPriorityMap;

		public static IEnumerable<IReward> OfType(this IEnumerable<IReward> rewards, RewardType type)
		{
			return null;
		}

		public static List<IReward> Combine(this IEnumerable<IReward> rewards)
		{
			return null;
		}

		public static List<IReward> SortByPriority(this IEnumerable<IReward> rewards)
		{
			return null;
		}

		private static int GetPriority(IReward reward)
		{
			return 0;
		}

		private static int CombineEntitlementAmounts(IEnumerable<IReward> group)
		{
			return 0;
		}
	}
}
