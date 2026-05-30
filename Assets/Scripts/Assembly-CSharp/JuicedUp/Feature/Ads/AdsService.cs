using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;

namespace JuicedUp.Feature.Ads
{
	public class AdsService : IAsyncInitializable, IDisposable
	{
		private readonly RemoteConfigService _remoteConfigService;

		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly AdsPersistence _adsPersistence;

		private bool _rewardedVideoWatchedThisSession;

		public static AdsService Instance { get; private set; }

		public AdsConfig Config => null;

		public AdsPersistence Persistence => null;

		public AdsService(RemoteConfigService remoteConfigService, AdsPersistence adsPersistence, IEntitlementStorage entitlementStorage, IGameStateEvents gameStateEvents)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void HandleGameStateChangedForRv(GameState state, DefeatType defeatType)
		{
		}

		public void TryShowInterstitial(int currentLevel, Action<bool> onComplete, string interstitialType = "level_completed")
		{
		}

		public bool IsRewardedVideoAvailableForUI()
		{
			return false;
		}

		private bool IsRewardedVideoAvailable()
		{
			return false;
		}

		public void ShowRewardedVideo(Action<bool> onComplete, string rewardedType = null)
		{
		}

		public bool CanRefillLifeWithRewardedVideo()
		{
			return false;
		}

		public void TryRefillLifeWithRewardedVideo(Action<bool> onComplete)
		{
		}

		private void AddOneLife()
		{
		}

		private bool CanShowInterstitial(int currentLevel)
		{
			return false;
		}

		public void Dispose()
		{
		}
	}
}
