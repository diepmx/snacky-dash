namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IMissionExecutor
	{
		void ExecuteDailyMission(MissionGoalType type, int amount);

		void FailDailyMissions(MissionGoalType type);
	}
}
