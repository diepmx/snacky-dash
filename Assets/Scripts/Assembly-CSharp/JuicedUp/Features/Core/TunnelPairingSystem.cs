using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Scans the ground tilemap for all tunnel tiles and pairs them by tunnel index
	/// (from TileDefinitionDatabase.Entry.tunnelIndex).
	///
	/// Two tunnel tiles with the same tunnelIndex form a pair: entering one teleports
	/// the snake to the other.
	/// </summary>
	public class TunnelPairingSystem
	{
		private readonly TileDefinitionDatabase _tileDatabase;
		private readonly bool _logMissingTileDefinitions;

		// tunnelIndex → list of cells that share that index
		private readonly Dictionary<int, List<Vector3Int>> _tunnelCellsByIndex
			= new Dictionary<int, List<Vector3Int>>();

		// entrance cell → paired exit cell (bidirectional)
		private readonly Dictionary<Vector3Int, Vector3Int> _tunnelPairByCell
			= new Dictionary<Vector3Int, Vector3Int>();

		// entrance cell → direction the snake should exit in
		private readonly Dictionary<Vector3Int, DirectionPlayer> _tunnelDirectionByCell
			= new Dictionary<Vector3Int, DirectionPlayer>();

		private Tilemap _tilemapGround;

		public IReadOnlyDictionary<Vector3Int, Vector3Int> PairByCell => _tunnelPairByCell;

		public TunnelPairingSystem(TileDefinitionDatabase tileDatabase, bool logMissingTileDefinitions)
		{
			_tileDatabase = tileDatabase;
			_logMissingTileDefinitions = logMissingTileDefinitions;
		}

		/// <summary>
		/// Scan the tilemap and build all tunnel pairs. Call once after the level tilemap is loaded.
		/// </summary>
		public void Build(Tilemap tilemapGround)
		{
			_tilemapGround = tilemapGround;
			Clear();

			if (tilemapGround == null || _tileDatabase == null) return;

			// Iterate every cell in the tilemap bounds
			BoundsInt bounds = tilemapGround.cellBounds;
			foreach (Vector3Int cell in bounds.allPositionsWithin)
			{
				TileBase tile = tilemapGround.GetTile(cell);
				if (tile == null) continue;

				if (!_tileDatabase.TryGet(tile, out TileDefinitionDatabase.Entry entry))
				{
					if (_logMissingTileDefinitions)
						Debug.LogWarning($"[TunnelPairingSystem] No DB entry for tile '{tile.name}' at {cell}");
					continue;
				}

				if (!entry.IsTunnel) continue;

				int idx = entry.tunnelIndex;
				if (!_tunnelCellsByIndex.TryGetValue(idx, out List<Vector3Int> list))
				{
					list = new List<Vector3Int>(2);
					_tunnelCellsByIndex[idx] = list;
				}
				list.Add(cell);

				// Store exit direction per cell
				_tunnelDirectionByCell[cell] = entry.tunnelDirection;
			}

			BuildPairs();
		}

		private void Clear()
		{
			_tunnelCellsByIndex.Clear();
			_tunnelPairByCell.Clear();
			_tunnelDirectionByCell.Clear();
		}

		/// <summary>
		/// Given the cell the snake is entering, returns the paired exit cell.
		/// Returns Vector3Int.zero if no pair found.
		/// </summary>
		public Vector3Int FindMatchingTunnelTile(Vector3Int currentCell)
		{
			if (_tunnelPairByCell.TryGetValue(currentCell, out Vector3Int exitCell))
				return exitCell;

			return Vector3Int.zero;
		}

		/// <summary>
		/// Returns the exit direction for a given tunnel entrance cell.
		/// </summary>
		public bool TryGetTunnelDirection(Vector3Int cell, out DirectionPlayer direction)
		{
			return _tunnelDirectionByCell.TryGetValue(cell, out direction);
		}

		/// <summary>
		/// Build bidirectional pair mappings from the grouped cells.
		/// For each tunnelIndex that has exactly 2 cells, link them as a pair.
		/// </summary>
		private void BuildPairs()
		{
			foreach (KeyValuePair<int, List<Vector3Int>> entry in _tunnelCellsByIndex)
			{
				List<Vector3Int> cells = entry.Value;
				if (cells.Count != 2)
				{
					if (_logMissingTileDefinitions)
						Debug.LogWarning($"[TunnelPairingSystem] Tunnel index {entry.Key} has {cells.Count} cells (expected 2). Skipping.");
					continue;
				}

				// Link A → B and B → A
				_tunnelPairByCell[cells[0]] = cells[1];
				_tunnelPairByCell[cells[1]] = cells[0];
			}
		}
	}
}
