using System;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Features.Shop.Internal.Controllers
{
	public interface IShopViewController
	{
		void Activate(ShopSource source, bool enableCloseButton = false, Action<IProduct> onClose = null, Action onPurchaseClaimed = null);

		void Deactivate();
	}
}
