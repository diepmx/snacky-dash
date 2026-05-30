namespace MobileGameShop
{
	public interface ITimedBoostsService
	{
		bool IsActive(string boostKey, long utcNowSeconds);

		long GetEndUtc(string boostKey);

		void Activate(string boostKey, long endUtcSeconds);
	}
}
