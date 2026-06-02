using System.Collections.Generic;
using UnityEngine;

public static class PillSpawnBlockerRegistry
{
	private static readonly HashSet<Vector2Int> BlockerAndAdjacentCells = new HashSet<Vector2Int>();

	private static readonly HashSet<Vector2Int> ClearedBlockerCells = new HashSet<Vector2Int>();

	public static bool IsBlockerOrAdjacentCell(Vector3Int cell)
	{
		return BlockerAndAdjacentCells.Contains(new Vector2Int(cell.x, cell.y));
	}

	public static bool IsBlockerCleared(Vector3Int cell)
	{
		return ClearedBlockerCells.Contains(new Vector2Int(cell.x, cell.y));
	}

	public static void AddBlockerCell(Vector2Int cell)
	{
		BlockerAndAdjacentCells.Add(cell);
	}

	public static void MarkBlockerCleared(Vector2Int cell)
	{
		ClearedBlockerCells.Add(cell);
		BlockerAndAdjacentCells.Remove(cell);
	}

	public static void Clear()
	{
		BlockerAndAdjacentCells.Clear();
		ClearedBlockerCells.Clear();
	}
}
