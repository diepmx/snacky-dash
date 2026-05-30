using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public class DailyMissionsPayload
	{
		public readonly IMissionDescriptionProvider MissionDescriptionProvider;

		public readonly IDailyMissionContainer[] DailyMissionContainers;

		public readonly IWeeklyMissionsFacade WeeklyMissionsFacade;

		public readonly IRewardViewSetuper RewardViewSetuper;

		public readonly IEconomyService EconomyService;

		public DailyMissionsPayload(IMissionDescriptionProvider missionDescriptionProvider, IDailyMissionContainer[] dailyMissionContainers, IWeeklyMissionsFacade weeklyMissionsFacade, IRewardViewSetuper rewardViewSetuper, IEconomyService economyService)
		{
		}
	}
}
