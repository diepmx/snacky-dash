using System;
using UnityEngine;

namespace MobileGameShop
{
	[Serializable]
	public class EligibilityRule
	{
		public EligibilityRuleType type;

		[Header("Key / OfferId")]
		public string keyOrOfferId;

		[Header("Value")]
		public int intValue;

		[Header("UTC Window (seconds since epoch)")]
		public long startUtc;

		public long endUtc;

		public bool Evaluate(IShopContext ctx, string thisOfferId)
		{
			return false;
		}
	}
}
