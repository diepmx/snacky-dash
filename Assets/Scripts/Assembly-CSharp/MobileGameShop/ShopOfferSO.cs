using System.Collections.Generic;
using UnityEngine;

namespace MobileGameShop
{
	[CreateAssetMenu(menuName = "MobileGameShop/Shop Offer", fileName = "ShopOffer")]
	public class ShopOfferSO : ScriptableObject
	{
		[Header("Identity")]
		public string offerId;

		[Header("Visual")]
		public OfferVisual visual;

		[Header("Purchase")]
		public OfferPurchase purchase;

		[Header("Rewards")]
		public List<Grant> grants;

		[Header("Eligibility")]
		public List<EligibilityRule> eligibility;

		public bool IsEligible(IShopContext ctx)
		{
			return false;
		}
	}
}
