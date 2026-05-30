using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;

namespace JuicedUp.Common.Economy.Internal.Providers
{
	internal sealed class CurrencyLimitsProvider : ICurrencyLimitsProvider
	{
		private const int DefaultMax = 2147483647;

		private const int LivesMax = 5;

		public int GetMaxAmount(CurrencyId currencyId)
		{
			return 0;
		}
	}
}
