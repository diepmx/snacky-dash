using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionsDataProvider
	{
		WeeklyMissionsData CurrentWeeklyMissionsData { get; }

		void Initialize();

		void Clear();

		MissionData[] GetMissionsByDayIndex(int dayIndex);

		IReadOnlyList<MissionData> GetAllMissionsFromConfig();

		IMilestone[] GetAllMilestones();

		int GetCountOfDailyMissions();

		DailyMissionsData[] GetAllDailyMissions();
	}
}
