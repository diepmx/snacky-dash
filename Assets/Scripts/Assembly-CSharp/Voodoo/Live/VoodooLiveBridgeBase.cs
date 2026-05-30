using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public abstract class VoodooLiveBridgeBase : IVoodooLiveBridge
	{
		protected IInventory Inventory { get; private set; }

		public virtual void PurchaseIAP(string productId, Dictionary<string, object> eventContextProperties)
		{
		}

		public virtual bool RewardingMethod(Transaction transaction)
		{
			return false;
		}

		protected virtual bool GrantReward(ItemQuantity itemQuantity)
		{
			return false;
		}

		protected abstract bool HasItemQuantity(string itemId, int amount);

		protected abstract bool ApplyItemDelta(string itemId, int delta);

		public virtual bool ValidateFeature(IFeature feature)
		{
			return false;
		}

		public void ConfigureInventory(IInventory inventory)
		{
		}
	}
}
