using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Common.Time;

namespace JuicedUp.Features.Core.Analytics
{
	internal class AnalyticsDataProvider : IDisposable
	{
		private readonly IBoosterStorage _boosterStorage;

		private readonly IDataRepository<AnalyticsSaveData> _repository;

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IWallet _wallet;

		private List<string> _boosterBalanceKeys;

		private string _boosterNames;

		private List<string> _boosterUsedKeys;

		private readonly ILevelProvider _levelProvider;

		private int _currentStreak;

		private DateTime _installDateUtc;

		private bool _isPayerUser;

		private int _maxWinStreak;

		private int _numberOfShopOpen;

		internal string GetBoosterNames => null;

		internal List<string> GetBoosterUsedKeys => null;

		internal List<string> GetBoosterBalanceKeys => null;

		internal GameAttemptTracker AttemptTracker { get; }

		internal AnalyticsDataProvider(IWallet wallet, IBoosterStorage boosterStorage, IDataRepository<AnalyticsSaveData> repository, IServerTimeProvider serverTimeProvider, GameAttemptTracker attemptTracker, ILevelProvider levelProvider)
		{
		}

		public void Dispose()
		{
		}

		internal void Init()
		{
		}

		internal int GetCurrentLevel()
		{
			return 0;
		}

		internal int GetCurrentOriginalLevel()
		{
			return 0;
		}

		internal float GetCoinBalance()
		{
			return 0f;
		}

		internal string GetLevelDifficulty()
		{
			return null;
		}

		internal int GetGameLoop()
		{
			return 0;
		}

		internal string GetLevelFunnel()
		{
			return null;
		}

		internal int GetStreakMeter()
		{
			return 0;
		}

		internal int GetMaxWinStreak()
		{
			return 0;
		}

		internal bool IsPayerUser()
		{
			return false;
		}

		internal int GetLifeBalance()
		{
			return 0;
		}

		internal int GetNumberOfShopOpen()
		{
			return 0;
		}

		internal float GetNumberOfObjectives()
		{
			return 0f;
		}

		internal int GetNumberOfCrates()
		{
			return 0;
		}

		internal int GetNumberOfObjectivesLeft()
		{
			return 0;
		}

		internal float GetPercentageOfObjectivesLeft()
		{
			return 0f;
		}

		internal int GetBoosterBalance(BoosterId boosterId)
		{
			return 0;
		}

		internal int GetDaysSinceInstall()
		{
			return 0;
		}

		internal string GetVoodooTuneShopId()
		{
			return null;
		}

		internal void OnGameFinished(bool isVictory)
		{
		}

		internal void OnShopOpened()
		{
		}

		internal void OnItemTransactionCompleted(string iap)
		{
		}

		private int GetRawLevelIndex()
		{
			return 0;
		}

		private List<string> GetOrGenerateBoosterBalanceKeys()
		{
			return null;
		}

		private List<string> GetOrGenerateBoosterUsedKeys()
		{
			return null;
		}

		private string GetOrGenerateBoosterNames()
		{
			return null;
		}

		private void GenerateBoosterNamesAndKeys()
		{
		}
	}
}
