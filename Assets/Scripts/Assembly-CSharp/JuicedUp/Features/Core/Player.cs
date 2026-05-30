using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class Player : MonoBehaviour, IMoveReceiver, IAsyncInitializable
	{
		[CompilerGenerated]
		private sealed class _003CMoveSmoothly_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Player _003C_003E4__this;

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
			public _003CMoveSmoothly_003Ed__81(int _003C_003E1__state)
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
		private sealed class _003CMoveToDirection_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DirectionPlayer direction;

			public Player _003C_003E4__this;

			public bool isCorner;

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
			public _003CMoveToDirection_003Ed__75(int _003C_003E1__state)
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
		private sealed class _003CReviveMoveToPlannedTarget_Co_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Player _003C_003E4__this;

			private Vector3 _003Ctarget_003E5__2;

			private Vector3 _003Cstart_003E5__3;

			private float _003Ct_003E5__4;

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
			public _003CReviveMoveToPlannedTarget_Co_003Ed__74(int _003C_003E1__state)
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

		private const float c_ThresholdDistance = 0.001f;

		public static Action<int> OnArrivedAtCrate;

		public static Action OnArrivedAtDestination;

		public static Action OnEatingTail;

		public static Action OnLeftCrate;

		public static Action OnReviveOver;

		public static Action OnSpawnPlayer;

		public static Action<Vector3> OnSwipe;

		[SerializeField]
		private PlayerView _view;

		private TailManager _tailManager;

		[SerializeField]
		private MovementGatekeeper _movementGatekeeper;

		[SerializeField]
		private TunnelTraversalHandler _tunnelHandler;

		[SerializeField]
		private SnakePoseTracker _poseTracker;

		[SerializeField]
		private TileArrivalDispatcher _arrivalDispatcher;

		[SerializeField]
		private TailCuttingController _tailCuttingController;

		[SerializeField]
		private LayerMask _enemyLayer;

		public bool isMoving;

		public bool isAutoTurning;

		public bool firstSwipe;

		public GridTracker gridTracker;

		public State currentState;

		public TileType nextTargetTile;

		public List<Vector3> allPositionsPath;

		private Quaternion _currentRotation;

		private float _distanceToTarget;

		private bool _hasPlannedTarget;

		private Vector3 _lastSafePosition;

		private Coroutine _moveCo;

		private Vector3Int _plannedTargetCell;

		private Vector3 _plannedTargetWorld;

		private LoadingScreenController _loadingScreenController;

		public IReadOnlyList<PositionStateRotation> PoseQueue => null;

		public DirectionPlayer CurrentDirection { get; private set; }

		public bool IsMoving => false;

		public bool IsAutoTurning => false;

		public int TailLength => 0;

		public Vector3 Position => default(Vector3);

		public Transform SnakeHeadTransform => null;

		public SnakeHeadView SnakeHeadView => null;

		public static event Action<Vector3Int, TileType> OnHeadEnterTile
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
		public void Construct(TailManager tailManager, LoadingScreenController loadingScreenController, IGameStateWriter gameStateWriter, RemoteConfigService remoteConfigService, SnakeOccupancyManager occupancy)
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

		private void OnBridgeTileTypeChanged(Vector3Int cell, TileType oldType, TileType newType)
		{
		}

		public bool TryRequestMove(DirectionPlayer dir, bool playFeedbackIfBlocked = true)
		{
			return false;
		}

		public bool CanMove(DirectionPlayer direction, bool shouldAnim)
		{
			return false;
		}

		public void RegisterValidator(IMovementValidator validator)
		{
		}

		public void UnregisterValidator(IMovementValidator validator)
		{
		}

		public void MoveSmoothlyIntoTunnel(Vector3 exitWorld, Vector3Int exitCell, bool continueAfterExit)
		{
		}

		private void InitPlayer(LevelDataSO levelData, LevelMeta _)
		{
		}

		private void ReviveSnapToPlannedTarget()
		{
		}

		private void SetSnakeHeadVisual()
		{
		}

		public void SpawnPlayer()
		{
		}

		private void OnLoadingScreenHidden()
		{
		}

		public void ReScaleObject()
		{
		}

		public void LittleBumpOnArrow(DirectionPlayer direction)
		{
		}

		public void LittleBump(DirectionPlayer direction)
		{
		}

		public void CalculatePath(DirectionPlayer firstSwipeDirection)
		{
		}

		private void ResetHeadPosition()
		{
		}

		public Vector2Int GetNextDirection(DirectionPlayer direction)
		{
			return default(Vector2Int);
		}

		private void HandleArrivedOnCell(Vector3Int cell)
		{
		}

		[IteratorStateMachine(typeof(_003CReviveMoveToPlannedTarget_Co_003Ed__74))]
		private IEnumerator ReviveMoveToPlannedTarget_Co()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMoveToDirection_003Ed__75))]
		private IEnumerator MoveToDirection(DirectionPlayer direction, bool isCorner)
		{
			return null;
		}

		private void UpdateCellAndFireTileEventsIfChanged()
		{
		}

		private void FinalizeMoveAtTarget()
		{
		}

		private bool TryContinueAfterArrival(Vector3 target)
		{
			return false;
		}

		private bool HandleTailHitIfNeeded(Vector3 nextPosition)
		{
			return false;
		}

		private void PushHistoryAndMoveTail()
		{
		}

		[IteratorStateMachine(typeof(_003CMoveSmoothly_003Ed__81))]
		private IEnumerator MoveSmoothly()
		{
			return null;
		}

		private void ReplanTargetIfNeeded()
		{
		}

		private void SetState(State s)
		{
		}

		public void MoveTail(IReadOnlyList<PositionStateRotation> psr)
		{
		}
	}
}
