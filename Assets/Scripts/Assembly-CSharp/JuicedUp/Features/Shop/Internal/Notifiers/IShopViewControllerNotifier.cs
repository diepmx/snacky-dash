using System;

namespace JuicedUp.Features.Shop.Internal.Notifiers
{
	public interface IShopViewControllerNotifier
	{
		event Action ShopActivated;

		event Action ShopDeactivated;

		void NotifyShopActivated();

		void NotifyShopDeactivated();
	}
}
