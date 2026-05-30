using System;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Sauce.Internal.Analytics;

namespace JuicedUp.Common.Economy.Public.Extensions
{
	public static class RewardExtensions
	{
		private const string BoostersAmountPrefix = "x";

		public static string GetAnalyticName(this IReward reward)
		{
			return null;
		}

		public static ItemType GetAnalyticItemType(this IReward reward)
		{
			return default(ItemType);
		}

		public static Enum GetAnalyticsRewardId(this IReward reward)
		{
			return null;
		}

		public static string GetFormatedStringAmount(this IReward reward)
		{
			return null;
		}

		private static string FormatEntitlementDurationFromSeconds(int totalSeconds)
		{
			return null;
		}
	}
}
