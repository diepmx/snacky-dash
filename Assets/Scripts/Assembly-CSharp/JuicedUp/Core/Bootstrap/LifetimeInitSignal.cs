using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class LifetimeInitSignal
	{
		private readonly object _gate;

		private readonly HashSet<Type> _completedInit;

		private readonly Dictionary<Type, UniTaskCompletionSource> _waiting;

		public UniTask WaitAsync<TLifetimeScope>(CancellationToken cancellationToken) where TLifetimeScope : LifetimeScope
		{
			return default(UniTask);
		}

		public void Reset<TLifetimeScope>() where TLifetimeScope : LifetimeScope
		{
		}

		public UniTask WaitAsync(Type lifetimeScopeType, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Complete(LifetimeScope lifetimeScope)
		{
		}

		private void Complete(Type lifetimeScopeType)
		{
		}

		private void Reset(Type lifetimeScopeType)
		{
		}

		private static void ValidateLifetimeScopeType(Type lifetimeScopeType)
		{
		}
	}
}
