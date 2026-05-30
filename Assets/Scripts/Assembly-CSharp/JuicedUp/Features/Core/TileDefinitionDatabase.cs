using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(menuName = "Game/Tiles/Tile Definition Database", fileName = "TileDefinitionDatabase")]
	public class TileDefinitionDatabase : ScriptableObject
	{
		[Serializable]
		public class Entry
		{
			public string name;

			public int tiledId;

			public TileBase tile;

			public TileType tileType;

			public TileCategory category;

			[Tooltip("Resources path (no extension), e.g. TilesCovers/TileCov_Border_D")]
			public string coverPrefabResourcePath;

			public bool spawnOverlayTunnelBoosterTile;

			public int deliverPointIndex;

			[Header("Settings for Tunnels tiles")]
			public DirectionPlayer tunnelDirection;

			public float tunnelZRotation;

			public int tunnelIndex;

			[Header("Settings for Arrows tiles")]
			public bool arrowIsFixed;

			public bool arrowIsUnique;

			public int arrowGroupId;

			public ArrowDirection arrowDirection;

			public bool IsSwitchableBridge => false;

			public bool IsSwitch => false;

			public bool IsSwitchVisual => false;

			public bool IsTurnout => false;

			public bool IsDestructibleWall => false;

			public bool IsCorridorRoadBlock => false;

			public bool IsTunnel => false;

			public bool IsArrow => false;

			public bool IsDeliverPoint => false;

			public bool IsGrass => false;

			public bool IsPath => false;

			public bool IsPrioritySpawnPoint => false;
		}

		[SerializeField]
		private List<Entry> entries;

		private Dictionary<TileBase, Entry> _byTile;

		private Dictionary<TileType, Entry> _primaryByType;

		public IReadOnlyList<Entry> Entries => null;

		private void OnEnable()
		{
		}

		public bool TryGetTunnelIndex(TileBase tile, out int tunnelIndex)
		{
			tunnelIndex = default(int);
			return false;
		}

		public bool TryGet(TileBase tile, out Entry entry)
		{
			entry = null;
			return false;
		}

		public bool TryGetPrimary(TileType type, out Entry entry)
		{
			entry = null;
			return false;
		}

		private void Rebuild()
		{
		}
	}
}
