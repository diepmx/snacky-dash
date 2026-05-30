using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Shop.Internal.Controllers;

namespace JuicedUp.Features.Core.Lives
{
	public class RefillLivesPopupPayload : IPopupPayload
	{
		public readonly IEconomyService EconomyService;

		public readonly IShopViewController ShopViewController;

		public RefillLivesPopupPayload(IEconomyService economyService, IShopViewController shopViewController)
		{
		}
	}
}
