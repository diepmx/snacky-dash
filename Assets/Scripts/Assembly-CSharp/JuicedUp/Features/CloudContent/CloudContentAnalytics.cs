using JuicedUp.Features.Core;

namespace JuicedUp.Features.CloudContent
{
	public sealed class CloudContentAnalytics
	{
		private const string EventInit = "cloud_content_init";

		private const string EventLevelLoaded = "cloud_level_loaded";

		private const string SuccessKey = "success";

		private const string CohortNameKey = "cohort_name";

		private const string LevelCountKey = "level_count";

		private const string PlayerLevelIndexKey = "player_level_index";

		private const string SourceKey = "source";

		private bool _isInitTracked;

		public void TrackInit(CloudContentState state, string cohortName, int levelCount)
		{
		}

		public void TrackLevelLoaded(int playerLevelIndex, LevelSource source, string cohortName)
		{
		}
	}
}
