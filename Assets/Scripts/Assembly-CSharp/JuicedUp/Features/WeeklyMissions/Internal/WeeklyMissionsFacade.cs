using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Time;
using JuicedUp.Features.WeeklyMissions.Public;
using UniRx;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsFacade : IWeeklyMissionsFacade
	{
		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IWallet _wallet;

		public ReactiveProperty<int> SelectedDayIndex { get; }

		public event Action CurrentWeeklyMissionCompleted
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

		public event Action<MissionData> MissionClaimed
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

		public event Action<MissionData> MissionCompleted
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

		public WeeklyMissionsFacade(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, IServerTimeProvider serverTimeProvider, IWallet wallet)
		{
		}

		public void SelectActiveMissionsData()
		{
		}

		public void SelectMissionsDataByDayIndex(int dayIndex)
		{
		}

		public void ClaimMission(MissionData missionData)
		{
		}

		public void CompleteMission(MissionData missionData)
		{
		}

		public MissionData[] GetCurrentMissions()
		{
			return null;
		}

		public bool IsSuitedDayForClaim()
		{
			return false;
		}

		public int GetCurrentDailyMissionsIndex()
		{
			return 0;
		}

		public int GetDailyIndexByMissionData(MissionData missionData)
		{
			return 0;
		}

		public int GetMissionIndexInDay(MissionData missionData, int dayIndex)
		{
			return 0;
		}

		public int GetMilestoneIndex(Milestone milestone)
		{
			return 0;
		}

		public Bundle GetAllUnclaimedRewards()
		{
			return null;
		}

		public float GetRemainingTime()
		{
			return 0f;
		}

		public bool IsEnded()
		{
			return false;
		}

		public bool IsExistUncompletedMission(int dayIndex)
		{
			return false;
		}

		public bool IsExistUnclaimedMission(int dayIndex)
		{
			return false;
		}

		public bool IsExistUnclaimedMission()
		{
			return false;
		}

		public int GetUnclaimedMissionCount()
		{
			return 0;
		}

		public void MarkCurrentConfigAsCompleted()
		{
		}
	}
}
