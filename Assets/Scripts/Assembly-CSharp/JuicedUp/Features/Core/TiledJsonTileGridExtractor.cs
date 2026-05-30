using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public static class TiledJsonTileGridExtractor
	{
		private static readonly Regex SpawnLayerRegex;

		private static readonly Regex LdfWaveLayerRegex;

		public static bool TryExtract(string levelMapJson, TileDefinitionDatabase tileDb, out Dictionary<Vector3Int, TileType> tileTypes, out Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef, out int maxLayerIndex)
		{
			tileTypes = null;
			cellToDef = null;
			maxLayerIndex = default(int);
			return false;
		}

		private static void ProcessTileLayer(TiledLayer layer, int layerIndex, int tilesetStartIndex, TileDefinitionDatabase tileDb, Dictionary<Vector3Int, TileType> tileTypes, Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef)
		{
		}

		private static Vector3Int IndexToCell(int index, int width, int height)
		{
			return default(Vector3Int);
		}

		private static int ResolveTileId(uint rawGid, int tilesetStartIndex)
		{
			return 0;
		}
	}
}
