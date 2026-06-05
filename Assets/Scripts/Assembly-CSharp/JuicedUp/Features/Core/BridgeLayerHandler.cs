using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Stateless helper that determines the vertical layer (Above/Below/OnGround)
	/// of the snake when it interacts with bridge tiles.
	///
	/// A bridge tile has two traversal modes:
	///   - "On top" (Above): snake is on the road surface on top of the bridge.
	///   - "Underpass" (Below): snake passes under the bridge deck going perpendicularly.
	///
	/// The LevelController/Player consult this class when the snake moves into or out
	/// of a bridge cell to determine whether to render the snake above or below the bridge.
	/// </summary>
	public static class BridgeLayerHandler
	{
		/// <summary>
		/// Called when the snake HEAD moves from prevCell to newCell.
		/// Returns true if the bridge requires a layer change, and sets result accordingly.
		///
		/// Logic:
		///   - If newCell is a bridge tile AND the snake is moving perpendicular to the bridge
		///     axis → the snake is going under (State.Below).
		///   - If the snake is moving parallel to the bridge axis → it is on top (State.Above).
		///   - If neither cell is a bridge → no change (returns false).
		/// </summary>
		public static bool TryApplyTransition(
			Vector3Int prevCell,
			Vector3Int newCell,
			DirectionPlayer direction,
			out State result)
		{
			result = State.OnGround;

			// We need the LevelController to look up tile types
			LevelController lc = LevelController.Instance;
			if (lc == null) return false;

			// Check bridge tile at the destination cell
			if (!lc.TryGetTileType(newCell, out TileType newTileType))
				return false;

			if (!BridgeOrientation.IsBridgeLike(newTileType))
				return false;

			// Determine traversal mode based on direction vs bridge orientation
			bool isUnderpass = IsUnderpassDirection(direction, newTileType);
			result = isUnderpass ? State.Below : State.Above;
			return true;
		}

		/// <summary>
		/// Called one cell before the snake reaches a bridge, so the layer can be set in advance
		/// (e.g. to drive the sorting order update before the visual pops).
		/// Returns true if the cell AHEAD of currentCell is a bridge.
		/// </summary>
		public static bool TryApplyPreBridge(
			Vector3Int currentCell,
			DirectionPlayer direction,
			out State result)
		{
			result = State.OnGround;

			Vector3Int nextCell = currentCell + DirectionToOffset(direction);
			return TryApplyTransition(currentCell, nextCell, direction, out result);
		}

		// ─── Helpers ─────────────────────────────────────────────────────────────

		/// <summary>
		/// Returns true when the movement direction is perpendicular to the bridge axis
		/// (i.e. the snake goes underneath the bridge deck).
		/// </summary>
		private static bool IsUnderpassDirection(DirectionPlayer direction, TileType bridgeType)
		{
			if (BridgeOrientation.IsLR(bridgeType))
			{
				// LR bridge: road runs Left↔Right, underpass direction is Up or Down
				return direction == DirectionPlayer.Up || direction == DirectionPlayer.Down;
			}
			if (BridgeOrientation.IsUD(bridgeType))
			{
				// UD bridge: road runs Up↔Down, underpass direction is Left or Right
				return direction == DirectionPlayer.Left || direction == DirectionPlayer.Right;
			}
			return false;
		}

		private static Vector3Int DirectionToOffset(DirectionPlayer direction)
		{
			switch (direction)
			{
				case DirectionPlayer.Up:    return Vector3Int.up;
				case DirectionPlayer.Down:  return Vector3Int.down;
				case DirectionPlayer.Left:  return Vector3Int.left;
				case DirectionPlayer.Right: return Vector3Int.right;
				default: return Vector3Int.zero;
			}
		}
	}
}
