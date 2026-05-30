using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public static class DestructibleWallPathCellResolver
	{
		public static bool IsCorridorRoadBlock(TileDefinitionDatabase.Entry definition)
		{
			return false;
		}

		public static void FillPathUnderDestructibleWall(IReadOnlyDictionary<Vector3Int, TileType> tileTypes, IReadOnlyDictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef, int maxLayerIndex, Dictionary<Vector2Int, TileType> pathUnderDestructibleWall, Action<Vector2Int> onDestructibleWallBlocker = null)
		{
		}
	}
}
