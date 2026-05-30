namespace JuicedUp.Common.Config
{
	public class VoodooSauceRemoteConfigProvider : IRemoteConfigProvider
	{
		public T Get<T>() where T : class, new()
		{
			return null;
		}
	}
}
