using System;
using JuicedUp.Common.Economy.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	[Serializable]
	internal class WeeklyMissionsDataConfig
	{
		public string Name;

		public DailyMissionsDataConfig[] DailyMissionsData;

		public MilestoneConfig[] Milestones;
	}
}
