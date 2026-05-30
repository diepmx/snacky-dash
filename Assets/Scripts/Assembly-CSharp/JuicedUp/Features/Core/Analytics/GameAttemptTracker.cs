using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Core.Analytics
{
	public class GameAttemptTracker : IDisposable
	{
		private readonly Dictionary<BoosterId, int> _boosterUsagePerType;

		private readonly List<int> _comboList;

		private int _softCurrencySpent;

		private bool _isTracking;

		internal int ReviveCount { get; private set; }

		internal int SwipeCount { get; private set; }

		internal int TotalBoostersUsed => 0;

		internal float SoftCurrencyUsed => 0f;

		internal int CurrentTailLength { get; private set; }

		internal int MaxTailLength { get; private set; }

		internal int CratesCompleted { get; private set; }

		internal int ComboCoin { get; private set; }

		internal IReadOnlyList<int> ComboList => null;

		internal IReadOnlyDictionary<BoosterId, int> BoosterUsagePerType => null;

		public void Dispose()
		{
		}

		internal void Subscribe()
		{
		}

		private void OnLevelBuilt(LevelDataSO levelData, LevelBuilder levelBuilder)
		{
		}

		private void Reset()
		{
		}

		private void OnBoosterTriggered(BoosterId boosterId)
		{
		}

		private void OnReviveTriggered()
		{
		}

		internal void AccumulateSoftCurrencySpent(int amount)
		{
		}

		private void OnSwipe(DirectionPlayer direction)
		{
		}

		private void OnTailUpdated(int tailLength)
		{
		}

		private void OnCrateCompleted(PillKind pillKind)
		{
		}

		private void OnComboCrateRewarded(int coinsThisStep)
		{
		}
	}
}
