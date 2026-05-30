using System;
using JuicesUp.Features.SeasonPass.Internal.Providers;
using VContainer;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	[Preserve]
	internal class BattlePassTokenService : IDisposable
	{
		private readonly IBattlePassAppBridge _appBridge;

		private readonly IBattlePassManager _manager;

		private readonly IBattlePassRemoteConfigsProvider _remoteConfigsProvider;

		private int _levelDifficulty;

		public BattlePassTokenService(IBattlePassManager manager, IBattlePassRemoteConfigsProvider remoteConfigsProvider, IBattlePassAppBridge appBridge)
		{
		}

		public void Dispose()
		{
		}

		private void OnGameStarted()
		{
		}

		private void OnGameWin()
		{
		}

		private int CalculateTokensForCurrentLevel()
		{
			return 0;
		}

		private int GetTokensForDifficulty(int difficulty)
		{
			return 0;
		}

		private bool IsFeatureUnlocked()
		{
			return false;
		}

		private bool CanEarnMoreTokens()
		{
			return false;
		}
	}
}
