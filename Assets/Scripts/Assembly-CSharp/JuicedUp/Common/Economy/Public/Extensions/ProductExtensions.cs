using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Extensions
{
	public static class ProductExtensions
	{
		public static string GetTagValue(this IProduct product, string tagKey)
		{
			return null;
		}

		public static SpriteType GetSpriteTypeTagValue(this IProduct product, string spriteTagKey)
		{
			return default(SpriteType);
		}

		public static Color GetColorTagValue(this IProduct product, string colorTagKey)
		{
			return default(Color);
		}

		public static bool IsNoAdsProduct(this IProduct product)
		{
			return false;
		}

		public static bool IsNoAdsPack(this IProduct product)
		{
			return false;
		}

		public static bool IsStarterPack(this IProduct product)
		{
			return false;
		}

		public static List<List<IReward>> BuildRewardsByPriority(this IProduct product)
		{
			return null;
		}

		public static string GetProductFallbackBundleName(this IProduct product)
		{
			return null;
		}

		private static bool IsMatchingReward(IReward reward, IReward priorityReward)
		{
			return false;
		}
	}
}
