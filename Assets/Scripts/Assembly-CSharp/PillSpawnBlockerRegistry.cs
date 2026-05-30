using System.Collections.Generic;
using UnityEngine;

public static class PillSpawnBlockerRegistry
{
	private static readonly HashSet<Vector2Int> BlockerAndAdjacentCells;

	private static readonly HashSet<Vector2Int> ClearedBlockerCells;

	public static bool IsBlockerOrAdjacentCell(Vector3Int cell)
	{
		return false;
	}

	public static bool IsBlockerCleared(Vector3Int cell)
	{
		return false;
	}

	public static void AddBlockerCell(Vector2Int cell)
	{
	}

	public static void MarkBlockerCleared(Vector2Int cell)
	{
	}

	public static void Clear()
	{
	}
}
