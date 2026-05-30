using System;
using JuicedUp.Features.Core;
using UnityEngine;

public static class PillSpawnEligibility
{
	public static bool IsCellEligibleForInitialSpawn(Vector3Int cell, TileType baseTileType, bool? spawnOverlayAllow = null, bool risingBlockActivated = false, bool blockerCleared = true)
	{
		return false;
	}

	public static bool IsCellBlockedByAnyLayer(Vector3Int cell)
	{
		return false;
	}

	private static int MaxTileZInclusive()
	{
		return 0;
	}

	private static bool IsCellNeverSpawnByTileType(Vector3Int cell)
	{
		return false;
	}

	private static bool IsTileTypeNeverSpawn(TileType tileType)
	{
		return false;
	}

	private static bool IsTileTypeHardNeverSpawn(TileType tileType)
	{
		return false;
	}

	public static bool IsCellEligibleForRespawnSlot(Vector3Int cell, PillSpawnRelaxationTier tier)
	{
		return false;
	}

	private static bool CellMatchesOnAnyLayer(Vector3Int cell, Func<TileType, bool> predicate)
	{
		return false;
	}

	private static bool CellHasHardNeverSpawnOnAnyLayer(Vector3Int cell)
	{
		return false;
	}
}
