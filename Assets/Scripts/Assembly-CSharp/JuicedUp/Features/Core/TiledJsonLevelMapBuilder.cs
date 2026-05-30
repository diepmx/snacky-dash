using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TiledJsonLevelMapBuilder : ILevelMapBuilder
	{
		private readonly struct PendingCrossRoadCover
		{
			public readonly Vector3Int CellKey;

			public readonly Vector3 CoverWorldPosition;

			public readonly TileDefinitionDatabase.Entry TileDefinition;

			public readonly Vector2Int GroundCell;

			public PendingCrossRoadCover(Vector3Int cellKey, Vector3 coverWorldPosition, TileDefinitionDatabase.Entry tileDefinition, Vector2Int groundCell)
			{
				CellKey = default(Vector3Int);
				CoverWorldPosition = default(Vector3);
				TileDefinition = null;
				GroundCell = default(Vector2Int);
			}
		}

		private const int SpawnTileIdMin = 371;

		private const int SpawnTileIdMax = 377;

		private readonly Regex _spawnLayerRegex;

		private readonly Regex _ldfWaveLayerRegex;

		private readonly string _levelMapJson;

		public TiledJsonLevelMapBuilder(string levelMapJson)
		{
		}

		public void Build(LevelTilemapMapping mapping)
		{
		}

		private TiledMapData TryDeserializeMapData()
		{
			return null;
		}

		private static Vector3Int IndexToCell(int index, int width, int height)
		{
			return default(Vector3Int);
		}

		private bool TryProcessLdfWaveLayer(string layerName, TiledLayer tiledLayer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			return false;
		}

		private void ProcessLdfWaveLayer(TiledLayer tiledLayer, int ldfLayerIndex, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
		}

		private static int ResolveTileId(uint rawGid, int tilesetStartIndex)
		{
			return 0;
		}

		private static void SpawnDeferredCrossRoadCovers(List<PendingCrossRoadCover> pending, HashSet<Vector2Int> regularBridgeXyCells, LevelTilemapMapping mapping)
		{
		}

		private List<(Vector3Int, int)> ProcessSpawnLayer(TiledLayer layer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			return null;
		}

		private static void ProcessTileLayer(TiledLayer layer, string layerName, int layerIndex, int tilesetStartIndex, LevelTilemapMapping mapping, Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef, Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell, Dictionary<Vector2Int, bool?> spawnOverlayByCell, HashSet<int> crateIndicesFromJson, Dictionary<int, Vector2Int> crateCellsByIndex, List<(Vector3Int cell, int crateIndex)> crateSpawnEntries, HashSet<Vector2Int> regularBridgeXyCells, List<PendingCrossRoadCover> pendingCrossRoadCovers)
		{
		}

		private static FixedSpawnPlan BuildFixedSpawnPlan(Dictionary<int, List<(Vector3Int cell, int tileId)>> spawnLayerEntries, Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell, LevelTilemapMapping mapping)
		{
			return null;
		}

		private static (int, int, int, int) CalculatePlayableBounds(Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell)
		{
			return default((int, int, int, int));
		}

		private static void SpawnCrateObjects(List<(Vector3Int cell, int crateIndex)> crateSpawnEntries, Dictionary<int, Vector2Int> crateCellsByIndex, (int minX, int maxX, int minY, int maxY) bounds, LevelTilemapMapping mapping)
		{
		}
	}
}
