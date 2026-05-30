using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class TailManager : MonoBehaviour, IAsyncInitializable
	{
		[CompilerGenerated]
		private sealed class _003CRemoveTailSegmentsOfColorGradually_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PillKind kindToRemove;

			public TailManager _003C_003E4__this;

			public int numberToRemove;

			public float delay;

			private int _003Ccount_003E5__2;

			private int _003Cdone_003E5__3;

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
			public _003CRemoveTailSegmentsOfColorGradually_003Ed__64(int _003C_003E1__state)
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

		public static Action<int> OnUpdatedTail;

		[SerializeField]
		private TailView _view;

		[SerializeField]
		private SnakeOccupancyManager _occupancy;

		[SerializeField]
		private Transform headTransform;

		[SerializeField]
		private LayerMask pillMask;

		[SerializeField]
		private PillManager _pillManager;

		public GameObject tailPrefab;

		public List<TailSegment> tailSegments;

		[FormerlySerializedAs("playerPsr")]
		[SerializeField]
		private List<PositionStateRotation> _playerPositionStateRotations;

		private readonly Stack<List<PositionStateRotation>> _history;

		[SerializeField]
		private TailFeelHandler _tailFeelHandler;

		private bool _hasHeadCell;

		private bool _hasLastTailCell;

		private Vector3Int _headCell;

		private PositionStateRotation _headPositionStateRotation;

		private Vector3Int _lastTailCell;

		private bool _prevTipIsHead;

		private bool _tailTipOnBridgeAbove;

		public int TailLength => 0;

		public float SpacingFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal List<TailSegment> TailSegments => null;

		internal Transform HeadTransform => null;

		internal TailFeelHandler FeelHandler => null;

		internal bool HasHeadPositionStateRotation { get; private set; }

		internal PositionStateRotation HeadPositionStateRotation => default(PositionStateRotation);

		private TailUnderInfo LastTailUnderInfo { get; set; }

		public static event Action<Vector3Int, TileType> OnLastSegmentLiveCell
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

		private void Update()
		{
		}

		private static bool IsBridge(TileType t)
		{
			return false;
		}

		public bool IsAnySnakeOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool TryGetUnderLastTail(out TailUnderInfo info)
		{
			info = default(TailUnderInfo);
			return false;
		}

		public bool TryGetLastTailCell(out Vector3Int cell)
		{
			cell = default(Vector3Int);
			return false;
		}

		public void DetachSegmentFromSnake(TailSegment seg)
		{
		}

		public void StartBumpTheTail()
		{
		}

		public void RebuildOccupancyAndNotify()
		{
		}

		public void SetAllSegmentsToPose(Vector3 position, Quaternion rotation, State state, DirectionPlayer direction)
		{
		}

		public void MoveTail(IReadOnlyList<PositionStateRotation> psr)
		{
		}

		public void RecordPositionSnakeAndTail()
		{
		}

		internal GameObject GetParticleTailBump()
		{
			return null;
		}

		internal float GetDurationBump()
		{
			return 0f;
		}

		private Vector3Int WorldToCell(Vector3 world)
		{
			return default(Vector3Int);
		}

		private void RebuildOccupancy(bool notify = false, bool cleanDeadRefs = true)
		{
		}

		private void RefreshPillUI()
		{
		}

		private void TryMoveTail()
		{
		}

		private void AddTailSegmentBehindHead(PillKind pillKind, PillType pillType)
		{
		}

		private void AssignMaterial(GameObject tailSegment, PillKind pillKind, PillType pillType)
		{
		}

		[IteratorStateMachine(typeof(_003CRemoveTailSegmentsOfColorGradually_003Ed__64))]
		private IEnumerator RemoveTailSegmentsOfColorGradually(PillKind kindToRemove, int numberToRemove, float delay = 0.05f)
		{
			return null;
		}

		private void PillEaten(PillKind pillKind, PillType pillType)
		{
		}

		private void OnSnakePoseUpdated(IReadOnlyList<PositionStateRotation> psr, Player player)
		{
		}

		private void OnSendingOneSegmentToCrate(PillKind pillKind, int arg2, float arg3)
		{
		}

		private TailSegment GetLastActiveTail()
		{
			return null;
		}

		private Transform GetTipTransform(out bool tipIsHead)
		{
			tipIsHead = default(bool);
			return null;
		}

		private void UpdateLastTailTileEvents(Transform tipTr, bool tipIsHead)
		{
		}

		private void UpdateHeadTileEvents()
		{
		}

		private void DetectTailTipBridgeAbove(Transform tipTr, bool tipIsHead)
		{
		}

		private void RemoveDeadTailRefs(bool notify = false)
		{
		}

		private void TrimHistory()
		{
		}

		private void UpdateTailColor()
		{
		}

		private void OnTurnOverListener()
		{
		}

		private PositionStateRotation FindPositionAtDistance(IReadOnlyList<PositionStateRotation> positionStateRotation, Vector3 lastPosition, float targetDistance)
		{
			return default(PositionStateRotation);
		}

		private void ReapplySortingOrders()
		{
		}

		private void RefreshSnakeCachesHard(bool notify = true)
		{
		}
	}
}
