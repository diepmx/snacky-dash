using System;
using System.Runtime.CompilerServices;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class MissionNotifier : IMissionExecutor, IMissionListener
	{
		public event Action<MissionGoalType, int> MissionExecuted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<MissionGoalType> MissionFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void ExecuteDailyMission(MissionGoalType type, int amount)
		{
		}

		public void FailDailyMissions(MissionGoalType type)
		{
		}
	}
}
