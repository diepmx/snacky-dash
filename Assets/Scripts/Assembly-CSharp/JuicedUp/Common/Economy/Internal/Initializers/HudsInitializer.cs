using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Providers;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Notifiers;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Common.Economy.Internal.Initializers
{
	internal class HudsInitializer : IAsyncInitializable, IDisposable
	{
		private IRewardHudRegistrationNotifier _rewardHudRegistrationNotifier;

		private ActiveRewardHudViewProvider _activeRewardHudViewProvider;

		private IHudValueSyncService _hudValueSyncService;

		private IHudIconSyncService _hudIconSyncService;

		public HudsInitializer(IRewardHudRegistrationNotifier rewardHudRegistrationNotifier, ActiveRewardHudViewProvider activeRewardHudViewProvider, IHudValueSyncService hudValueSyncService, IHudIconSyncService hudIconSyncService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnRewardHudRegistered(IRewardHudView rewardHudView)
		{
		}
	}
}
