using JuicedUp.Common.Network;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public class BottomDailyItemsPayload
	{
		public readonly INetworkConnectionProvider NetworkConnectionProvider;

		public readonly IWeeklyMissionsFacade WeeklyMissionsFacade;

		public readonly DailyMissionsData[] DailyMissionsData;

		public readonly Transform BottomDailyMissionsParent;

		public BottomDailyItemsPayload(INetworkConnectionProvider networkConnectionProvider, IWeeklyMissionsFacade weeklyMissionsFacade, DailyMissionsData[] dailyMissionsData, Transform bottomDailyMissionsParent)
		{
		}
	}
}
