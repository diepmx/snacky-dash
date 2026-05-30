using System;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public readonly struct InitItem
	{
		public Type ImplementationType { get; }

		public InitItem(Type implementationType)
		{
			ImplementationType = null;
		}
	}
}
