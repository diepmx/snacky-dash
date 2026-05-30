using JuicedUp.Features.WeeklyMissions.Public;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class MissionDescriptionProvider : IMissionDescriptionProvider
	{
		private readonly IDailyMissionsDescription _missionsDescription;

		public MissionDescriptionProvider(IDailyMissionsDescription missionsDescription)
		{
		}

		public string GetMissionTitle(MissionData missionData)
		{
			return null;
		}

		public Sprite GetMissionIcon(MissionGoalType missionType)
		{
			return null;
		}
	}
}
