using System;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	[Serializable]
	internal class MissionDataConfig
	{
		public MissionGoalType Type;

		public BundleConfig Bundle;

		public string Description;

		public int Amount;
	}
}
