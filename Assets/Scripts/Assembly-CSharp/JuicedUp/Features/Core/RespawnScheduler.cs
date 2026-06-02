using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JuicedUp.Features.Core.SecretCollectible;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class RespawnScheduler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass34_0
		{
			public PillSpawnRelaxationTier chosenTier;

			public RespawnScheduler _003C_003E4__this;

			public HashSet<Vector3Int> blockedCells;

			public Vector3 playerPos;

			public Dictionary<PillsGroup, List<PillController>> slotsByGroup;

			public Dictionary<PillsGroup, int> groupUsed;

			public Dictionary<PillsGroup, int> prioritySlotCountByGroup;

			public List<PillsGroup> spawnOrder;

			public Predicate<PillsGroup> _003C_003E9__17;

			public Comparison<PillController> _003C_003E9__20;

			internal int _003CRespawnUsingSequence_003Eb__6(PillsGroup g)
			{
				return 0;
			}

			internal int _003CRespawnUsingSequence_003Eb__7(PillsGroup g)
			{
				return 0;
			}

			internal bool _003CRespawnUsingSequence_003Eb__17(PillsGroup g)
			{
				return false;
			}

			internal int _003CRespawnUsingSequence_003Eb__20(PillController a, PillController b)
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass41_0
		{
			public Vector3 center;

			internal float _003CSpawnWaveFromPlayer_003Eb__0(PillController p)
			{
				return 0f;
			}

			internal float _003CSpawnWaveFromPlayer_003Eb__1(PillController p)
			{
				return 0f;
			}
		}

		private readonly Dictionary<PillKind, int> _pendingRecovery = new Dictionary<PillKind, int>();

		private ISecretCollectibleSpawnHandler _secretHandler;

		private bool _emergencyWaveAppended;

		private RespawnBatch _emergencyBatch;

		private bool _isInitialized;

		private LevelData _levelData;

		private PillManager _pillManager;

		private float _firstRespawnDelay;

		private Player _player;

		private System.Random _seededRng;

		private bool _chunkRespawnOver;

		private bool HasPendingRecovery
		{
			get
			{
				return _pendingRecovery != null && _pendingRecovery.Count > 0;
			}
		}

		private int PendingRecoveryTotal
		{
			get
			{
				if (_pendingRecovery == null)
				{
					return 0;
				}
				int num = 0;
				foreach (int value in _pendingRecovery.Values)
				{
					num += value;
				}
				return num;
			}
		}

		public bool IsRespawning { get; private set; }

		public bool ChunkRespawnOver
		{
			get
			{
				return _chunkRespawnOver;
			}
		}

		public int RespawnBatchIndex { get; private set; }

		public static event Action<int, bool, List<PillController>, PillManager> OnBatchPlaced
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

		public static int ComparePrioritySpawnCells(Vector3Int cellA, Vector3Int cellB, LevelController levelController)
		{
			if ((UnityEngine.Object)(object)levelController == (UnityEngine.Object)null)
			{
				return 0;
			}
			bool flag = levelController.IsPriorityPillSpawnCell(new Vector2Int(cellA.x, cellA.y));
			bool flag2 = levelController.IsPriorityPillSpawnCell(new Vector2Int(cellB.x, cellB.y));
			if (flag && !flag2)
			{
				return -1;
			}
			if (!flag && flag2)
			{
				return 1;
			}
			return 0;
		}

		public void Init(Player player, LevelData levelData, PillManager pillManager, float firstRespawnDelay, ISecretCollectibleSpawnHandler secretHandler = null)
		{
			_player = player;
			_levelData = levelData;
			_pillManager = pillManager;
			_firstRespawnDelay = firstRespawnDelay;
			_secretHandler = secretHandler;
			_isInitialized = true;
			_chunkRespawnOver = false;
			RespawnBatchIndex = 0;
			IsRespawning = false;
			InitRespawnRandom();
		}

		public void InitFirstRespawn()
		{
			if (_isInitialized)
			{
			}
		}

		public void StartFirstRespawn()
		{
			if (_isInitialized)
			{
				StartCoroutine(RespawnUsingSequence(_firstRespawnDelay));
			}
		}

		public void EnqueueRecoveryFromTailCut(List<PillKind> cutKinds)
		{
			if (cutKinds == null)
			{
				return;
			}
			foreach (PillKind cutKind in cutKinds)
			{
				if (_pendingRecovery.ContainsKey(cutKind))
				{
					_pendingRecovery[cutKind]++;
				}
				else
				{
					_pendingRecovery[cutKind] = 1;
				}
			}
		}

		public IEnumerator HandleChunkOver()
		{
			_chunkRespawnOver = false;
			yield return RespawnUsingSequence(0f);
			_chunkRespawnOver = true;
		}

		private IEnumerator RespawnUsingSequence(float delay)
		{
			IsRespawning = true;
			if (delay > 0f)
			{
				yield return new WaitForSeconds(delay);
			}
			RespawnBatch batch = GetCurrentBatch();
			bool isEmergencyRun = false;
			if (HasPendingRecovery)
			{
				RespawnBatch recoverySlice = BuildRecoverySliceBatch(PendingRecoveryTotal);
				ConsumeRecoverySlice(recoverySlice);
				batch = recoverySlice;
				isEmergencyRun = true;
			}
			else if (_emergencyWaveAppended && _emergencyBatch != null)
			{
				batch = _emergencyBatch;
				isEmergencyRun = true;
			}
			if (batch == null)
			{
				IsRespawning = false;
				yield break;
			}
			int totalNeeded = ((batch.total > 0) ? batch.total : CalculateTotalFromColors(batch));
			if (totalNeeded <= 0)
			{
				IsRespawning = false;
				yield break;
			}
			List<PillController> spawnedThisBatch = new List<PillController>();
			if (TryGetFixedAssignment(RespawnBatchIndex, batch, out var fixedAssignment) && fixedAssignment != null)
			{
				foreach (var pair in fixedAssignment)
				{
					if (!((UnityEngine.Object)(object)pair.pillController == (UnityEngine.Object)null))
					{
						pair.pillController.SetPillKind(pair.pillKind);
						pair.pillController.SetPillActive(active: true);
						spawnedThisBatch.Add(pair.pillController);
					}
				}
			}
			else
			{
				int placed = 0;
				if ((UnityEngine.Object)(object)_pillManager != (UnityEngine.Object)null)
				{
					foreach (PillController p in _pillManager.EnumerateActivePills(onlyUnlockedGroups: false))
					{
						if (!((UnityEngine.Object)(object)p == (UnityEngine.Object)null) && !p.IsPillActive)
						{
							PillKind kind = PickKindForSlot(batch, placed, totalNeeded);
							p.SetPillKind(kind);
							p.SetPillActive(active: true);
							spawnedThisBatch.Add(p);
							placed++;
							if (placed >= totalNeeded)
							{
								break;
							}
						}
					}
				}
			}
			Vector3 playerCenter = (((UnityEngine.Object)(object)_player != (UnityEngine.Object)null) ? ((Component)_player).transform.position : Vector3.zero);
			HashSet<Vector3Int> blockedCells = new HashSet<Vector3Int>();
			yield return SpawnWaveFromPlayer(spawnedThisBatch, playerCenter, 0.5f, blockedCells);
			yield return RespawnPostProcess(spawnedThisBatch, blockedCells);
			if (!isEmergencyRun)
			{
				RespawnBatchIndex++;
				ResetRespawnRngForBatch();
			}
			IsRespawning = false;
		}

		private bool TryGetFixedAssignment(int batchIndex, RespawnBatch batch, out List<(PillController pillController, PillKind pillKind)> assignment)
		{
			assignment = null;
			LevelController instance = LevelController.Instance;
			if (instance?.FixedSpawnPlan == null)
			{
				return false;
			}
			if (!instance.FixedSpawnPlan.TryGetLayer(batchIndex, out var layer))
			{
				return false;
			}
			if (layer?.Entries == null || layer.Entries.Count == 0)
			{
				return false;
			}
			assignment = new List<(PillController, PillKind)>();
			foreach (var entry in layer.Entries)
			{
				if ((UnityEngine.Object)(object)_pillManager == (UnityEngine.Object)null)
				{
					continue;
				}
				var (cell, _) = entry;
				if (_pillManager.TryFindPillAtCell(cell, out var pillController))
				{
					if (instance.SpawnIdMap == null || !instance.SpawnIdMap.TryGetKind(entry.tileId, out var kind))
					{
						kind = (PillKind)Mathf.Clamp(entry.tileId - 371, 0, 6);
					}
					assignment.Add((pillController, kind));
				}
			}
			return assignment.Count > 0;
		}

		private RespawnBatch BuildEmergencyBatch()
		{
			RespawnBatch respawnBatch = new RespawnBatch();
			respawnBatch.colors = new List<RespawnColorCount>();
			respawnBatch.total = 0;
			if (_levelData?.respawnSequence?.batches != null)
			{
				List<RespawnBatch> batches = _levelData.respawnSequence.batches;
				if (batches.Count > 0)
				{
					RespawnBatch respawnBatch2 = batches[batches.Count - 1];
					if (respawnBatch2 != null)
					{
						respawnBatch.colors = ((respawnBatch2.colors != null) ? new List<RespawnColorCount>(respawnBatch2.colors) : new List<RespawnColorCount>());
						respawnBatch.total = respawnBatch2.total;
					}
				}
			}
			return respawnBatch;
		}

		private RespawnBatch BuildRecoverySliceBatch(int capacity)
		{
			RespawnBatch respawnBatch = new RespawnBatch();
			respawnBatch.colors = new List<RespawnColorCount>();
			respawnBatch.total = 0;
			if (_pendingRecovery == null)
			{
				return respawnBatch;
			}
			foreach (KeyValuePair<PillKind, int> item in _pendingRecovery)
			{
				if (item.Value > 0)
				{
					respawnBatch.colors.Add(new RespawnColorCount
					{
						pillKind = item.Key,
						count = item.Value
					});
					respawnBatch.total += item.Value;
				}
			}
			return respawnBatch;
		}

		private void ConsumeRecoverySlice(RespawnBatch slice)
		{
			if (slice?.colors == null || _pendingRecovery == null)
			{
				return;
			}
			foreach (RespawnColorCount color in slice.colors)
			{
				if (_pendingRecovery.ContainsKey(color.pillKind))
				{
					_pendingRecovery[color.pillKind] -= color.count;
					if (_pendingRecovery[color.pillKind] <= 0)
					{
						_pendingRecovery.Remove(color.pillKind);
					}
				}
			}
		}

		private void InitRespawnRandom()
		{
			if ((UnityEngine.Object)(object)_levelData != (UnityEngine.Object)null && _levelData.usingSeedRandom)
			{
				_seededRng = new System.Random(_levelData.seedRandom);
			}
			else
			{
				_seededRng = new System.Random(UnityEngine.Random.Range(0, int.MaxValue));
			}
		}

		private void ResetRespawnRngForBatch()
		{
			if ((UnityEngine.Object)(object)_levelData != (UnityEngine.Object)null && _levelData.usingSeedRandom)
			{
				_seededRng = new System.Random(_levelData.seedRandom + RespawnBatchIndex);
			}
		}

		private IEnumerator SpawnWaveFromPlayer(List<PillController> pillsToSpawn, Vector3 center, float duration, HashSet<Vector3Int> blockedCells)
		{
			if (pillsToSpawn == null || pillsToSpawn.Count == 0)
			{
				yield break;
			}
			pillsToSpawn.Sort(delegate(PillController a, PillController b)
			{
				if ((UnityEngine.Object)(object)a == (UnityEngine.Object)null && (UnityEngine.Object)(object)b == (UnityEngine.Object)null)
				{
					return 0;
				}
				if ((UnityEngine.Object)(object)a == (UnityEngine.Object)null)
				{
					return 1;
				}
				if ((UnityEngine.Object)(object)b == (UnityEngine.Object)null)
				{
					return -1;
				}
				float num = Vector3.Distance(((Component)a).transform.position, center);
				float value = Vector3.Distance(((Component)b).transform.position, center);
				return num.CompareTo(value);
			});
			float maxDist = 0f;
			foreach (PillController p in pillsToSpawn)
			{
				if (!((UnityEngine.Object)(object)p == (UnityEngine.Object)null))
				{
					float d = Vector3.Distance(((Component)p).transform.position, center);
					if (d > maxDist)
					{
						maxDist = d;
					}
				}
			}
			if (maxDist <= 0f)
			{
				maxDist = 1f;
			}
			float elapsed = 0f;
			int nextIndex = 0;
			while (nextIndex < pillsToSpawn.Count)
			{
				elapsed += Time.deltaTime;
				float progress = Mathf.Clamp01(elapsed / duration);
				while (nextIndex < pillsToSpawn.Count)
				{
					PillController p2 = pillsToSpawn[nextIndex];
					if ((UnityEngine.Object)(object)p2 == (UnityEngine.Object)null)
					{
						nextIndex++;
						continue;
					}
					float normDist = Vector3.Distance(((Component)p2).transform.position, center) / maxDist;
					if (normDist <= progress)
					{
						p2.StartCoroutineRenew();
						nextIndex++;
						continue;
					}
					break;
				}
				yield return null;
			}
		}

		private IEnumerator RespawnPostProcess(List<PillController> spawned, HashSet<Vector3Int> blockedCells)
		{
			yield return null;
			if (spawned != null && spawned.Count > 0 && (UnityEngine.Object)(object)_pillManager != (UnityEngine.Object)null)
			{
				_pillManager.OnChunkRespawned?.Invoke();
			}
		}

		private void SetPillType(PillController pm, int waveIndex)
		{
			PillType type = ((waveIndex == 0) ? PillType.Common : PillType.Common);
			pm.SetType(type);
		}

		private RespawnBatch GetCurrentBatch()
		{
			if (_levelData?.respawnSequence?.batches == null)
			{
				return null;
			}
			List<RespawnBatch> batches = _levelData.respawnSequence.batches;
			if (batches.Count == 0)
			{
				return null;
			}
			int index = Mathf.Min(RespawnBatchIndex, batches.Count - 1);
			return batches[index];
		}

		private static int CalculateTotalFromColors(RespawnBatch batch)
		{
			if (batch?.colors == null)
			{
				return 0;
			}
			int num = 0;
			foreach (RespawnColorCount color in batch.colors)
			{
				if (color != null)
				{
					num += color.count;
				}
			}
			return num;
		}

		private PillKind PickKindForSlot(RespawnBatch batch, int slotIndex, int totalNeeded)
		{
			if (batch?.colors == null || batch.colors.Count == 0)
			{
				return PillKind.Strawberry;
			}
			int num = 0;
			foreach (RespawnColorCount color in batch.colors)
			{
				if (color != null)
				{
					num += color.count;
					float num2 = (float)num / (float)totalNeeded;
					if ((float)(slotIndex + 1) / (float)totalNeeded <= num2)
					{
						return color.pillKind;
					}
				}
			}
			int num3 = ((_seededRng != null) ? _seededRng.Next(0, totalNeeded) : UnityEngine.Random.Range(0, totalNeeded));
			int num4 = 0;
			foreach (RespawnColorCount color2 in batch.colors)
			{
				if (color2 != null)
				{
					num4 += color2.count;
					if (num3 < num4)
					{
						return color2.pillKind;
					}
				}
			}
			return batch.colors[0]?.pillKind ?? PillKind.Strawberry;
		}
	}
}
