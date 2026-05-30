namespace Voodoo.Live.Offers
{
	public enum FeatureStatus
	{
		InvalidData = 0,
		Idle = 1,
		TryTrigger = 2,
		Triggered = 3,
		InQueue = 4,
		Shown = 5,
		PurchaseStarted = 6,
		PurchaseRewarded = 7,
		PurchaseFailed = 8,
		Closed = 9
	}
}
