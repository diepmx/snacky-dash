namespace MobileGameShop
{
	public interface ITimeProvider
	{
		long UtcNowSeconds { get; }
	}
}
