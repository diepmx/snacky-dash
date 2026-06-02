using System;
using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public static class PillSpawnEligibility
{
	public static bool IsCellEligibleForInitialSpawn(Vector3Int cell, TileType baseTileType, bool? spawnOverlayAllow = null, bool risingBlockActivated = false, bool blockerCleared = true)
	{
		if (!blockerCleared)
		{
			return false;
		}
		if (IsTileTypeHardNeverSpawn(baseTileType))
		{
			return false;
		}
		if (IsTileTypeNeverSpawn(baseTileType))
		{
			return false;
		}
		if (risingBlockActivated && IsRisingBlockRestrictedType(baseTileType))
		{
			return false;
		}
		if (spawnOverlayAllow.HasValue && !spawnOverlayAllow.Value)
		{
			return false;
		}
		if (IsCellBlockedByAnyLayer(cell))
		{
			return false;
		}
		return true;
	}

	public static bool IsCellBlockedByAnyLayer(Vector3Int cell)
	{
		return PillSpawnBlockerRegistry.IsBlockerOrAdjacentCell(cell) && !PillSpawnBlockerRegistry.IsBlockerCleared(cell);
	}

	public static bool IsCellEligibleForRespawnSlot(Vector3Int cell, PillSpawnRelaxationTier tier)
	{
		LevelController instance = LevelController.Instance;
		if ((UnityEngine.Object)(object)instance == (UnityEngine.Object)null)
		{
			return false;
		}
		TileType tileTypeAt = instance.GetTileTypeAt(new Vector2Int(cell.x, cell.y));
		if (IsTileTypeHardNeverSpawn(tileTypeAt))
		{
			return false;
		}
		return tier switch
		{
			PillSpawnRelaxationTier.Strict => IsStrictEligible(tileTypeAt),
			PillSpawnRelaxationTier.RelaxNoSpawnMarker => IsStrictEligible(tileTypeAt) || tileTypeAt == TileType.RoadRightLeftNoPill || tileTypeAt == TileType.RoadUpDownNoPill,
			PillSpawnRelaxationTier.RelaxDeliverPoints => IsStrictEligible(tileTypeAt) || tileTypeAt == TileType.RoadRightLeftNoPill || tileTypeAt == TileType.RoadUpDownNoPill || tileTypeAt == TileType.Stop || tileTypeAt == TileType.Stop_CRATE || tileTypeAt == TileType.Stop_CRATE_0 || tileTypeAt == TileType.Stop_CRATE_1 || tileTypeAt == TileType.Stop_CRATE_2,
			PillSpawnRelaxationTier.RelaxBridges => !IsTileTypeHardNeverSpawn(tileTypeAt) && tileTypeAt != TileType.Tunnel,
			PillSpawnRelaxationTier.RelaxKnots => !IsTileTypeHardNeverSpawn(tileTypeAt) && tileTypeAt != TileType.Tunnel,
			_ => IsStrictEligible(tileTypeAt),
		};
	}

	private static int MaxTileZInclusive()
	{
		return 0;
	}

	private static bool IsCellNeverSpawnByTileType(Vector3Int cell)
	{
		LevelController instance = LevelController.Instance;
		if ((UnityEngine.Object)(object)instance == (UnityEngine.Object)null)
		{
			return false;
		}
		TileType tileTypeAt = instance.GetTileTypeAt(new Vector2Int(cell.x, cell.y));
		return IsTileTypeNeverSpawn(tileTypeAt) || IsTileTypeHardNeverSpawn(tileTypeAt);
	}

	private static bool IsTileTypeNeverSpawn(TileType tileType)
	{
		return tileType == TileType.NonPillSpawnPlace;
	}

	private static bool IsTileTypeHardNeverSpawn(TileType tileType)
	{
		switch (tileType)
		{
		case TileType.Empty:
		case TileType.Plot:
		case TileType.Wall:
		case TileType.Enemy:
		case TileType.Contour:
		case TileType.Tunnel:
		case TileType.None:
		case TileType.PlayerStartPosition:
		case TileType.SecretCollectible:
			return true;
		default:
			return false;
		}
	}

	private static bool IsRisingBlockRestrictedType(TileType tileType)
	{
		return tileType == TileType.RoadRightLeftNoPill || tileType == TileType.RoadUpDownNoPill || tileType == TileType.NonPillSpawnPlace;
	}

	private static bool IsStrictEligible(TileType tileType)
	{
		switch (tileType)
		{
		case TileType.CornerUpRight:
		case TileType.CornerDownRight:
		case TileType.CornerUpLeft:
		case TileType.CornerDownLeft:
		case TileType.RoadRightLeft:
		case TileType.RoadUpDown:
		case TileType.CrossRoad:
		case TileType.BridgeUD:
		case TileType.BridgeLR:
		case TileType.FlippingArrowLeft:
		case TileType.FlippingArrowRight:
		case TileType.FlippingArrowDown:
		case TileType.FlippingArrowUp:
		case TileType.PillSpawnPoint:
		case TileType.RoadRightLeft_DestructibleWall:
		case TileType.RoadUpDown_DestructibleWall:
		case TileType.FixedArrowLeft:
		case TileType.FixedArrowRight:
		case TileType.FixedArrowDown:
		case TileType.FixedArrowUp:
		case TileType.PathConnectionBoat:
		case TileType.BridgeSwitchable:
		case TileType.BridgeDownStop:
		case TileType.BridgeSwitchableLR:
		case TileType.BridgeSwitchableUD:
		case TileType.CrossRoadToggleOFF:
		case TileType.CrossRoadToggleOn:
		case TileType.Aiguillage_Left_Down_Open:
		case TileType.Aiguillage_Left_Down:
		case TileType.Aiguillage_Right_Down_Open:
		case TileType.Aiguillage_Right_Down:
		case TileType.Aiguillage_Right_U_D:
		case TileType.Aiguillage_Left_U_D:
		case TileType.Aiguillage_Up_R_L:
		case TileType.Aiguillage_DOWN_R_L:
		case TileType.Aiguillage_Left_Up:
		case TileType.Aiguillage_Right_Up:
		case TileType.Aiguillage_Right_Up_Open:
		case TileType.Aiguillage_Left_Up_Open:
			return true;
		default:
			return false;
		}
	}

	private static bool CellMatchesOnAnyLayer(Vector3Int cell, Func<TileType, bool> predicate)
	{
		LevelController instance = LevelController.Instance;
		if ((UnityEngine.Object)(object)instance == (UnityEngine.Object)null)
		{
			return false;
		}
		TileType tileTypeAt = instance.GetTileTypeAt(new Vector2Int(cell.x, cell.y));
		return predicate(tileTypeAt);
	}

	private static bool CellHasHardNeverSpawnOnAnyLayer(Vector3Int cell)
	{
		return CellMatchesOnAnyLayer(cell, IsTileTypeHardNeverSpawn);
	}
}
