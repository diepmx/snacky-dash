using System;
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

		private readonly Regex _spawnLayerRegex;

		private readonly Regex _ldfWaveLayerRegex;

		private readonly string _levelMapJson;

		public TiledJsonLevelMapBuilder(string levelMapJson)
		{
			_levelMapJson = levelMapJson;
			_spawnLayerRegex = new Regex("^spawn\\d*$", RegexOptions.IgnoreCase);
			_ldfWaveLayerRegex = new Regex("^ldf_wave_(\\d+)$", RegexOptions.IgnoreCase);
		}

		public void Build(LevelTilemapMapping mapping)
		{
			TiledMapData tiledMapData = TryDeserializeMapData();
			if (tiledMapData == null || tiledMapData.Layers == null)
			{
				Debug.LogError("[TiledJsonLevelMapBuilder] Failed to deserialize map JSON.");
				return;
			}
			int tilesetStartIndex = 1;
			if (tiledMapData.Tilesets != null && tiledMapData.Tilesets.Length != 0)
			{
				tilesetStartIndex = Mathf.Max(1, tiledMapData.Tilesets[0].TileMapStartIndex);
			}
			Dictionary<int, List<(Vector3Int, int)>> dictionary = new Dictionary<int, List<(Vector3Int, int)>>();
			Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell = new Dictionary<Vector2Int, TileDefinitionDatabase.Entry>();
			Dictionary<Vector2Int, bool?> spawnOverlayByCell = new Dictionary<Vector2Int, bool?>();
			Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef = new Dictionary<Vector3Int, TileDefinitionDatabase.Entry>();
			HashSet<int> crateIndicesFromJson = new HashSet<int>();
			Dictionary<int, Vector2Int> crateCellsByIndex = new Dictionary<int, Vector2Int>();
			List<(Vector3Int, int)> crateSpawnEntries = new List<(Vector3Int, int)>();
			HashSet<Vector2Int> regularBridgeXyCells = new HashSet<Vector2Int>();
			List<PendingCrossRoadCover> list = new List<PendingCrossRoadCover>();
			int num = 0;
			TiledLayer[] layers = tiledMapData.Layers;
			foreach (TiledLayer tiledLayer in layers)
			{
				if (tiledLayer == null || tiledLayer.Data == null)
				{
					continue;
				}
				string text = tiledLayer.Name ?? string.Empty;
				if (_spawnLayerRegex.IsMatch(text))
				{
					int key = 0;
					Match match = Regex.Match(text, "\\d+$");
					if (match.Success)
					{
						key = Mathf.Max(0, int.Parse(match.Value) - 1);
					}
					List<(Vector3Int, int)> list2 = ProcessSpawnLayer(tiledLayer, tilesetStartIndex, mapping);
					if (list2 != null)
					{
						if (!dictionary.ContainsKey(key))
						{
							dictionary[key] = new List<(Vector3Int, int)>();
						}
						dictionary[key].AddRange(list2);
					}
				}
				else if (!TryProcessLdfWaveLayer(text, tiledLayer, tilesetStartIndex, mapping))
				{
					ProcessTileLayer(tiledLayer, text, num, tilesetStartIndex, mapping, cellToDef, baseTileByCell, spawnOverlayByCell, crateIndicesFromJson, crateCellsByIndex, crateSpawnEntries, regularBridgeXyCells, list);
					num++;
				}
			}
			mapping.ApplyWinningTilesToTilemap(cellToDef);
			mapping.BuildTunnelPairsFromWinningLayers(cellToDef);
			mapping.SpawnPillsFromEligibility(baseTileByCell, spawnOverlayByCell);
			if (dictionary.Count > 0)
			{
				FixedSpawnPlan fixedSpawnPlan = BuildFixedSpawnPlan(dictionary, baseTileByCell, mapping);
				if (fixedSpawnPlan != null && (UnityEngine.Object)(object)LevelController.Instance != (UnityEngine.Object)null)
				{
					LevelController.Instance.SetFixedSpawnPlan(fixedSpawnPlan);
					HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
					foreach (KeyValuePair<int, List<(Vector3Int, int)>> item2 in dictionary)
					{
						foreach (var item3 in item2.Value)
						{
							Vector3Int item = item3.Item1;
							hashSet.Add(new Vector2Int(item.x, item.y));
						}
					}
					LevelController.Instance.SetPriorityPillSpawnCells(hashSet);
				}
			}
			SpawnDeferredCrossRoadCovers(list, regularBridgeXyCells, mapping);
			(int, int, int, int) bounds = CalculatePlayableBounds(baseTileByCell);
			SpawnCrateObjects(crateSpawnEntries, crateCellsByIndex, bounds, mapping);
		}

		private TiledMapData TryDeserializeMapData()
		{
			if (string.IsNullOrEmpty(_levelMapJson))
			{
				return null;
			}
			try
			{
				return JsonConvert.DeserializeObject<TiledMapData>(_levelMapJson);
			}
			catch (Exception ex)
			{
				Debug.LogError("[TiledJsonLevelMapBuilder] JSON parse error: " + ex.Message);
				return null;
			}
		}

		private static Vector3Int IndexToCell(int index, int width, int height)
		{
			int num = index % width;
			int num2 = index / width;
			return new Vector3Int(num, height - 1 - num2, 0);
		}

		private bool TryProcessLdfWaveLayer(string layerName, TiledLayer tiledLayer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			Match match = _ldfWaveLayerRegex.Match(layerName);
			if (!match.Success)
			{
				return false;
			}
			if (!int.TryParse(match.Groups[1].Value, out var result))
			{
				return false;
			}
			ProcessLdfWaveLayer(tiledLayer, result, tilesetStartIndex, mapping);
			return true;
		}

		private void ProcessLdfWaveLayer(TiledLayer tiledLayer, int ldfLayerIndex, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			if (tiledLayer?.Data == null)
			{
				return;
			}
			int width = tiledLayer.Width;
			int height = tiledLayer.Height;
			for (int i = 0; i < tiledLayer.Data.Length; i++)
			{
				int num = ResolveTileId(tiledLayer.Data[i], tilesetStartIndex);
				if (num > 0)
				{
					Vector3Int val = IndexToCell(i, width, height);
					if (mapping.LdfAdjacentCells != null)
					{
						mapping.LdfAdjacentCells.Add(new Vector2Int(val.x, val.y));
					}
				}
			}
		}

		private static int ResolveTileId(uint rawGid, int tilesetStartIndex)
		{
			if (rawGid == 0)
			{
				return 0;
			}
			uint num = TiledLayer.StripFlipFlags(rawGid);
			int num2 = (int)num - tilesetStartIndex;
			return (num2 >= 0) ? num2 : 0;
		}

		private static void SpawnDeferredCrossRoadCovers(List<PendingCrossRoadCover> pending, HashSet<Vector2Int> regularBridgeXyCells, LevelTilemapMapping mapping)
		{
			if (pending == null || pending.Count == 0)
			{
				return;
			}
			foreach (PendingCrossRoadCover item in pending)
			{
				if (!regularBridgeXyCells.Contains(item.GroundCell))
				{
					mapping.TrySpawnCover(item.CellKey, item.CoverWorldPosition, item.TileDefinition);
				}
			}
		}

		private List<(Vector3Int, int)> ProcessSpawnLayer(TiledLayer layer, int tilesetStartIndex, LevelTilemapMapping mapping)
		{
			if (layer?.Data == null)
			{
				return null;
			}
			int width = layer.Width;
			int height = layer.Height;
			List<(Vector3Int, int)> list = new List<(Vector3Int, int)>();
			for (int i = 0; i < layer.Data.Length; i++)
			{
				int num = ResolveTileId(layer.Data[i], tilesetStartIndex);
				if (num > 0)
				{
					Vector3Int item = IndexToCell(i, width, height);
					if (num >= 371 && num <= 377)
					{
						list.Add((item, num));
					}
				}
			}
			return list;
		}

		private static void ProcessTileLayer(TiledLayer layer, string layerName, int layerIndex, int tilesetStartIndex, LevelTilemapMapping mapping, Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef, Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell, Dictionary<Vector2Int, bool?> spawnOverlayByCell, HashSet<int> crateIndicesFromJson, Dictionary<int, Vector2Int> crateCellsByIndex, List<(Vector3Int cell, int crateIndex)> crateSpawnEntries, HashSet<Vector2Int> regularBridgeXyCells, List<PendingCrossRoadCover> pendingCrossRoadCovers)
		{
			if (layer?.Data == null)
			{
				return;
			}
			int width = layer.Width;
			int height = layer.Height;
			for (int i = 0; i < layer.Data.Length; i++)
			{
				int num = ResolveTileId(layer.Data[i], tilesetStartIndex);
				if (num > 0)
				{
					Vector3Int key = IndexToCell(i, width, height);
					if (layerIndex == 0 && mapping.TileTypes != null && !mapping.TileTypes.ContainsKey(key))
					{
						mapping.TileTypes[key] = TileType.Empty;
					}
				}
			}
		}

		private static FixedSpawnPlan BuildFixedSpawnPlan(Dictionary<int, List<(Vector3Int cell, int tileId)>> spawnLayerEntries, Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell, LevelTilemapMapping mapping)
		{
			List<FixedSpawnLayer> list = new List<FixedSpawnLayer>();
			List<int> list2 = new List<int>(spawnLayerEntries.Keys);
			list2.Sort();
			foreach (int item in list2)
			{
				List<(Vector3Int, int)> list3 = spawnLayerEntries[item];
				List<(Vector3Int, int)> list4 = new List<(Vector3Int, int)>();
				foreach (var item2 in list3)
				{
					if (item2.Item2 >= 371 && item2.Item2 <= 377)
					{
						list4.Add(item2);
					}
				}
				if (list4.Count > 0)
				{
					list.Add(new FixedSpawnLayer(item, list4));
				}
			}
			return new FixedSpawnPlan(list);
		}

		private static (int minX, int maxX, int minY, int maxY) CalculatePlayableBounds(Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell)
		{
			if (baseTileByCell == null || baseTileByCell.Count == 0)
			{
				return (minX: 0, maxX: 0, minY: 0, maxY: 0);
			}
			int num = int.MaxValue;
			int num2 = int.MinValue;
			int num3 = int.MaxValue;
			int num4 = int.MinValue;
			foreach (Vector2Int key in baseTileByCell.Keys)
			{
				Vector2Int current = key;
				if (current.x < num) num = current.x;
				if (current.x > num2) num2 = current.x;
				if (current.y < num3) num3 = current.y;
				if (current.y > num4) num4 = current.y;
			}
			return (minX: num, maxX: num2, minY: num3, maxY: num4);
		}

		private static void SpawnCrateObjects(List<(Vector3Int cell, int crateIndex)> crateSpawnEntries, Dictionary<int, Vector2Int> crateCellsByIndex, (int minX, int maxX, int minY, int maxY) bounds, LevelTilemapMapping mapping)
		{
			if (crateSpawnEntries == null || crateSpawnEntries.Count == 0)
			{
				return;
			}
			foreach (var crateSpawnEntry in crateSpawnEntries)
			{
				if (!((UnityEngine.Object)(object)mapping.PositionCratesPrefab == (UnityEngine.Object)null))
				{
					Vector3Int val = crateSpawnEntry.cell;
					Vector3 worldPos = new Vector3(val.x, val.y, 0f);
					LevelTilemapMapping.GetCrateSpawnOffsetAndRotation(crateSpawnEntry.crateIndex, new Vector2Int(val.x, val.y), crateCellsByIndex, bounds.minX, bounds.maxX, bounds.minY, bounds.maxY, out var offset, out var rotation);
					if ((UnityEngine.Object)(object)mapping.PositionCratesParent != (UnityEngine.Object)null)
					{
						GameObject val3 = UnityEngine.Object.Instantiate<GameObject>(mapping.PositionCratesPrefab, worldPos + offset, rotation, mapping.PositionCratesParent);
						((UnityEngine.Object)val3).name = $"Crate_{crateSpawnEntry.crateIndex}";
					}
				}
			}
		}
	}
}
