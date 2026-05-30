using System;
using System.Runtime.CompilerServices;

namespace JuicedUp.Common.Notifiers
{
	public class Notifier<T> : IRequestListener<T>, IRequestExecutor<T>
	{
		public event Action<T> Requested
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Request(T payload)
		{
		}
	}
}
