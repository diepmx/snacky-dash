using System;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	internal interface IMissionListener
	{
		event Action<MissionGoalType, int> MissionExecuted;

		event Action<MissionGoalType> MissionFailed;
	}
}
