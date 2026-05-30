using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public class WeeklyMissionsData
	{
		private const string WeeklyMissionsStatusSaveKey = "WeeklyMission_{0}_Current_Status";

		private const string WeeklyMissionsStartingDaySaveKey = "WeeklyMission_{0}_Starting_Day";

		private const string WeeklyMissionsMilestoneFirstActiveIndexKey = "WeeklyMission_{0}_Milestone_FirstActiveIndex";

		public string Name;

		public DailyMissionsData[] DailyMissionsData;

		public Milestone[] Milestones;

		public void Activate(DateTime startDate)
		{
		}

		public DateTime GetActivationDateTime()
		{
			return default(DateTime);
		}

		public DateTime GetDeactivationDateTime()
		{
			return default(DateTime);
		}

		public bool HasStared()
		{
			return false;
		}

		public bool IsEnded(DateTime now)
		{
			return false;
		}

		public bool IsCompleted()
		{
			return false;
		}

		public void MarkAsCompleted()
		{
		}

		public int GetFirstActiveMilestoneIndex()
		{
			return 0;
		}

		public void SetFirstActiveMilestoneIndex(int index)
		{
		}

		public void ResetAllSaveData()
		{
		}
	}
}
