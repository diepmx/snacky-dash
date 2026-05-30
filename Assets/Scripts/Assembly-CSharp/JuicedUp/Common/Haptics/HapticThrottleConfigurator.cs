using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Common.Haptics
{
	public class HapticThrottleConfigurator : IAsyncInitializable, IDisposable
	{
		private readonly RemoteConfigService _remoteConfigService;

		public HapticThrottleConfigurator(RemoteConfigService remoteConfigService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void Apply()
		{
		}
	}
}
