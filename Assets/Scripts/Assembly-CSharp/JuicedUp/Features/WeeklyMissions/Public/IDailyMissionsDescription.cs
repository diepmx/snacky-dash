namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IDailyMissionsDescription
	{
		DailyMissionDescription GetDailyMissionDescriptionByQuestGoalType(MissionGoalType type);
	}
}
