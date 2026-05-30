namespace MobileGameShop
{
	public class PlayerPrefsTimedBoostsService : ITimedBoostsService
	{
		private const string Prefix = "MGS_BOOST_END_";

		public bool IsActive(string boostKey, long utcNowSeconds)
		{
			return false;
		}

		public long GetEndUtc(string boostKey)
		{
			return 0L;
		}

		public void Activate(string boostKey, long endUtcSeconds)
		{
		}
	}
}
