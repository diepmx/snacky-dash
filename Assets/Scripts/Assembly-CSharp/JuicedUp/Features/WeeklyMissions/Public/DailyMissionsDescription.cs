using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	[CreateAssetMenu(fileName = "DailyMissionsDescription", menuName = "Quest System/DailyMissionsDescription")]
	public class DailyMissionsDescription : ScriptableObject, IDailyMissionsDescription
	{
		[SerializeField]
		private List<DailyMissionDescription> _descriptions;

		public DailyMissionDescription GetDailyMissionDescriptionByQuestGoalType(MissionGoalType type)
		{
			return null;
		}
	}
}
