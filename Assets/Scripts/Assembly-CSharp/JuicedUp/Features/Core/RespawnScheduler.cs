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

		[CompilerGenerated]
		private sealed class _003CHandleChunkOver_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RespawnScheduler _003C_003E4__this;

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
			public _003CHandleChunkOver_003Ed__33(int _003C_003E1__state)
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
		private sealed class _003CRespawnPostProcess_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<PillController> spawned;

			public HashSet<Vector3Int> blockedCells;

			public RespawnScheduler _003C_003E4__this;

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
			public _003CRespawnPostProcess_003Ed__42(int _003C_003E1__state)
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
		private sealed class _003CRespawnUsingSequence_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RespawnScheduler _003C_003E4__this;

			public float delay;

			private _003C_003Ec__DisplayClass34_0 _003C_003E8__1;

			private bool _003CisEmergencyRun_003E5__2;

			private bool _003CisRecoveryRun_003E5__3;

			private RespawnBatch _003Cbatch_003E5__4;

			private int _003CtotalNeeded_003E5__5;

			private List<PillController> _003CspawnedThisBatch_003E5__6;

			private int _003CslotsTotal_003E5__7;

			private int _003CtotalPlaced_003E5__8;

			private Dictionary<PillKind, int> _003CplacedByKind_003E5__9;

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
			public _003CRespawnUsingSequence_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CSpawnWaveFromPlayer_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector3 center;

			public List<PillController> pillsToSpawn;

			private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

			public float duration;

			public HashSet<Vector3Int> blockedCells;

			public RespawnScheduler _003C_003E4__this;

			private float _003CmaxDist_003E5__2;

			private List<PillController>.Enumerator _003C_003E7__wrap2;

			private PillController _003Cpill_003E5__4;

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
			public _003CSpawnWaveFromPlayer_003Ed__41(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private readonly Dictionary<PillKind, int> _pendingRecovery;

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

		private bool HasPendingRecovery => false;

		private int PendingRecoveryTotal => 0;

		public bool IsRespawning { get; private set; }

		public bool ChunkRespawnOver => false;

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
			return 0;
		}

		public void Init(Player player, LevelData levelData, PillManager pillManager, float firstRespawnDelay, ISecretCollectibleSpawnHandler secretHandler = null)
		{
		}

		public void InitFirstRespawn()
		{
		}

		public void StartFirstRespawn()
		{
		}

		public void EnqueueRecoveryFromTailCut(List<PillKind> cutKinds)
		{
		}

		[IteratorStateMachine(typeof(_003CHandleChunkOver_003Ed__33))]
		public IEnumerator HandleChunkOver()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRespawnUsingSequence_003Ed__34))]
		private IEnumerator RespawnUsingSequence(float delay)
		{
			return null;
		}

		private bool TryGetFixedAssignment(int batchIndex, RespawnBatch batch, out List<(PillController pillController, PillKind pillKind)> assignment)
		{
			assignment = null;
			return false;
		}

		private RespawnBatch BuildEmergencyBatch()
		{
			return null;
		}

		private RespawnBatch BuildRecoverySliceBatch(int capacity)
		{
			return null;
		}

		private void ConsumeRecoverySlice(RespawnBatch slice)
		{
		}

		private void InitRespawnRandom()
		{
		}

		private void ResetRespawnRngForBatch()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnWaveFromPlayer_003Ed__41))]
		private IEnumerator SpawnWaveFromPlayer(List<PillController> pillsToSpawn, Vector3 center, float duration, HashSet<Vector3Int> blockedCells)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRespawnPostProcess_003Ed__42))]
		private IEnumerator RespawnPostProcess(List<PillController> spawned, HashSet<Vector3Int> blockedCells)
		{
			return null;
		}

		private void SetPillType(PillController pm, int waveIndex)
		{
		}
	}
}
