using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Providers
{
	public interface ICurrencyLimitsProvider
	{
		int GetMaxAmount(CurrencyId currencyId);
	}
}
