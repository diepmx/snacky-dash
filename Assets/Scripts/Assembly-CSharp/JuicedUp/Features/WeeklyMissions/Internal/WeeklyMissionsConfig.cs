using System;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	[Serializable]
	internal class WeeklyMissionsConfig
	{
		private static WeeklyMissionsConfig _config;

		public int UnlockLevel;

		public bool IsActive;

		public string DefaultConfigJson;

		public string FtueConfigJson;

		[NonSerialized]
		public WeeklyMissionsData DefaultWeeklyMissionsData;

		public static void Init()
		{
		}

		public static WeeklyMissionsConfig GetConfig()
		{
			return null;
		}

		private static void ParseDefaultConfig()
		{
		}
	}
}
