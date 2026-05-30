using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class PaymentService : IPaymentService
	{
		private readonly IWallet _wallet;

		public PaymentService(IWallet wallet)
		{
		}

		public bool CanSpend(ICost[] costs)
		{
			return false;
		}

		public bool TrySpend(ICost[] costs)
		{
			return false;
		}
	}
}
