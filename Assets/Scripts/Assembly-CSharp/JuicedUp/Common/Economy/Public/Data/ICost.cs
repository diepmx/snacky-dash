namespace JuicedUp.Common.Economy.Public.Data
{
	public interface ICost
	{
		CurrencyId Id { get; }

		int Amount { get; }
	}
}
