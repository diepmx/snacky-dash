using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using JuicedUp.Common.Notifiers.AppLifeCycle;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Features.Core
{
	[UsedImplicitly]
	public class StuckDetectionAppCloseHandler : IAsyncInitializable, IDisposable
	{
		private readonly IAppLifeCycleNotifier _appLifeCycleNotifier;

		private readonly StuckDetectionTracker _stuckDetectionTracker;

		private readonly ICoreGameAnalyticsService _analyticsService;

		public StuckDetectionAppCloseHandler(IAppLifeCycleNotifier appLifeCycleNotifier, StuckDetectionTracker stuckDetectionTracker, ICoreGameAnalyticsService analyticsService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnApplicationPauseChanged(bool isPaused)
		{
		}
	}
}
