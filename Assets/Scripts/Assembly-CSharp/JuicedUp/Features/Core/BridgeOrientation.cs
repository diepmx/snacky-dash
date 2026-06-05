namespace JuicedUp.Features.Core
{
	public static class BridgeOrientation
	{
		/// <summary>Returns true if the bridge runs Left-Right (horizontal road on top, vertical underpass).</summary>
		public static bool IsLR(TileType type)
		{
			return type == TileType.BridgeLR
			    || type == TileType.BridgeSwitchableLR;
		}

		/// <summary>Returns true if the bridge runs Up-Down (vertical road on top, horizontal underpass).</summary>
		public static bool IsUD(TileType type)
		{
			return type == TileType.BridgeUD
			    || type == TileType.BridgeSwitchableUD;
		}

		/// <summary>Returns true for any bridge-like tile type (static or switchable).</summary>
		public static bool IsBridgeLike(TileType type)
		{
			return type == TileType.BridgeUD
			    || type == TileType.BridgeLR
			    || type == TileType.BridgeSwitchable
			    || type == TileType.BridgeSwitchableLR
			    || type == TileType.BridgeSwitchableUD
			    || type == TileType.BridgeDownStop;
		}

		/// <summary>
		/// Returns true when a tail segment travelling under a bridge should use the underpass layer.
		/// A segment is "underpass" when the snake body is going perpendicular to the bridge road.
		/// e.g. LR bridge: road goes horizontally, underpass is vertical → shape UpDown.
		/// </summary>
		public static bool IsUnderpassShape(SegmentShape shape, TileType bridgeType)
		{
			if (IsLR(bridgeType))
			{
				// LR bridge: road is horizontal, underpass traversal is vertical
				return shape == SegmentShape.StraightVertical;
			}
			if (IsUD(bridgeType))
			{
				// UD bridge: road is vertical, underpass traversal is horizontal
				return shape == SegmentShape.StraightHorizontal;
			}
			return false;
		}
	}
}
