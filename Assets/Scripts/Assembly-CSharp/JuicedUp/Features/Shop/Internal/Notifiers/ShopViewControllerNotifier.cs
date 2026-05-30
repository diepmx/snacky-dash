using System;
using System.Runtime.CompilerServices;

namespace JuicedUp.Features.Shop.Internal.Notifiers
{
	public class ShopViewControllerNotifier : IShopViewControllerNotifier
	{
		public event Action ShopActivated
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

		public event Action ShopDeactivated
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

		public void NotifyShopActivated()
		{
		}

		public void NotifyShopDeactivated()
		{
		}
	}
}
