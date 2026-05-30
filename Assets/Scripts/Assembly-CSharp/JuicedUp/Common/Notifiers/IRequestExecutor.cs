namespace JuicedUp.Common.Notifiers
{
	public interface IRequestExecutor<T>
	{
		void Request(T payload);
	}
}
