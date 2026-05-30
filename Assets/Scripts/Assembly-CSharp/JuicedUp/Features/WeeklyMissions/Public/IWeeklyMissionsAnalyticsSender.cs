using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionsAnalyticsSender
	{
		void SendImpressionEvent(string impressionTrigger, string widgetString, int currentMilestoneLevel);

		void SendUserJoinedEvent();

		void SendMissionCompletedEvent(MissionData missionData, int missionIndexInDay, int dayIndex);

		void SendDayMilestoneCompletedEvent(int dayIndex);

		void SendProgressionBarMilestoneEvent(int milestoneIndex);

		void SendMissionItemTransactionEvent(IReward reward, int energyCollected);

		void SendMilestoneItemTransactionEvent(IReward reward);

		void SendEventCompletedEvent();
	}
}
