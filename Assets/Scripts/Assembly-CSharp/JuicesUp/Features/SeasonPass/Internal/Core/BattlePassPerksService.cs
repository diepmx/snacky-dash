using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap;
using JuicesUp.Features.SeasonPass.Internal.Providers;
using UnityEngine.Scripting;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	[Preserve]
	internal class BattlePassPerksService : IDisposable, IAsyncInitializable, IBattlePassPerksService
	{
		private const string BattlePassPerkLives = "battle_pass_perk_lives";

		private const string BattlePassPerkLivesRemove = "battle_pass_perk_lives_remove";

		private readonly IBattlePassManager _manager;

		private readonly IBattlePassRemoteConfigsProvider _remoteData;

		private readonly IBattlePassAppBridge _appBridge;

		public bool IsLivesBoostActive => false;

		public int LivesBoostAmount => 0;

		public BattlePassPerksService(IBattlePassManager manager, IBattlePassRemoteConfigsProvider remoteConfigsProvider, IBattlePassAppBridge appBridge)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnPremiumPurchased()
		{
		}

		private void OnGracePeriodStarted()
		{
		}

		public void UpdatePerks()
		{
		}

		public void RemoveAllPerks()
		{
		}

		private void ApplyLivesBoost()
		{
		}

		private void RemoveLivesBoost()
		{
		}
	}
}
