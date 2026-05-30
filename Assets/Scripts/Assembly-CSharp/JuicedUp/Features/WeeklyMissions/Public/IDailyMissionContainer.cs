namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IDailyMissionContainer
	{
		IDailyMissionView DailyMissionView { get; }

		void SetNewDailyMissionView(IDailyMissionView dailyMissionView);
	}
}
