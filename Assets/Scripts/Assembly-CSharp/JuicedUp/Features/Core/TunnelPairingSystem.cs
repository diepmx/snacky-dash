using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	public class TunnelPairingSystem
	{
		private readonly TileDefinitionDatabase _tileDatabase;

		private readonly bool _logMissingTileDefinitions;

		private readonly Dictionary<int, List<Vector3Int>> _tunnelCellsByIndex;

		private readonly Dictionary<Vector3Int, Vector3Int> _tunnelPairByCell;

		private Tilemap _tilemapGround;

		public IReadOnlyDictionary<Vector3Int, Vector3Int> PairByCell => null;

		public TunnelPairingSystem(TileDefinitionDatabase tileDatabase, bool logMissingTileDefinitions)
		{
		}

		public void Build(Tilemap tilemapGround)
		{
		}

		private void Clear()
		{
		}

		public Vector3Int FindMatchingTunnelTile(Vector3Int currentCell)
		{
			return default(Vector3Int);
		}

		public bool TryGetTunnelDirection(Vector3Int cell, out DirectionPlayer direction)
		{
			direction = default(DirectionPlayer);
			return false;
		}

		private void BuildPairs()
		{
		}
	}
}
