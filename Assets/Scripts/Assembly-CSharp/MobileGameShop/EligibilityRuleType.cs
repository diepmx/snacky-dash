namespace MobileGameShop
{
	public enum EligibilityRuleType
	{
		Always = 0,
		HideIfEntitlementTrue = 1,
		HideIfOfferPurchased = 2,
		ShowOnlyIfOfferNotPurchased = 3,
		ShowOnlyIfWithinUtcWindow = 4,
		ShowOnlyIfPlayerLevelAtLeast = 5
	}
}
