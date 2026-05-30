using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelTilemapMapping
{
	private readonly List<MeshRenderer> _allGrassMeshDecor;

	private readonly List<MeshRenderer> _allRoadMeshDecor;

	private readonly ArrowGroupController _arrowGroupController;

	private readonly IAssetLoader _assetLoader;

	private readonly Transform _decorParent;

	private readonly bool _logMissingTileDefinitions;

	private readonly Transform _overlayTunnelRoot;

	private readonly GameObject _overlayTunnelTile;

	private readonly PillManager _pillManager;

	private readonly SnakeOccupancyManager _snakeOccupancy;

	private readonly LevelController _levelController;

	private readonly bool _strictTileDb;

	private readonly TailManager _tailManager;

	private readonly TileDefinitionDatabase _tileDb;

	private readonly TunnelPairingSystem _tunnelPairing;

	private readonly GameObject _positionCratesPrefab;

	private readonly Dictionary<Vector3Int, TileType> _tileTypes;

	private readonly Dictionary<Vector3Int, GameObject> _coverByCell;

	private readonly HashSet<Vector3Int> _corridorRoadBlockCoverCells;

	private readonly Dictionary<Vector3Int, GameObject> _extraByCell;

	private readonly Dictionary<int, List<Vector3Int>> _tunnelCellsByIndex;

	private readonly Dictionary<Vector3Int, Vector3Int> _tunnelPairByCell;

	private readonly Dictionary<Vector2Int, TileType> _winningTypeByPosition;

	private readonly Dictionary<Vector2Int, TileType> _pathUnderDestructibleWall;

	private readonly Dictionary<Vector2Int, int> _destructibleWallGroupByCell;

	private readonly Dictionary<Vector2Int, TileType> _pathGeometryUnderPlot;

	private readonly HashSet<Vector2Int> _bridgeAdjacentCells;

	private readonly HashSet<Vector2Int> _tunnelAdjacentCells;

	private readonly HashSet<Vector2Int> _ldfAdjacentCells;

	private readonly HashSet<Vector2Int> _priorityPillSpawnCells;

	private readonly List<HashSet<Vector2Int>> _secretCollectibleCells;

	private Level _level;

	private Tilemap _tilemapGround;

	private Transform _positionCratesParent;

	private SwitchController _switchController;

	private SwitchView _switchView;

	internal TileDefinitionDatabase TileDb => null;

	internal bool LogMissingTileDefinitions => false;

	internal Tilemap TilemapGround => null;

	internal Dictionary<Vector3Int, TileType> TileTypes => null;

	internal Dictionary<Vector3Int, GameObject> CoverByCell => null;

	internal HashSet<Vector2Int> BridgeAdjacentCells => null;

	internal HashSet<Vector2Int> TunnelAdjacentCells => null;

	internal HashSet<Vector2Int> LdfAdjacentCells => null;

	internal HashSet<Vector2Int> PriorityPillSpawnCells => null;

	internal List<HashSet<Vector2Int>> SecretCollectibleCells => null;

	internal PillManager PillManager => null;

	internal IAssetLoader AssetLoader => null;

	internal GameObject PositionCratesPrefab => null;

	internal Transform PositionCratesParent => null;

	internal List<MeshRenderer> AllGrassMeshDecor => null;

	internal List<MeshRenderer> AllRoadMeshDecor => null;

	internal int MaxLayerIndex { get; set; }

	public TunnelPairingSystem TunnelPairing => null;

	public IReadOnlyDictionary<Vector2Int, TileType> GetPathUnderDestructibleWall => null;

	public IReadOnlyDictionary<Vector2Int, int> DestructibleWallGroupByCell => null;

	public LevelTilemapMapping(TileDefinitionDatabase tileDb, bool strictTileDb, bool logMissingTileDefinitions, PillManager pillManager, Transform decorParent, Transform overlayTunnelRoot, GameObject overlayTunnelTile, Dictionary<Vector3Int, TileType> tileTypes, Dictionary<Vector3Int, GameObject> coverByCell, Dictionary<Vector3Int, GameObject> extraByCell, List<MeshRenderer> allGrassMeshDecor, List<MeshRenderer> allRoadMeshDecor, SnakeOccupancyManager snakeOccupancy, LevelController levelController, TailManager tailManager, ArrowGroupController arrowGroupController, IAssetLoader assetLoader, GameObject positionCratesPrefab)
	{
	}

	public void Bind(Level level, Tilemap tilemapGround)
	{
	}

	public void InitializeFromTilemap(LevelDataSO levelData)
	{
	}

	internal void ApplyWinningTilesToTilemap(Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef)
	{
	}

	private void BuildDestructibleWallGroups()
	{
	}

	internal void BuildTunnelPairsFromWinningLayers(Dictionary<Vector3Int, TileDefinitionDatabase.Entry> cellToDef)
	{
	}

	internal void SpawnPillsFromEligibility(Dictionary<Vector2Int, TileDefinitionDatabase.Entry> baseTileByCell, Dictionary<Vector2Int, bool?> spawnOverlayByCell)
	{
	}

	internal static void GetCrateSpawnOffsetAndRotation(int crateIndex, Vector2Int cell, IReadOnlyDictionary<int, Vector2Int> crateCellsByIndex, int minPlayableX, int maxPlayableX, int minPlayableY, int maxPlayableY, out Vector3 offset, out Quaternion rotation)
	{
		offset = default(Vector3);
		rotation = default(Quaternion);
	}

	private static float GetVisibleInset(float defaultOffset, int borderDistance)
	{
		return 0f;
	}

	internal static bool IsCrateTile(TileType tileType, out int crateIndex)
	{
		crateIndex = default(int);
		return false;
	}

	public TileType GetTileTypeAt(Vector2Int position)
	{
		return default(TileType);
	}

	public TileType GetTileTypeAtForSnakePath(Vector2Int position)
	{
		return default(TileType);
	}

	public GameObject FindRoadBlockCoverAtAnyLayer(int x, int y)
	{
		return null;
	}

	public TileType CheckTileUnderPlayer(Vector3 position)
	{
		return default(TileType);
	}

	public void SetTileVisualByType(Vector3Int cell, TileType type)
	{
	}

	public bool TryGetTunnelDirection(Vector3Int cell, out DirectionPlayer dir)
	{
		dir = default(DirectionPlayer);
		return false;
	}

	public Vector3Int FindMatchingTunnelTile(Vector3Int currentCell)
	{
		return default(Vector3Int);
	}

	private TileType ResolveTileType(TileBase tile)
	{
		return default(TileType);
	}

	internal void TrySpawnCover(Vector3Int cell, Vector3 pos, TileDefinitionDatabase.Entry def)
	{
	}

	private GameObject InstantiateCover(Vector3Int cell, Vector3 pos, TileDefinitionDatabase.Entry def, GameObject prefab)
	{
		return null;
	}

	private void WireTunnelControllers()
	{
	}

	private bool TryGetTunnelDirectionFromTileName(Vector3Int cell, out DirectionPlayer dir)
	{
		dir = default(DirectionPlayer);
		return false;
	}

	private void WireSwitchControllers()
	{
	}
}
