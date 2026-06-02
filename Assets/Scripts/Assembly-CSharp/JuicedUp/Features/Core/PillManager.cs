using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Boosters.Shuffle;
using JuicedUp.Features.Core.SecretCollectible;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class PillManager : MonoBehaviour, IAsyncInitializable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerateActivePills_003Ed__56 : IEnumerable<PillController>, IEnumerable, IEnumerator<PillController>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private PillController _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PillManager _003C_003E4__this;

			private bool onlyUnlockedGroups;

			public bool _003C_003E3__onlyUnlockedGroups;

			private int _003Ci_003E5__2;

			PillController IEnumerator<PillController>.Current
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
			public _003CEnumerateActivePills_003Ed__56(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<PillController> IEnumerable<PillController>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGroupAllPills_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PillManager _003C_003E4__this;

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
			public _003CGroupAllPills_003Ed__62(int _003C_003E1__state)
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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayShuffleVortexThenRespawnAsync_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public PillManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRecolorCooldown_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PillManager _003C_003E4__this;

			public int groupId;

			public float duration;

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
			public _003CRecolorCooldown_003Ed__75(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CRenewLostPillsCoroutine_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PillManager _003C_003E4__this;

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
			public _003CRenewLostPillsCoroutine_003Ed__61(int _003C_003E1__state)
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

		public Action<int> OnChunkCountUpdated;

		public Action OnChunkRespawned;

		public Action<Vector3Int> OnEatingPill;

		public Action<Vector3Int, bool> OnPillActiveStateChanged;

		public Action<Vector3Int> OnSpawningPill;

		public int pillsGroupsToAvoid;

		[Header("Grouping Settings")]
		public bool groupByVolumeBoxes;

		public LayerMask pillLayerMask;

		public bool differentPillsUD_RL;

		public PillController pillPrefab;

		public List<GameObject> pillsEaten;

		public List<PillCounter> allPillCounter;

		public List<GameObject> allPillsInGameAtFirst;

		public List<PillsGroup> pillGroupsA;

		public readonly Dictionary<PillGroupBox, PillsGroup> PillGroupsByBox;

		[SerializeField]
		private RespawnScheduler _respawnScheduler;

		private readonly Dictionary<Vector3Int, PillsGroup> _cellToGroup = new Dictionary<Vector3Int, PillsGroup>();

		private readonly bool _ignoreChunkEvents;

		private readonly Dictionary<int, int> _chunkActivePillCount = new Dictionary<int, int>();

		private readonly Vector3 _offsetSprite;

		private readonly Queue<GameObject> _pillsEatenQueue = new Queue<GameObject>();

		private readonly HashSet<int> _recentlyRecoloredGroups = new HashSet<int>();

		private bool _cellToGroupBuilt;

		private int _activeChunkPillCount;

		private bool _isCoroutineRunning;

		private bool _isInitialized;

		private Player _player;

		private TailManager _tailManager;

		private int _totalPillsToRenew;

		private LevelData _levelData;

		private readonly Dictionary<Vector3Int, PillController> _allPillsSpawnedDict = new Dictionary<Vector3Int, PillController>();

		private RemoteConfigService _remoteConfigService;

		private ISecretCollectibleSpawnHandler _secretHandler;

		private IShuffleVortexVfxController _shuffleVortexVfxController;

		public bool IsRespawning => _respawnScheduler != null && _respawnScheduler.IsRespawning;

		public bool IsChunkRespawnOver => false;

		public event Action<PillKind, PillType> OnPillKindEaten
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

		[Inject]
		public void Construct(Player player, TailManager tailManager, RemoteConfigService remoteConfigService, ISecretCollectibleSpawnHandler secretHandler, IShuffleVortexVfxController shuffleVortexVfxController)
		{
		}

		public void Init(Player player, LevelData levelData)
		{
			_player = player;
			_levelData = levelData;
			_isInitialized = true;
			InitializeRespawnScheduler();
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void InitializeRespawnScheduler()
		{
			if (_respawnScheduler == null) return;
			float delay = GetRespawnDelay();
			_respawnScheduler.Init(_player, _levelData, this, delay, null);
		}

		private float GetRespawnDelay()
		{
			return 0f;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public Vector3Int GetCellFromWorld(Vector3 worldPos)
		{
			return default(Vector3Int);
		}

		public bool TryFindPillAtCell(Vector3Int cell, out PillController pillController)
		{
			if (_allPillsSpawnedDict != null && _allPillsSpawnedDict.TryGetValue(cell, out pillController))
				return true;
			pillController = null;
			return false;
		}

		public void RefreshUnlockedGroupsFromBoxes()
		{
		}

		public bool IsCellInUnlockedPillGroup(Vector3Int cell)
		{
			return false;
		}

		public void InitFirstRespawn()
		{
			if (_respawnScheduler == null) return;
			_respawnScheduler.InitFirstRespawn();
		}

		public void StartFirstRespawn()
		{
			if (_respawnScheduler == null) return;
			_respawnScheduler.StartFirstRespawn();
		}

		public IEnumerator HandleChunkOver()
		{
			return null;
		}

		public GameObject GetPillMasterAtPosition(Vector3 position)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEnumerateActivePills_003Ed__56))]
		public IEnumerable<PillController> EnumerateActivePills(bool onlyUnlockedGroups = true)
		{
			if (_allPillsSpawnedDict == null) yield break;
			foreach (PillController pill in _allPillsSpawnedDict.Values)
			{
				if (pill == null) continue;
				// If group map not built yet, skip the group filter
				if (onlyUnlockedGroups && _cellToGroupBuilt)
				{
					Vector3Int cell = new Vector3Int(
						(int)pill.transform.position.x,
						(int)pill.transform.position.y, 0);
					if (!IsCellInUnlockedPillGroup(cell)) continue;
				}
				yield return pill;
			}
		}

		public void RegisterChunk(List<Collider2D> colliders)
		{
		}

		public void RespawnAllMapPillsInstant()
		{
		}

		public bool SpawnPill(Vector3Int position, TileType tileType)
		{
			if (pillPrefab == null) return false;
			if (_allPillsSpawnedDict != null && _allPillsSpawnedDict.ContainsKey(position)) return false;

			Vector3 worldPos = new Vector3(position.x, position.y, position.z);
			PillController pill = Instantiate(pillPrefab, worldPos, Quaternion.identity);
			if (pill == null) return false;

			pill.SetTileType(tileType);
			pill.SetPillActive(false); // RespawnScheduler will activate it

			if (_allPillsSpawnedDict != null)
				_allPillsSpawnedDict[position] = pill;

			return true;
		}

		private void RemovePill(Vector3Int _, GameObject pill)
		{
		}

		[IteratorStateMachine(typeof(_003CRenewLostPillsCoroutine_003Ed__61))]
		public IEnumerator RenewLostPillsCoroutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGroupAllPills_003Ed__62))]
		public IEnumerator GroupAllPills()
		{
			return null;
		}

		internal void LockThisPillGroup(PillGroupBox box)
		{
		}

		public void SetPillActivePublic(PillController pill, bool active)
		{
		}

		public void RegisterPillForNextRound(Vector3Int cell)
		{
		}

		private void OnTriggeringBooster(BoosterId type)
		{
		}

		[AsyncStateMachine(typeof(_003CPlayShuffleVortexThenRespawnAsync_003Ed__67))]
		private UniTaskVoid PlayShuffleVortexThenRespawnAsync(CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		private void ConsumePillLikeHeadEnter(PillController pm, Vector3Int cell, bool playHaptics)
		{
		}

		private void HandleHeadEnterTile(Vector3Int cell, TileType tile)
		{
		}

		private void HandlePillStateChanged(Vector3Int tile, bool isActive)
		{
		}

		private void SetPillActive(PillController pill, bool active)
		{
		}

		private void GroupAllPillsByCoordinate()
		{
		}

		private void BuildCellToGroupMap()
		{
		}

		private void GroupAllPillsByVolumes()
		{
		}

		[IteratorStateMachine(typeof(_003CRecolorCooldown_003Ed__75))]
		private IEnumerator RecolorCooldown(int groupId, float duration)
		{
			return null;
		}

		private bool IsBoxUnlockedNow(PillGroupBox box)
		{
			return false;
		}

		private List<PillController> GetAllowedSlotsForInstantRespawn(int neededCount)
		{
			return null;
		}

		public void SimulatePlayerEatPill(PillController pillController, bool playHaptics = false)
		{
		}
	}
}
