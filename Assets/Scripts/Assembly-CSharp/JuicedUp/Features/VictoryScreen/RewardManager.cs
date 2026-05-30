using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Features.VictoryScreen
{
	public class RewardManager : IAsyncInitializable, IDisposable
	{
		public int rewardEasy;

		public int rewardHard;

		public int rewardSuperHard;

		private RemoteConfigService _remoteConfigService;

		public RewardManager(RemoteConfigService remoteConfigService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnRemoteConfigInitialized()
		{
		}

		private void ApplyConfig()
		{
		}

		public void Dispose()
		{
		}
	}
}
