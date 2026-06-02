using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JuicedUp.Features.Core.SecretCollectible;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class RespawnScheduler : MonoBehaviour
	{
		// -----------------------------------------------
		// Compiler-generated state machine stubs (preserved from decode)
		// -----------------------------------------------

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

			internal int _003CRespawnUsingSequence_003Eb__6(PillsGroup g) => 0;
			internal int _003CRespawnUsingSequence_003Eb__7(PillsGroup g) => 0;
			internal bool _003CRespawnUsingSequence_003Eb__17(PillsGroup g) => false;
			internal int _003CRespawnUsingSequence_003Eb__20(PillController a, PillController b) => 0;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass41_0
		{
			public Vector3 center;
			internal float _003CSpawnWaveFromPlayer_003Eb__0(PillController p) => 0f;
			internal float _003CSpawnWaveFromPlayer_003Eb__1(PillController p) => 0f;
		}

		// -----------------------------------------------
		// State fields (preserved from decode)
		// -----------------------------------------------

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

		// -----------------------------------------------
		// Properties
		// -----------------------------------------------

		private bool HasPendingRecovery => _pendingRecovery != null && _pendingRecovery.Count > 0;

		private int PendingRecoveryTotal
		{
			get
			{
				if (_pendingRecovery == null) return 0;
				int total = 0;
				foreach (int v in _pendingRecovery.Values) total += v;
				return total;
			}
		}

		public bool IsRespawning { get; private set; }

		public bool ChunkRespawnOver => _chunkRespawnOver;

		public int RespawnBatchIndex { get; private set; }

		public static event Action<int, bool, List<PillController>, PillManager> OnBatchPlaced
		{
			[CompilerGenerated] add { }
			[CompilerGenerated] remove { }
		}

		// -----------------------------------------------
		// Static helper
		// -----------------------------------------------

		public static int ComparePrioritySpawnCells(Vector3Int cellA, Vector3Int cellB, LevelController levelController)
		{
			if (levelController == null) return 0;
			bool aIsPriority = levelController.IsPriorityPillSpawnCell(new Vector2Int(cellA.x, cellA.y));
			bool bIsPriority = levelController.IsPriorityPillSpawnCell(new Vector2Int(cellB.x, cellB.y));
			if (aIsPriority && !bIsPriority) return -1;
			if (!aIsPriority && bIsPriority) return 1;
			return 0;
		}

		// -----------------------------------------------
		// Init
		// -----------------------------------------------

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
			if (!_isInitialized) return;
			// Nothing extra to initialize – StartFirstRespawn triggers the first coroutine
		}

		public void StartFirstRespawn()
		{
			if (!_isInitialized) return;
			StartCoroutine(RespawnUsingSequence(_firstRespawnDelay));
		}

		public void EnqueueRecoveryFromTailCut(List<PillKind> cutKinds)
		{
			if (cutKinds == null) return;
			foreach (PillKind k in cutKinds)
			{
				if (_pendingRecovery.ContainsKey(k))
					_pendingRecovery[k]++;
				else
					_pendingRecovery[k] = 1;
			}
		}

		// -----------------------------------------------
		// Coroutines
		// -----------------------------------------------

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
				yield return new WaitForSeconds(delay);

			// Determine which batch to use
			RespawnBatch batch = GetCurrentBatch();
			bool isEmergencyRun = false;

			// Check for pending recovery first
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

			int totalNeeded = batch.total > 0 ? batch.total : CalculateTotalFromColors(batch);
			if (totalNeeded <= 0)
			{
				IsRespawning = false;
				yield break;
			}

			// Collect available slots from PillManager
			List<PillController> spawnedThisBatch = new List<PillController>();

			// Try fixed assignment first (from FixedSpawnPlan)
			bool usedFixedAssignment = TryGetFixedAssignment(RespawnBatchIndex, batch, out List<(PillController pillController, PillKind pillKind)> fixedAssignment);

			if (usedFixedAssignment && fixedAssignment != null)
			{
				// Apply fixed pill kind assignments
				foreach ((PillController pillController, PillKind pillKind) pair in fixedAssignment)
				{
					if (pair.pillController == null) continue;
					pair.pillController.SetPillKind(pair.pillKind);
					pair.pillController.SetPillActive(true);
					spawnedThisBatch.Add(pair.pillController);
				}
			}
			else
			{
				// Fallback: use random placement by PillManager
				// Let PillManager decide which inactive slots to fill
				int placed = 0;
				if (_pillManager != null)
				{
					foreach (PillController p in _pillManager.EnumerateActivePills(false))
					{
						if (p == null || p.IsPillActive) continue;
						PillKind kind = PickKindForSlot(batch, placed, totalNeeded);
						p.SetPillKind(kind);
						p.SetPillActive(true);
						spawnedThisBatch.Add(p);
						placed++;
						if (placed >= totalNeeded) break;
					}
				}
			}

			// Spawn wave animation from player position
			Vector3 playerCenter = _player != null ? _player.transform.position : Vector3.zero;
			HashSet<Vector3Int> blockedCells = new HashSet<Vector3Int>();
			yield return SpawnWaveFromPlayer(spawnedThisBatch, playerCenter, 0.5f, blockedCells);

			// Post-process
			yield return RespawnPostProcess(spawnedThisBatch, blockedCells);

			if (!isEmergencyRun)
			{
				RespawnBatchIndex++;
				ResetRespawnRngForBatch();
			}

			IsRespawning = false;
		}

		// -----------------------------------------------
		// Fixed assignment helpers
		// -----------------------------------------------

		private bool TryGetFixedAssignment(int batchIndex, RespawnBatch batch, out List<(PillController pillController, PillKind pillKind)> assignment)
		{
			assignment = null;
			LevelController lc = LevelController.Instance;
			if (lc?.FixedSpawnPlan == null) return false;

			if (!lc.FixedSpawnPlan.TryGetLayer(batchIndex, out FixedSpawnLayer layer))
				return false;

			if (layer?.Entries == null || layer.Entries.Count == 0) return false;

			assignment = new List<(PillController, PillKind)>();

			foreach ((Vector3Int cell, int tileId) entry in layer.Entries)
			{
				// Find the PillController at this cell
				if (_pillManager == null) continue;
				Vector3Int cell3 = entry.cell;
				if (!_pillManager.TryFindPillAtCell(cell3, out PillController pill)) continue;

				// Resolve PillKind from tileId
				PillKind kind;
				if (lc.SpawnIdMap != null && lc.SpawnIdMap.TryGetKind(entry.tileId, out kind))
				{
					// use mapped kind
				}
				else
				{
					// Fallback: direct cast (371 = 0, 372 = 1, ...)
					kind = (PillKind)Mathf.Clamp(entry.tileId - 371, 0, 6);
				}

				assignment.Add((pill, kind));
			}

			return assignment.Count > 0;
		}

		// -----------------------------------------------
		// Emergency / Recovery batches
		// -----------------------------------------------

		private RespawnBatch BuildEmergencyBatch()
		{
			RespawnBatch eb = new RespawnBatch();
			eb.colors = new List<RespawnColorCount>();
			eb.total = 0;
			if (_levelData?.respawnSequence?.batches != null)
			{
				// Use the last known batch as emergency fallback
				List<RespawnBatch> batches = _levelData.respawnSequence.batches;
				if (batches.Count > 0)
				{
					RespawnBatch last = batches[batches.Count - 1];
					if (last != null)
					{
						eb.colors = last.colors != null ? new List<RespawnColorCount>(last.colors) : new List<RespawnColorCount>();
						eb.total = last.total;
					}
				}
			}
			return eb;
		}

		private RespawnBatch BuildRecoverySliceBatch(int capacity)
		{
			RespawnBatch slice = new RespawnBatch();
			slice.colors = new List<RespawnColorCount>();
			slice.total = 0;

			if (_pendingRecovery == null) return slice;
			foreach (KeyValuePair<PillKind, int> kv in _pendingRecovery)
			{
				if (kv.Value <= 0) continue;
				slice.colors.Add(new RespawnColorCount { pillKind = kv.Key, count = kv.Value });
				slice.total += kv.Value;
			}
			return slice;
		}

		private void ConsumeRecoverySlice(RespawnBatch slice)
		{
			if (slice?.colors == null || _pendingRecovery == null) return;
			foreach (RespawnColorCount c in slice.colors)
			{
				if (_pendingRecovery.ContainsKey(c.pillKind))
				{
					_pendingRecovery[c.pillKind] -= c.count;
					if (_pendingRecovery[c.pillKind] <= 0)
						_pendingRecovery.Remove(c.pillKind);
				}
			}
		}

		// -----------------------------------------------
		// RNG helpers
		// -----------------------------------------------

		private void InitRespawnRandom()
		{
			if (_levelData != null && _levelData.usingSeedRandom)
				_seededRng = new System.Random(_levelData.seedRandom);
			else
				_seededRng = new System.Random(UnityEngine.Random.Range(0, int.MaxValue));
		}

		private void ResetRespawnRngForBatch()
		{
			// Each batch uses a fresh seeded random derived from batch index and level seed
			if (_levelData != null && _levelData.usingSeedRandom)
				_seededRng = new System.Random(_levelData.seedRandom + RespawnBatchIndex);
		}

		// -----------------------------------------------
		// Spawn wave animation
		// -----------------------------------------------

		private IEnumerator SpawnWaveFromPlayer(List<PillController> pillsToSpawn, Vector3 center, float duration, HashSet<Vector3Int> blockedCells)
		{
			if (pillsToSpawn == null || pillsToSpawn.Count == 0) yield break;

			// Sort pills by distance from player (closest last = they appear first in the wave)
			pillsToSpawn.Sort((a, b) =>
			{
				if (a == null && b == null) return 0;
				if (a == null) return 1;
				if (b == null) return -1;
				float dA = Vector3.Distance(a.transform.position, center);
				float dB = Vector3.Distance(b.transform.position, center);
				return dA.CompareTo(dB);
			});

			float maxDist = 0f;
			foreach (PillController p in pillsToSpawn)
			{
				if (p == null) continue;
				float d = Vector3.Distance(p.transform.position, center);
				if (d > maxDist) maxDist = d;
			}
			if (maxDist <= 0f) maxDist = 1f;

			float elapsed = 0f;
			int nextIndex = 0;

			while (nextIndex < pillsToSpawn.Count)
			{
				elapsed += Time.deltaTime;
				float progress = Mathf.Clamp01(elapsed / duration);

				// Spawn pills whose normalised distance <= progress
				while (nextIndex < pillsToSpawn.Count)
				{
					PillController p = pillsToSpawn[nextIndex];
					if (p == null) { nextIndex++; continue; }
					float normDist = Vector3.Distance(p.transform.position, center) / maxDist;
					if (normDist <= progress)
					{
						p.StartCoroutineRenew();
						nextIndex++;
					}
					else break;
				}
				yield return null;
			}
		}

		private IEnumerator RespawnPostProcess(List<PillController> spawned, HashSet<Vector3Int> blockedCells)
		{
			// Yield one frame to let pill animations start
			yield return null;

			// Notify listeners
			if (spawned != null && spawned.Count > 0 && _pillManager != null)
			{
				_pillManager.OnChunkRespawned?.Invoke();
			}
		}

		// -----------------------------------------------
		// Private utilities
		// -----------------------------------------------

		private void SetPillType(PillController pm, int waveIndex)
		{
			PillType type = waveIndex == 0 ? PillType.Common : PillType.Common;
			pm.SetType(type);
		}

		private RespawnBatch GetCurrentBatch()
		{
			if (_levelData?.respawnSequence?.batches == null) return null;
			List<RespawnBatch> batches = _levelData.respawnSequence.batches;
			if (batches.Count == 0) return null;
			// Clamp to last batch once we've exhausted the sequence
			int idx = Mathf.Min(RespawnBatchIndex, batches.Count - 1);
			return batches[idx];
		}

		private static int CalculateTotalFromColors(RespawnBatch batch)
		{
			if (batch?.colors == null) return 0;
			int t = 0;
			foreach (RespawnColorCount c in batch.colors)
				if (c != null) t += c.count;
			return t;
		}

		private PillKind PickKindForSlot(RespawnBatch batch, int slotIndex, int totalNeeded)
		{
			if (batch?.colors == null || batch.colors.Count == 0)
				return PillKind.Strawberry;

			// Distribute kinds proportionally across slots
			int runningTotal = 0;
			foreach (RespawnColorCount c in batch.colors)
			{
				if (c == null) continue;
				runningTotal += c.count;
				float threshold = (float)runningTotal / totalNeeded;
				if ((float)(slotIndex + 1) / totalNeeded <= threshold)
					return c.pillKind;
			}

			// Fallback: random pick weighted by count
			int roll = _seededRng != null ? _seededRng.Next(0, totalNeeded) : UnityEngine.Random.Range(0, totalNeeded);
			int acc = 0;
			foreach (RespawnColorCount c in batch.colors)
			{
				if (c == null) continue;
				acc += c.count;
				if (roll < acc) return c.pillKind;
			}
			return batch.colors[0]?.pillKind ?? PillKind.Strawberry;
		}
	}
}
