using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Shop.Scripts.Public
{
	public interface IProductPurchaseGlobalNotifier
	{
		event Action<IProduct> OnProductPurchased;

		void InvokeOnProductPurchased(IProduct products);
	}
}
