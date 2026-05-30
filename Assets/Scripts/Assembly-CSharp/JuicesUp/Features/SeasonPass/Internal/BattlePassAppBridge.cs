using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.QueueManagement;
using UnityEngine;
using Voodoo.Live;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal class BattlePassAppBridge : IDisposable, IBattlePassAppBridge, IDebugBattlePassTimeOverride
	{
		private readonly IServerTimeProvider _serverTimeProvider;

		private TimeSpan? _debugTimeOffset;

		private Action _onGameStarted;

		private Action _onGameWin;

		public int CoinsBalance => 0;

		public int CurrentLevelIndex => 0;

		public int CurrentLevelDifficulty => 0;

		public string VoodooLiveBattlePassRewardName => null;

		public DateTime CustomDateTimeNow => default(DateTime);

		public int BoosterHammerBalance => 0;

		public int BoosterSlotBalance => 0;

		public int BoosterShuffleBalance => 0;

		public int BoosterSelectBalance => 0;

		public int DaysSinceInstall => 0;

		public int LifeBalance => 0;

		public event Action<int> LevelChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SetDebugTimeOffset(TimeSpan? offset)
		{
		}

		public BattlePassAppBridge(IServerTimeProvider serverTimeProvider)
		{
		}

		public void Dispose()
		{
		}

		private void OnLevelIncreased(int level)
		{
		}

		public void SubscribeOnGameStartedEvent(Action onGameStarted)
		{
		}

		public void UnsubscribeOnGameWinEvent(Action onGameWin)
		{
		}

		public void SubscribeOnGameWinEvent(Action onGameWin)
		{
		}

		public void UnsubscribeOnGameStartedEvent(Action onGameStarted)
		{
		}

		public void RegisterActionQueueEvent(Action<IActionQueue> queuedEvent)
		{
		}

		private void OnLevelStart()
		{
		}

		private void OnGameEnd(bool isWin)
		{
		}

		public void UpdateMaxLives(int amount)
		{
		}

		public void SetLifeBalance(int balance)
		{
		}

		public void RegisterRewardHandler(string rewardName, Action<ItemQuantity> handler)
		{
		}

		public void UnregisterRewardHandler(string rewardName)
		{
		}

		public void FlyAttractor(Vector3 source, Transform target, Sprite sprite, int count, Action onComplete)
		{
		}

		public void ShowLoader()
		{
		}

		public void HideLoader()
		{
		}

		public void ShowPurchaseFailed()
		{
		}
	}
}
