using System;
using JuicedUp.Common.Economy.Public.Data;
using UniRx;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionsFacade
	{
		ReactiveProperty<int> SelectedDayIndex { get; }

		event Action CurrentWeeklyMissionCompleted;

		event Action<MissionData> MissionClaimed;

		event Action<MissionData> MissionCompleted;

		void SelectActiveMissionsData();

		void SelectMissionsDataByDayIndex(int dayIndex);

		void ClaimMission(MissionData missionData);

		void CompleteMission(MissionData missionData);

		MissionData[] GetCurrentMissions();

		void MarkCurrentConfigAsCompleted();

		int GetCurrentDailyMissionsIndex();

		int GetDailyIndexByMissionData(MissionData missionData);

		int GetMissionIndexInDay(MissionData missionData, int dayIndex);

		int GetMilestoneIndex(Milestone milestone);

		Bundle GetAllUnclaimedRewards();

		float GetRemainingTime();

		bool IsExistUncompletedMission(int dayIndex);

		bool IsExistUnclaimedMission(int dayIndex);

		bool IsExistUnclaimedMission();

		int GetUnclaimedMissionCount();

		bool IsSuitedDayForClaim();

		bool IsEnded();
	}
}
