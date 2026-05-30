using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IMissionDescriptionProvider
	{
		string GetMissionTitle(MissionData missionData);

		Sprite GetMissionIcon(MissionGoalType missionType);
	}
}
