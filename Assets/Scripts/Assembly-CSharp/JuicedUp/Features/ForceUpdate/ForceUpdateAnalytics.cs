namespace JuicedUp.Features.ForceUpdate
{
	internal static class ForceUpdateAnalytics
	{
		private const string EventShown = "force_update_shown";

		private const string EventClicked = "force_update_clicked";

		private const string ParamCurrentVersion = "current_version";

		private const string ParamMinimumVersion = "minimum_version";

		internal static void TrackShown(string minimumVersion)
		{
		}

		internal static void TrackClicked(string minimumVersion)
		{
		}
	}
}
