namespace JuicedUp.Common.Economy.Public.Data
{
	public class Cost : ICost
	{
		public CurrencyId Id { get; }

		public int Amount { get; }

		public Cost(CurrencyId id, int amount)
		{
		}
	}
}
