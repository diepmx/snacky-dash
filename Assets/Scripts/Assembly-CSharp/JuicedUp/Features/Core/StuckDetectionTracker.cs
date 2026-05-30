using JuicedUp.Features.Core.Analytics;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class StuckDetectionTracker
	{
		public const string ExitReasonLevelRestart = "level_restart";

		public const string ExitReasonGameClosed = "game_close";

		public const string ExitReasonMainMenu = "main_menu";

		private int _consecutiveFailedSwipes;

		private Vector3 _lastFailedSwipePosition;

		private bool _lastHasNoWalkableDirections;

		public void IncrementFailedSwipe(Vector3 position, bool hasNoWalkableDirections)
		{
		}

		public void Reset()
		{
		}

		public void TryFireAndReset(ICoreGameAnalyticsService analyticsService, string exitReason)
		{
		}
	}
}
