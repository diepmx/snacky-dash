using System;
using UnityEngine;

namespace MobileGameShop
{
	[Serializable]
	public class OfferPurchase
	{
		public PurchaseType type;

		[Tooltip("Use the same ID across stores when possible.")]
		public string productId;

		[Tooltip("For IAP_Product: Consumable for coins, Non-consumable for Remove Ads, etc.")]
		public bool isConsumable;
	}
}
