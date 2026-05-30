using System;
using UnityEngine;

namespace MobileGameShop
{
	[Serializable]
	public class Grant
	{
		public GrantType type;

		[Header("Coins")]
		public int coinsAmount;

		[Header("Item")]
		public string itemId;

		public int itemAmount;

		[Header("Entitlement")]
		public string entitlementKey;

		public bool entitlementValue;

		[Header("Timed boost")]
		public string boostKey;

		public int boostDurationSeconds;
	}
}
