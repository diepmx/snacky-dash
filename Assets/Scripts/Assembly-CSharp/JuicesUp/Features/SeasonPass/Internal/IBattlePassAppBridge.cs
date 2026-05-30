using System;
using JuicedUp.Common.QueueManagement;
using UnityEngine;
using Voodoo.Live;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IBattlePassAppBridge
	{
		int CoinsBalance { get; }

		int CurrentLevelIndex { get; }

		int CurrentLevelDifficulty { get; }

		string VoodooLiveBattlePassRewardName { get; }

		DateTime CustomDateTimeNow { get; }

		int BoosterHammerBalance { get; }

		int BoosterSlotBalance { get; }

		int BoosterShuffleBalance { get; }

		int BoosterSelectBalance { get; }

		int DaysSinceInstall { get; }

		int LifeBalance { get; }

		event Action<int> LevelChanged;

		void UpdateMaxLives(int amount);

		void SetLifeBalance(int balance);

		void RegisterRewardHandler(string rewardName, Action<ItemQuantity> handler);

		void UnregisterRewardHandler(string rewardName);

		void FlyAttractor(Vector3 source, Transform target, Sprite sprite, int count, Action onComplete);

		void SubscribeOnGameStartedEvent(Action onGameStarted);

		void UnsubscribeOnGameStartedEvent(Action onGameStarted);

		void SubscribeOnGameWinEvent(Action onGameWin);

		void UnsubscribeOnGameWinEvent(Action onGameWin);

		void RegisterActionQueueEvent(Action<IActionQueue> queuedEvent);

		void ShowLoader();

		void HideLoader();

		void ShowPurchaseFailed();
	}
}
