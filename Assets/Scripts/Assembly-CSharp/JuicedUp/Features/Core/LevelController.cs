using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.SecretCollectible;
using UnityEngine;
using UnityEngine.Tilemaps;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class LevelController : MonoBehaviour, IAsyncInitializable
	{
		[CompilerGenerated]
		private sealed class _003CCreateGroupPillForInitialSpawn_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCreateGroupPillForInitialSpawn_003Ed__113(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public Player player;

		[Header("Experimental Mode")]
		[SerializeField]
		private bool strictTileDb;

		[SerializeField]
		private TileDefinitionDatabase tileDb;

		[SerializeField]
		private bool logMissingTileDefinitions;

		[HideInInspector]
		public Tilemap tilemapGround;

		public Level levelToTest;

		public List<Vector3Int> VisitedTiles;

		public PillManager pillManager;

		public List<PillCounter> allLevelPattern;

		public Transform overlayTunnelRoot;

		public GameObject overlayTunnelTile;

		public List<GameObject> alltilesGround_NotCompleted;

		public TileBase tileRoadAfterBoss;

		public List<MeshRenderer> allGrassMeshDecor;

		public List<MeshRenderer> allRoadMeshDecor;

		public Transform decorParent;

		[SerializeField]
		private SnakeOccupancyManager _snakeOccupancy;

		[SerializeField]
		private ArrowGroupController _arrowGroupController;

		[Header("JSON level – PositionCrates spawning")]
		[Tooltip("Prefab to spawn at Stop_CRATE_0/1/2 cells when building level from Tiled JSON. Leave empty to skip spawning.")]
		[SerializeField]
		private GameObject positionCratesPrefab;

		public Dictionary<Vector3Int, TileType> dictionnaryTileType;

		private readonly Dictionary<Vector3Int, GameObject> _coverByCell;

		private readonly Dictionary<Vector3Int, GameObject> _extraByCell;

		private LevelTilemapMapping _tilemapMapping;

		private LevelDataSO _currentLevelDataSO;

		private readonly LevelMapCache _mapCache;

		private readonly HashSet<Vector2Int> _priorityPillSpawnCells = new HashSet<Vector2Int>();

		private TailManager _tailManager;

		private IAssetLoader _assetLoader;

		private IDataRepository<PlayerProgressData> _progressRepository;

		private ILevelRunStats _levelRunStats;

		private RemoteConfigService _remoteConfig;

		private IGameStateReader _gameStateReader;

		private IGameStateWriter _gameStateWriter;

		private IGameStateEvents _gameStateEvents;

		private RoadExplosionController _roadExplosionController;

		private ISecretCollectibleSpawnHandler _secretHandler;

		public GameState currentGameState => default(GameState);

		public TunnelPairingSystem TunnelPairing => null;

		public LevelDataSO CurrentLevelDataSO => null;

		public string CurrentLevelMapJson => null;

		public static LevelController Instance { get; private set; }

		public Vector3? PlayerStartPosition { get; set; }

		public List<int> CrateIndicesFromJson { get; set; }

		public FixedSpawnPlan FixedSpawnPlan { get; private set; }

		public LevelSpawnIdMap SpawnIdMap { get; private set; }

		public IReadOnlyCollection<Vector2Int> PriorityPillSpawnCells => _priorityPillSpawnCells;

		public int TileMaxLayerIndex => 0;

		public static event Action<Vector3Int, TileType, TileType> OnTileTypeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<LevelData> OnLevelDataInitialized
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		[Inject]
		public void Construct(TailManager tailManager, IAssetLoader assetLoader, RoadExplosionController roadExplosionController, IDataRepository<PlayerProgressData> progressRepository, ILevelRunStats levelRunStats, RemoteConfigService remoteConfig, ISecretCollectibleSpawnHandler secretHandler, IGameStateReader gameStateReader, IGameStateWriter gameStateWriter, IGameStateEvents gameStateEvents)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnReviveUsed()
		{
		}

		private void HandleGameStateChangedForLives(GameState state, DefeatType defeatType)
		{
		}

		public TileDefinitionDatabase GetTileDatabase()
		{
			return null;
		}

		public void InitMapping(LevelDataSO levelSO, Level level)
		{
			_currentLevelDataSO = levelSO;
			// Build SpawnIdMap from the level's respawnSequence
			if (levelSO != null && levelSO.respawnSequence != null)
				SpawnIdMap = new LevelSpawnIdMap(levelSO.respawnSequence);
			else
				SpawnIdMap = new LevelSpawnIdMap(null);
		}

		private void UpdateRoadPieceForExplosion()
		{
		}

		public void InitPillManager()
		{
			if (pillManager == null) return;
			LevelData levelData = GetComponent<LevelData>();
			Player p = player != null ? player : FindObjectOfType<Player>();
			if (levelData != null)
				pillManager.Init(p, levelData);
		}

		private static void ApplyDataMigration(LevelDataSO so, LevelData levelData)
		{
		}

		public void InitPillCounters()
		{
		}

		public void CreateGroupPill()
		{
		}

		public void SetTileType(Vector3Int cell, TileType newType)
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

		public void SetTileVisualByType(Vector3Int cell, TileType type)
		{
		}

		public void SetPriorityPillSpawnCells(HashSet<Vector2Int> cells)
		{
			_priorityPillSpawnCells.Clear();
			if (cells != null)
				foreach (Vector2Int c in cells)
					_priorityPillSpawnCells.Add(c);
		}

		public bool IsPriorityPillSpawnCell(Vector2Int cell)
		{
			return _priorityPillSpawnCells != null && _priorityPillSpawnCells.Contains(cell);
		}

		public TileType GetTileTypeAt(Vector2Int position)
		{
			return default(TileType);
		}

		public TileType GetTileTypeAtForSnakePath(Vector2Int position)
		{
			return default(TileType);
		}

		public bool TryGetTileType(Vector3Int cell, out TileType type)
		{
			type = default(TileType);
			return false;
		}

		public bool IsPillSpawnAdjacentCell(Vector2Int xy)
		{
			return false;
		}

		public void RestoreDestructibleWallPath(int groupId)
		{
		}

		public bool TryGetDestructibleWallGroup(Vector2Int key, out int groupId)
		{
			groupId = default(int);
			return false;
		}

		private void RestoreCells(int groupId)
		{
		}

		public bool TryGetRandomTilePosition(TileDefinitionDatabase tileDB, TileCategory category, out Vector3Int resultCell)
		{
			resultCell = default(Vector3Int);
			return false;
		}

		public ChunkTunnelController GetTunnelAt(Vector3Int cellPos)
		{
			return null;
		}

		public GameObject GetTileGroundAtPosition(Vector3 position)
		{
			return null;
		}

		public bool IsIntersection(TileType tileType)
		{
			return false;
		}

		public TileType CheckTileUnderPlayer(Vector3 position)
		{
			return default(TileType);
		}

		public TileBase GetTile(Vector3 positionTileOverlay, Tilemap tilemap)
		{
			return null;
		}

		public void StartGame()
		{
		}

		private void StartFirstRespawn()
		{
		}

		public void Toggle_AllBridge(SwitchToggleState switchToggleState)
		{
		}

		public void Toggle_AllSwitches()
		{
		}

		public void InitGroupStates()
		{
		}

		private void HideTileMap()
		{
		}

		[IteratorStateMachine(typeof(_003CCreateGroupPillForInitialSpawn_003Ed__113))]
		private IEnumerator CreateGroupPillForInitialSpawn()
		{
			return null;
		}

		private void OnGameComplete()
		{
		}

		private void OnTailCollision()
		{
		}

		internal void SetFixedSpawnPlan(FixedSpawnPlan plan)
		{
			FixedSpawnPlan = plan;
		}

		public void ForceLevelDefeat()
		{
		}
	}
}
