using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Common.Time;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsAnalyticsSender : IWeeklyMissionsAnalyticsSender
	{
		private const string ParticipationCountKey = "WM_Analytics_ParticipationCount";

		private const string LastRunIdKey = "WM_Analytics_LastRunId";

		private const string LevelJoinedKey = "WM_Analytics_LevelJoined";

		private readonly IDataRepository<AnalyticsSaveData> _analyticsRepository;

		private readonly IWeeklyMissionsDataProvider _dataProvider;

		private readonly IWeeklyMissionsFacade _facade;

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IWallet _wallet;

		private readonly Loading _loading;

		public WeeklyMissionsAnalyticsSender(IDataRepository<AnalyticsSaveData> analyticsRepository, IWeeklyMissionsDataProvider dataProvider, IWeeklyMissionsFacade facade, IServerTimeProvider serverTimeProvider, IWallet wallet, Loading loading)
		{
		}

		public void SendImpressionEvent(string impressionTrigger, string widgetString, int currentMilestoneLevel)
		{
		}

		public void SendUserJoinedEvent()
		{
		}

		public void SendMissionCompletedEvent(MissionData missionData, int missionIndexInDay, int dayIndex)
		{
		}

		public void SendDayMilestoneCompletedEvent(int dayIndex)
		{
		}

		public void SendProgressionBarMilestoneEvent(int milestoneIndex)
		{
		}

		public void SendMissionItemTransactionEvent(IReward reward, int energyCollected)
		{
		}

		public void SendMilestoneItemTransactionEvent(IReward reward)
		{
		}

		public void SendEventCompletedEvent()
		{
		}

		private Dictionary<string, object> BuildBasePayload()
		{
			return null;
		}

		private void EnsureRunTracked()
		{
		}

		private string GetRawRunId()
		{
			return null;
		}

		private string GetRunId()
		{
			return null;
		}

		private int GetParticipationCount()
		{
			return 0;
		}

		private int GetLevelJoined()
		{
			return 0;
		}

		private int GetGameLevel()
		{
			return 0;
		}

		private int GetSecondsRemaining()
		{
			return 0;
		}

		private int GetDaysSinceInstall()
		{
			return 0;
		}

		private string GetConfigName()
		{
			return null;
		}

		private WeeklyMissionsData GetCurrentConfig()
		{
			return null;
		}

		private static string FormatMissionLevel(int missionIndex, MissionGoalType missionType)
		{
			return null;
		}

		private static string ToSnakeCase(string str)
		{
			return null;
		}

		private static string GetRewardItemName(IReward reward)
		{
			return null;
		}
	}
}
