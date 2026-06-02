using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
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
				CellKey = cellKey;
				CoverWorldPosition = coverWorldPosition;
				TileDefinition = tileDefinition;
				GroundCell = groundCell;
			}
		}

		private const int SpawnTileIdMin = 371;

		private const int SpawnTileIdMax = 377;

		// Layer name regex: "spawn" or "spawn1", "spawn2", ...
		private readonly Regex _spawnLayerRegex;

		// Layer name regex: "ldf_wave_1", "ldf_wave_2", ...
		private readonly Regex _ldfWaveLayerRegex;

		private readonly string _levelMapJson;

		public TiledJsonLevelMapBuilder(string levelMapJson)
		{
			_levelMapJson = levelMapJson;
			_spawnLayerRegex = new Regex(@"^spawn\d*$", RegexOptions.IgnoreCase);
			_ldfWaveLayerRegex = new Regex(@"^ldf_wave_(\d+)$", RegexOptions.IgnoreCase);
		}

		public void Build(LevelTilemapMapping mapping)
		{
			TiledMapData mapData = TryDeserializeMapData();
			if (mapData == null || mapData.Layers == null)
			{
				Debug.LogError("[TiledJsonLevelMapBuilder] Failed to deserialize map JSON.");
				return;
			}

			int tilesetStartIndex = 1;
			if (mapData.Tilesets != null && mapData.Tilesets.Length > 0)
				tilesetStartIndex = Mathf.Max(1, mapData.Tilesets[0].TileMapStartIndex);

			// spawnLayerIndex → list of (cell, tileId)
			var spawnLayerEntries = new Dictionary<int, List<(Vector3Int cell, int tileId)>>();

			var baseTileByCell    = new Dictionary<Vector2Int, TileDefinitionDatabase.Entry>();
			var spawnOverlayByCell = new Dictionary<Vector2Int, bool?>();
			var cellToDef          = new Dictionary<Vector3Int, TileDefinitionDatabase.Entry>();

			var crateIndicesFromJson    = new HashSet<int>();
			var crateCellsByIndex       = new Dictionary<int, Vector2Int>();
			var crateSpawnEntries       = new List<(Vector3Int cell, int crateIndex)>();
			var regularBridgeXyCells    = new HashSet<Vector2Int>();
			var pendingCrossRoadCovers  = new List<PendingCrossRoadCover>();

			int layerIndex = 0;
			foreach (TiledLayer layer in mapData.Layers)
			{
				if (layer == null || layer.Data == null) continue;

				string layerName = layer.Name ?? string.Empty;

				// ── spawn layer ───────────────────────────────────────────
				if (_spawnLayerRegex.IsMatch(layerName))
				{
					int batchIndex = 0;
					Match m = Regex.Match(layerName, @"\d+$");
					if (m.Success) batchIndex = Mathf.Max(0, int.Parse(m.Value) - 1);

					List<(Vector3Int, int)> entries = ProcessSpawnLayer(layer, tilesetStartIndex, mapping);
					if (entries != null)
					{
						if (!spawnLayerEntries.ContainsKey(batchIndex))
							spawnLayerEntries[batchIndex] = new List<(Vector3Int, int)>();
						spawnLayerEntries[batchIndex].AddRange(entries);
					}
					continue;
				}

				// ── ldf wave layer ────────────────────────────────────────
				if (TryProcessLdfWaveLayer(layerName, layer, tilesetStartIndex, mapping))
					continue;

				// ── regular tile layer ────────────────────────────────────
				ProcessTileLayer(
					layer, layerName, layerIndex, tilesetStartIndex, mapping,
					cellToDef, baseTileByCell, spawnOverlayByCell,
					crateIndicesFromJson, crateCellsByIndex, crateSpawnEntries,
					regularBridgeXyCells, pendingCrossRoadCovers);
				layerIndex++;
			}

			// Apply winning tile types
			mapping.ApplyWinningTilesToTilemap(cellToDef);

			// Build tunnel pairs
			mapping.BuildTunnelPairsFromWinningLayers(cellToDef);

			// Spawn pills from eligibility for non-fixed cells
			mapping.SpawnPillsFromEligibility(baseTileByCell, spawnOverlayByCell);

			// Build FixedSpawnPlan
			if (spawnLayerEntries.Count > 0)
			{
				FixedSpawnPlan plan = BuildFixedSpawnPlan(spawnLayerEntries, baseTileByCell, mapping);
				if (plan != null && LevelController.Instance != null)
				{
					LevelController.Instance.SetFixedSpawnPlan(plan);

					// Priority cells = all cells that appear in ANY spawn layer
					var priorityCells = new HashSet<Vector2Int>();
					foreach (var kv in spawnLayerEntries)
						foreach ((Vector3Int cell, int _) in kv.Value)
							priorityCells.Add(new Vector2Int(cell.x, cell.y));

					LevelController.Instance.SetPriorityPillSpawnCells(priorityCells);
				}
			}

			// Deferred cross-road covers
			SpawnDeferredCrossRoadCovers(pendingCrossRoadCovers, regularBridgeXyCells, mapping);

			// Crate objects
			var bounds = CalculatePlayableBounds(baseTileByCell);
			SpawnCrateObjects(crateSpawnEntries, crateCellsByIndex, bounds, mapping);
		}

		private TiledMapData TryDeserializeMapData()
		{
			if (string.IsNullOrEmpty(_levelMapJson)) return null;
			try
			{
				// Use Newtonsoft.Json (available via TiledLayer using directive)
				return JsonConvert.DeserializeObject<TiledMapData>(_levelMapJson);
			}
			catch (System.Exception e)
			{
				Debug.LogError("[TiledJsonLevelMapBuilder] JSON parse error: " + e.Message);
				return null;
			}
		}

		private static Vector3Int IndexToCell(int index, int width, int height)
		{
			int x = index % width;
			int y = index / width;
			// Tiled Y is top-down; Unity tilemap Y is bottom-up
			return new Vector3Int(x, height - 1 - y, 0);
		}

		private bool TryProcessLdfWaveLayer(string layerName, TiledLayer tiledLayer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			Match m = _ldfWaveLayerRegex.Match(layerName);
			if (!m.Success) return false;
			if (!int.TryParse(m.Groups[1].Value, out int ldfLayerIndex)) return false;
			ProcessLdfWaveLayer(tiledLayer, ldfLayerIndex, tilesetStartIndex, mapping);
			return true;
		}

		private void ProcessLdfWaveLayer(TiledLayer tiledLayer, int ldfLayerIndex, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			if (tiledLayer?.Data == null) return;
			int width  = tiledLayer.Width;
			int height = tiledLayer.Height;

			for (int i = 0; i < tiledLayer.Data.Length; i++)
			{
				int tileId = ResolveTileId(tiledLayer.Data[i], tilesetStartIndex);
				if (tileId <= 0) continue;
				Vector3Int cell = IndexToCell(i, width, height);
				if (mapping.LdfAdjacentCells != null)
					mapping.LdfAdjacentCells.Add(new Vector2Int(cell.x, cell.y));
			}
		}

		private static int ResolveTileId(uint rawGid, int tilesetStartIndex)
		{
			if (rawGid == 0) return 0;
			// Use TiledLayer.StripFlipFlags to remove Tiled flip/rotate bits
			uint cleanGid = TiledLayer.StripFlipFlags(rawGid);
			int localId = (int)cleanGid - tilesetStartIndex;
			return localId < 0 ? 0 : localId;
		}

		private static void SpawnDeferredCrossRoadCovers(List<PendingCrossRoadCover> pending, HashSet<Vector2Int> regularBridgeXyCells, LevelTilemapMapping mapping)
		{
			if (pending == null || pending.Count == 0) return;
			foreach (PendingCrossRoadCover p in pending)
			{
				if (regularBridgeXyCells.Contains(p.GroundCell)) continue;
				mapping.TrySpawnCover(p.CellKey, p.CoverWorldPosition, p.TileDefinition);
			}
		}

		private List<(Vector3Int, int)> ProcessSpawnLayer(TiledLayer layer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			if (layer?.Data == null) return null;
			int width  = layer.Width;
			int height = layer.Height;
			var result = new List<(Vector3Int, int)>();

			for (int i = 0; i < layer.Data.Length; i++)
			{
				int tileId = ResolveTileId(layer.Data[i], tilesetStartIndex);
				if (tileId <= 0) continue;
				Vector3Int cell = IndexToCell(i, width, height);

				// Fruit spawn tiles: 371..377
				if (tileId >= SpawnTileIdMin && tileId <= SpawnTileIdMax)
					result.Add((cell, tileId));
			}

			return result;
		}

		private static void ProcessTileLayer(
			TiledLayer layer, string layerName, int layerIndex, int tilesetStartIndex,
			LevelTilemapMapping mapping,
			Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef,
			Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell,
			Dictionary<Vector2Int, bool?> spawnOverlayByCell,
			HashSet<int> crateIndicesFromJson,
			Dictionary<int, Vector2Int> crateCellsByIndex,
			List<(Vector3Int cell, int crateIndex)> crateSpawnEntries,
			HashSet<Vector2Int> regularBridgeXyCells,
			List<PendingCrossRoadCover> pendingCrossRoadCovers)
		{
			if (layer?.Data == null) return;
			int width  = layer.Width;
			int height = layer.Height;

			for (int i = 0; i < layer.Data.Length; i++)
			{
				int tileId = ResolveTileId(layer.Data[i], tilesetStartIndex);
				if (tileId <= 0) continue;
				Vector3Int cell = IndexToCell(i, width, height);

				// Base layer builds the primary tile type map
				if (layerIndex == 0 && mapping.TileTypes != null)
				{
					if (!mapping.TileTypes.ContainsKey(cell))
						mapping.TileTypes[cell] = TileType.Empty;
				}
			}
		}

		private static FixedSpawnPlan BuildFixedSpawnPlan(
			Dictionary<int, List<(Vector3Int cell, int tileId)>> spawnLayerEntries,
			Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell,
			LevelTilemapMapping mapping)
		{
			var layers = new List<FixedSpawnLayer>();
			var sortedIndices = new List<int>(spawnLayerEntries.Keys);
			sortedIndices.Sort();

			foreach (int batchIndex in sortedIndices)
			{
				var rawEntries   = spawnLayerEntries[batchIndex];
				var validEntries = new List<(Vector3Int cell, int tileId)>();
				foreach ((Vector3Int cell, int tileId) entry in rawEntries)
				{
					if (entry.tileId >= 371 && entry.tileId <= 377)
						validEntries.Add(entry);
				}
				if (validEntries.Count > 0)
					layers.Add(new FixedSpawnLayer(batchIndex, validEntries));
			}

			return new FixedSpawnPlan(layers);
		}

		private static (int minX, int maxX, int minY, int maxY) CalculatePlayableBounds(
			Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell)
		{
			if (baseTileByCell == null || baseTileByCell.Count == 0)
				return (0, 0, 0, 0);

			int minX = int.MaxValue, maxX = int.MinValue;
			int minY = int.MaxValue, maxY = int.MinValue;
			foreach (Vector2Int cell in baseTileByCell.Keys)
			{
				if (cell.x < minX) minX = cell.x;
				if (cell.x > maxX) maxX = cell.x;
				if (cell.y < minY) minY = cell.y;
				if (cell.y > maxY) maxY = cell.y;
			}
			return (minX, maxX, minY, maxY);
		}

		private static void SpawnCrateObjects(
			List<(Vector3Int cell, int crateIndex)> crateSpawnEntries,
			Dictionary<int, Vector2Int> crateCellsByIndex,
			(int minX, int maxX, int minY, int maxY) bounds,
			LevelTilemapMapping mapping)
		{
			if (crateSpawnEntries == null || crateSpawnEntries.Count == 0) return;

			foreach ((Vector3Int cell, int crateIndex) entry in crateSpawnEntries)
			{
				if (mapping.PositionCratesPrefab == null) continue;

				Vector3 worldPos = new Vector3(entry.cell.x, entry.cell.y, 0f);
				LevelTilemapMapping.GetCrateSpawnOffsetAndRotation(
					entry.crateIndex,
					new Vector2Int(entry.cell.x, entry.cell.y),
					crateCellsByIndex,
					bounds.minX, bounds.maxX, bounds.minY, bounds.maxY,
					out Vector3 offset, out Quaternion rotation);

				if (mapping.PositionCratesParent != null)
				{
					GameObject crateGO = Object.Instantiate(
						mapping.PositionCratesPrefab,
						worldPos + offset,
						rotation,
						mapping.PositionCratesParent);
					crateGO.name = $"Crate_{entry.crateIndex}";
				}
			}
		}
	}
}
