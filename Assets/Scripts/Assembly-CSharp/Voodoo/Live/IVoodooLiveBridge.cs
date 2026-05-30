using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public interface IVoodooLiveBridge
	{
		void PurchaseIAP(string productId, Dictionary<string, object> eventContextProperties);

		bool RewardingMethod(Transaction transaction);

		bool ValidateFeature(IFeature feature);

		void ConfigureInventory(IInventory inventory);
	}
}
