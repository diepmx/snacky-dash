using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Notifiers.AppLifeCycle;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Common.SaveAndLoad
{
	public class FlushRepositoriesHandler : IAsyncInitializable, IDisposable
	{
		private readonly IReadOnlyList<IFlushDataRepository> _flushDataRepositories;

		private readonly IAppLifeCycleNotifier _appLifeCycle;

		public FlushRepositoriesHandler(IReadOnlyList<IFlushDataRepository> flushDataRepositories, IAppLifeCycleNotifier appLifeCycle)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnPause(bool paused)
		{
		}

		private void OnFocus(bool focused)
		{
		}

		private void OnQuit()
		{
		}

		private void FlushAllRepositories()
		{
		}
	}
}
