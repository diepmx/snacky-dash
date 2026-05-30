using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyButtons;
using JuicedUp.Common.Config;
using JuicedUp.Features.Core.Analytics;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class TailCuttingController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCutTheTailRevive_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TailCuttingController _003C_003E4__this;

			public DefeatType defeatType;

			public int indexWhereToCut;

			public bool invertExplosionOrder;

			private int _003CoriginalTailCount_003E5__2;

			private bool _003CusedDeliveryPercentage_003E5__3;

			private List<TailSegment>.Enumerator _003C_003E7__wrap3;

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
			public _003CCutTheTailRevive_003Ed__38(int _003C_003E1__state)
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

		public static Action<Transform, PillKind> OnDestroyingOneSegment;

		public static Action<Transform, PillKind> OnSendingSegmentAfterRevive;

		public static Action OnTailCollision;

		public static Action<int> OnTailCut;

		public static Action<EgpTriggeredData> OnEgpFired;

		private const float CollisionDistance = 0.7f;

		private const float CollisionDistanceSqr = 0.48999998f;

		private const float DefaultTailSpacing = 0.75f;

		private const float SafetyScanDistance = 1.45f;

		private const float SafetyScanDistanceSqr = 2.1025002f;

		private const int MinSegmentsBeforeCollision = 5;

		[FormerlySerializedAs("cutMinDestroy")]
		[FormerlySerializedAs("_cutMinDestroy")]
		[SerializeField]
		private int _minimumSegmentsToDestroy;

		[FormerlySerializedAs("cutPreImpact")]
		[FormerlySerializedAs("_cutPreImpact")]
		[SerializeField]
		private int _preImpactCutOffset;

		[Tooltip("Maximum allowed z-axis difference between head and a tail segment before they are considered to be on different physical layers (over vs under a bridge). Keep this tight (~0.1) to reject false positives where the segment's logical z drifts close to ground while it is still physically over a bridge. Upper bound is capped at 0.5 because above ~0.5 the guard is effectively disabled given the bridge z-curve peaks near z = -1.")]
		[SerializeField]
		[Range(0.05f, 0.5f)]
		private float _maxLayerHeightDelta;

		[SerializeField]
		private TailManager _tailManager;

		[FormerlySerializedAs("timeBwSegmentDestruction")]
		public float _timeBwSegmentDestruction;

		public bool IsCuttingTail;

		public List<PillKind> lastCutPillColors;

		public List<Vector3> lastCutPillPositions;

		public int pillsCut;

		public bool IsTailProtected;

		private int _indexWhereToCut;

		private IGameStateWriter _gameStateWriter;

		private RemoteConfigService _remoteConfigService;

		private Player _player;

		private SnakeOccupancyManager _occupancy;

		public static event Action<TailBridgeCollisionData> OnBridgeCollisionEvaluated
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

		public event Action OnRevive
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

		public void Construct(IGameStateWriter gameStateWriter, RemoteConfigService remoteConfigService = null, Player player = null, SnakeOccupancyManager occupancy = null)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private static State Norm(State state)
		{
			return default(State);
		}

		public bool WillHeadHitTailNextStep(Vector3 nextHeadPosition, State playerState, DirectionPlayer playerDirection)
		{
			return false;
		}

		[Button("Continue playing after death")]
		public void CutTheTailAndContinuePlayingAfterRevive()
		{
		}

		[IteratorStateMachine(typeof(_003CCutTheTailRevive_003Ed__38))]
		private IEnumerator CutTheTailRevive(int indexWhereToCut, DefeatType defeatType, bool invertExplosionOrder = true)
		{
			return null;
		}

		private void OnReviveOver()
		{
		}

		private int ComputeCutStartIndex(int hitIndex, int tailCount)
		{
			return 0;
		}

		private bool IsGuaranteedDeliveryActive()
		{
			return false;
		}

		private int ComputeGuaranteedDeliveryCutIndex(int tailCount)
		{
			return 0;
		}

		private int ApplySafetyAndBuffer(int percentageCutStart, int originalTailCount, List<TailSegment> tailSegments)
		{
			return 0;
		}

		private int FindDeepestUnsafeIndex(List<TailSegment> tailSegments, Vector3 headPosition, State headState, DirectionPlayer headDirection, int exclusiveUpperBound)
		{
			return 0;
		}

		private float GetSafetyBufferPercentage()
		{
			return 0f;
		}

		private bool IsBridgeUnderpassFalsePositive(Vector3 headWorldPosition, TailSegment segment, int segmentIndex, DirectionPlayer playerDirection)
		{
			return false;
		}

		private static bool IsDirectionAlignedWithBridge(TileType bridgeType, DirectionPlayer direction)
		{
			return false;
		}

		private bool TryBuildNearBridgeContext(Vector3 nextHeadPosition, TailSegment segment, out Vector3Int bridgeCell, out TileType bridgeTileType)
		{
			bridgeCell = default(Vector3Int);
			bridgeTileType = default(TileType);
			return false;
		}
	}
}
