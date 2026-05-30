using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Time;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsDataProvider : IWeeklyMissionsDataProvider
	{
		private const string LastActivationDateKey = "WM_LastActivationDate";

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IWallet _wallet;

		public WeeklyMissionsData CurrentWeeklyMissionsData { get; private set; }

		public WeeklyMissionsDataProvider(IServerTimeProvider serverTimeProvider, IWallet wallet)
		{
		}

		public void Initialize()
		{
		}

		public void Clear()
		{
		}

		public MissionData[] GetMissionsByDayIndex(int dayIndex)
		{
			return null;
		}

		public IReadOnlyList<MissionData> GetAllMissionsFromConfig()
		{
			return null;
		}

		public IMilestone[] GetAllMilestones()
		{
			return null;
		}

		public int GetCountOfDailyMissions()
		{
			return 0;
		}

		public DailyMissionsData[] GetAllDailyMissions()
		{
			return null;
		}

		private WeeklyMissionsData GetCurrentConfig()
		{
			return null;
		}

		private DateTime LastActivationDateTime()
		{
			return default(DateTime);
		}
	}
}
