using System;

namespace JuicedUp.Common.Notifiers
{
	public interface IRequestListener<T>
	{
		event Action<T> Requested;
	}
}
