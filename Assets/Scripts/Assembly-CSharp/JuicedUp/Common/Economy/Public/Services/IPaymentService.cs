using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public.Services
{
	public interface IPaymentService
	{
		bool CanSpend(ICost[] costs);

		bool TrySpend(ICost[] costs);
	}
}
