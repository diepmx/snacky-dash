using UnityEngine;

namespace JuicedUp.Features.Core.Analytics
{
	public struct PlayerStuckData
	{
		public int ConsecutiveFailedSwipes { get; private set; }

		public string ExitReason { get; private set; }

		public Vector3 PlayerPosition { get; private set; }

		public bool HasNoWalkableDirections { get; private set; }

		public PlayerStuckData(int consecutiveFailedSwipes, string exitReason, Vector3 playerPosition, bool hasNoWalkableDirections)
		{
			ConsecutiveFailedSwipes = 0;
			ExitReason = null;
			PlayerPosition = default(Vector3);
			HasNoWalkableDirections = false;
		}
	}
}
