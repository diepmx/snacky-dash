using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Public.Providers
{
	public interface IActiveRewardHudViewProvider
	{
		IRewardHudView GetLastActivatedRewardHudView(EntitlementId entitlementId);

		IRewardHudView GetLastActivatedRewardHudView(CurrencyId currencyId);

		IRewardHudView GetLastActivatedRewardHudView(BoosterId boosterId);
	}
}
