namespace Voodoo.Live.Sample.Offers
{
	public class VoodooLiveBridge : VoodooLiveBridgeBase
	{
		protected override bool HasItemQuantity(string itemId, int amount)
		{
			return false;
		}

		protected override bool ApplyItemDelta(string itemId, int delta)
		{
			return false;
		}
	}
}
