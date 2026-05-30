using JuicedUp.Features.Core;
using UnityEngine;

public static class PlayerTileRules
{
	public static Vector2Int DirectionToVector2Int(DirectionPlayer direction)
	{
		return default(Vector2Int);
	}

	public static Vector3 DirectionToVector3(DirectionPlayer direction)
	{
		return default(Vector3);
	}

	public static bool IsPill(TileType tileType)
	{
		return false;
	}

	public static bool IsAiguillage(TileType tileType)
	{
		return false;
	}

	public static Vector2Int NextGridPos(Vector3 worldPos, DirectionPlayer direction)
	{
		return default(Vector2Int);
	}

	public static bool IsRegularBridgeLike(TileType t)
	{
		return false;
	}

	public static bool IsSwitchableBridgeLike(TileType t)
	{
		return false;
	}

	public static bool IsBridgeLike(TileType t)
	{
		return false;
	}

	public static Vector2Int[] GetAdjacentOffsets()
	{
		return null;
	}

	public static Vector2Int[] GetOneAdjacentOffsets()
	{
		return null;
	}

	public static bool DirectionMatchesBridge(TileType bridgeType, DirectionPlayer dir)
	{
		return false;
	}

	public static bool IsTunnelTile(TileType tileType)
	{
		return false;
	}

	public static bool IsCrossRoadTile(TileType t)
	{
		return false;
	}

	public static bool IsCornerTile(TileType tileType)
	{
		return false;
	}

	public static bool IsCornerAiguillageTile(TileType tileType)
	{
		return false;
	}

	public static bool IsCrateTile(TileType tileType)
	{
		return false;
	}

	public static bool IsDeliverPointTile(TileType tileType)
	{
		return false;
	}

	public static bool IsKnotTile(TileType tileType)
	{
		return false;
	}

	public static bool IsStopTile(TileType tileType)
	{
		return false;
	}

	public static bool IsArrow(TileType t)
	{
		return false;
	}

	public static bool IsFixedArrow(TileType t)
	{
		return false;
	}

	public static bool IsTraversableGeometryUnderPlot(TileType t)
	{
		return false;
	}
}
