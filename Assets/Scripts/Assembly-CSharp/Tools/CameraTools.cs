using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tools
{
	public class CameraTools
	{
		public static bool TryGetLevelBoundsWorld(Tilemap tilemapGround, Dictionary<Vector3Int, TileType> tileTypes, out Bounds worldBounds)
		{
			worldBounds = default(Bounds);
			return false;
		}
	}
}
