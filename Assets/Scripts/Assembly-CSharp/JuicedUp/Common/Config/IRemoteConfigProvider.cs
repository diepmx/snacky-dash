namespace JuicedUp.Common.Config
{
	public interface IRemoteConfigProvider
	{
		T Get<T>() where T : class, new();
	}
}
