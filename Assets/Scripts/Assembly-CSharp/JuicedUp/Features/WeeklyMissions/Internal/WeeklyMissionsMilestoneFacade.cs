using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal sealed class WeeklyMissionsMilestoneFacade : IMilestoneFacade
	{
		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		public WeeklyMissionsMilestoneFacade(IWeeklyMissionsDataProvider weeklyMissionsDataProvider)
		{
		}

		public IReadOnlyList<IMilestone> GetAllMilestones()
		{
			return null;
		}

		public IMilestone GetCurrentActiveMilestone()
		{
			return null;
		}

		public bool IsClaimed(IMilestone milestone)
		{
			return false;
		}

		public void MarkClaimed(IMilestone milestone)
		{
		}

		private int TryGetMilestoneIndex(IMilestone milestone)
		{
			return 0;
		}
	}
}
