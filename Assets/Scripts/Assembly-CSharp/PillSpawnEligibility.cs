using System;
using JuicedUp.Features.Core;
using UnityEngine;

public static class PillSpawnEligibility
{
	// ---------------------------------------------------------------
	// Public API – called by RespawnScheduler & TiledJsonLevelMapBuilder
	// ---------------------------------------------------------------

	public static bool IsCellEligibleForInitialSpawn(
		Vector3Int cell,
		TileType baseTileType,
		bool? spawnOverlayAllow = null,
		bool risingBlockActivated = false,
		bool blockerCleared = true)
	{
		if (!blockerCleared) return false;
		if (IsTileTypeHardNeverSpawn(baseTileType)) return false;
		if (IsTileTypeNeverSpawn(baseTileType)) return false;
		if (risingBlockActivated && IsRisingBlockRestrictedType(baseTileType)) return false;
		// spawnOverlayAllow: null means no overlay constraint, false means blocked
		if (spawnOverlayAllow.HasValue && !spawnOverlayAllow.Value) return false;
		if (IsCellBlockedByAnyLayer(cell)) return false;
		return true;
	}

	public static bool IsCellBlockedByAnyLayer(Vector3Int cell)
	{
		// Queries the PillSpawnBlockerRegistry which tracks runtime blockers
		// (rising blocks, destructible walls, etc.)
		// A cell is blocked if it's a blocker/adjacent cell AND hasn't been cleared yet
		return PillSpawnBlockerRegistry.IsBlockerOrAdjacentCell(cell)
		       && !PillSpawnBlockerRegistry.IsBlockerCleared(cell);
	}

	public static bool IsCellEligibleForRespawnSlot(Vector3Int cell, PillSpawnRelaxationTier tier)
	{
		LevelController lc = LevelController.Instance;
		if (lc == null) return false;

		TileType tileType = lc.GetTileTypeAt(new Vector2Int(cell.x, cell.y));

		// Hard-never cells are ALWAYS rejected regardless of tier
		if (IsTileTypeHardNeverSpawn(tileType)) return false;

		switch (tier)
		{
			case PillSpawnRelaxationTier.Strict:
				// Only true spawn-eligible road tiles
				return IsStrictEligible(tileType);

			case PillSpawnRelaxationTier.RelaxNoSpawnMarker:
				// Also allow tiles that are normally marked NoPill
				return IsStrictEligible(tileType) || tileType == TileType.RoadRightLeftNoPill || tileType == TileType.RoadUpDownNoPill;

			case PillSpawnRelaxationTier.RelaxDeliverPoints:
				// Allow Stop/Crate tiles too
				return IsStrictEligible(tileType)
					   || tileType == TileType.RoadRightLeftNoPill
					   || tileType == TileType.RoadUpDownNoPill
					   || tileType == TileType.Stop
					   || tileType == TileType.Stop_CRATE
					   || tileType == TileType.Stop_CRATE_0
					   || tileType == TileType.Stop_CRATE_1
					   || tileType == TileType.Stop_CRATE_2;

			case PillSpawnRelaxationTier.RelaxBridges:
				// Allow bridge-adjacent non-Hard cells
				return !IsTileTypeHardNeverSpawn(tileType) && tileType != TileType.Tunnel;

			case PillSpawnRelaxationTier.RelaxKnots:
				// Most permissive: allow anything except Hard-never and Tunnel
				return !IsTileTypeHardNeverSpawn(tileType) && tileType != TileType.Tunnel;

			default:
				return IsStrictEligible(tileType);
		}
	}

	// ---------------------------------------------------------------
	// Private helpers
	// ---------------------------------------------------------------

	private static int MaxTileZInclusive()
	{
		// The spawn system considers all cells at any Z layer
		return 0;
	}

	private static bool IsCellNeverSpawnByTileType(Vector3Int cell)
	{
		LevelController lc = LevelController.Instance;
		if (lc == null) return false;
		TileType t = lc.GetTileTypeAt(new Vector2Int(cell.x, cell.y));
		return IsTileTypeNeverSpawn(t) || IsTileTypeHardNeverSpawn(t);
	}

	private static bool IsTileTypeNeverSpawn(TileType tileType)
	{
		// Soft never-spawn: the game avoids spawning here but may relax this constraint
		return tileType == TileType.NonPillSpawnPlace;
	}

	private static bool IsTileTypeHardNeverSpawn(TileType tileType)
	{
		// Hard never-spawn: never used regardless of relaxation tier
		switch (tileType)
		{
			case TileType.Empty:
			case TileType.Wall:
			case TileType.Contour:
			case TileType.Plot:
			case TileType.Tunnel:
			case TileType.Enemy:
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
		// When rising blocks are active, these additional types are blocked
		return tileType == TileType.RoadRightLeftNoPill
			   || tileType == TileType.RoadUpDownNoPill
			   || tileType == TileType.NonPillSpawnPlace;
	}

	/// <summary>
	/// Core "strict" eligible set: only proper road / path tiles that allow pills.
	/// </summary>
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
			case TileType.FixedArrowLeft:
			case TileType.FixedArrowRight:
			case TileType.FixedArrowDown:
			case TileType.FixedArrowUp:
			case TileType.PillSpawnPoint:
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
			case TileType.RoadRightLeft_DestructibleWall:
			case TileType.RoadUpDown_DestructibleWall:
				return true;
			default:
				return false;
		}
	}

	private static bool CellMatchesOnAnyLayer(Vector3Int cell, Func<TileType, bool> predicate)
	{
		LevelController lc = LevelController.Instance;
		if (lc == null) return false;
		TileType t = lc.GetTileTypeAt(new Vector2Int(cell.x, cell.y));
		return predicate(t);
	}

	private static bool CellHasHardNeverSpawnOnAnyLayer(Vector3Int cell)
	{
		return CellMatchesOnAnyLayer(cell, IsTileTypeHardNeverSpawn);
	}
}
