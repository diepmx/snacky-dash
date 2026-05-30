using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsEventsHandler : IWeeklyMissionsEventsHandler, IAsyncInitializable, IDisposable
	{
		private const string UserJoinEventSaveKey = "WM_UserJoin";

		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly WeeklyMissionsMilestonesHandler _milestonesHandler;

		private readonly IWeeklyMissionsAnalyticsSender _analyticsSender;

		private readonly IWeeklyMissionsFacade _weeklyMissionsFacade;

		private readonly Loading _loading;

		public WeeklyMissionsEventsHandler(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, WeeklyMissionsMilestonesHandler milestonesHandler, IWeeklyMissionsAnalyticsSender analyticsSender, IWeeklyMissionsFacade weeklyMissionsFacade, Loading loading)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		public void Initialize()
		{
		}

		public void Clear()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnMilestoneClaimed(IMilestone milestone)
		{
		}

		private void OnMissionCompleted(MissionData missionData)
		{
		}

		private void OnMissionClaimed(MissionData missionData)
		{
		}

		private void OnCurrentWeeklyMissionCompleted()
		{
		}

		private void InitUserJoinEvent()
		{
		}

		private bool IsUnlocked()
		{
			return false;
		}
	}
}
