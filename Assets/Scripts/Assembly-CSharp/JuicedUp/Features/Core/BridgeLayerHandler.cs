using UnityEngine;

namespace JuicedUp.Features.Core
{
	public static class BridgeLayerHandler
	{
		public static bool TryApplyTransition(Vector3Int prevCell, Vector3Int newCell, DirectionPlayer direction, out State result)
		{
			result = default(State);
			return false;
		}

		public static bool TryApplyPreBridge(Vector3Int currentCell, DirectionPlayer direction, out State result)
		{
			result = default(State);
			return false;
		}
	}
}
