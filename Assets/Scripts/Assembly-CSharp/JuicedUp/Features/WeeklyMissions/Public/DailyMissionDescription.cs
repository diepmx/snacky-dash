using System;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	[Serializable]
	public class DailyMissionDescription
	{
		public MissionGoalType GoalType;

		public Sprite Sprite;

		public string Description;

		public string MultipleDescription;
	}
}
