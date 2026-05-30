using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Shop.Scripts.Public
{
	public class ProductPurchaseGlobalNotifier : IProductPurchaseGlobalNotifier
	{
		public event Action<IProduct> OnProductPurchased
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void InvokeOnProductPurchased(IProduct products)
		{
		}
	}
}
