using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class SwipeController : MonoBehaviour, IAsyncInitializable
	{
		[Flags]
		public enum DirMask
		{
			None = 0,
			Up = 1,
			Down = 2,
			Left = 4,
			Right = 8,
			All = 0xF
		}

		[CompilerGenerated]
		private sealed class _003CConsumeRecordedNextFrame_Co_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SwipeController _003C_003E4__this;

			public DirectionPlayer dir;

			private int _003Csafety_003E5__2;

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
			public _003CConsumeRecordedNextFrame_Co_003Ed__47(int _003C_003E1__state)
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

		public static Action OnFirstSwipe;

		public static Action<DirectionPlayer> OnSwipe;

		public static Action<DirectionPlayer> OnSwipeUp;

		public ControlMode controlMode;

		[SerializeField]
		private MonoBehaviour moveReceiverMb;

		public DirectionPlayer directionSaved;

		public SwipeRecorder swipeRecorder;

		public bool blockSwipe;

		public bool blockSwipeCrate;

		public bool blockSwipeRespawn;

		public bool firstSwipeInGame;

		public GameObject swipeControl;

		private readonly Stack<DirMask> _forcedMaskStack;

		private Coroutine _consumeRecordedCo;

		private DirMask _forcedMask;

		private bool _hardBlockInput;

		private IMoveReceiver _move;

		private StuckDetectionTracker _stuckDetectionTracker;

		public static SwipeController Instance { get; private set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnValidate()
		{
		}

		[Inject]
		private void Construct(StuckDetectionTracker stuckDetectionTracker)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void SetHardBlockInput(bool enabled)
		{
		}

		public void PushForcedDirections(DirMask mask)
		{
		}

		public void PopForcedDirections()
		{
		}

		public void ClearForcedDirections()
		{
		}

		public void BlockSwipe(BlockSwipeType blockSwipeType)
		{
		}

		public void AllowSwipe(BlockSwipeType blockSwipeType)
		{
		}

		public void OnEnterTunnel(bool _)
		{
		}

		public void OnExitTunnel(bool _)
		{
		}

		public DirectionPlayer GetDirectionFromSwipe(int _direction)
		{
			return default(DirectionPlayer);
		}

		public void GoToDirection(int direction)
		{
		}

		public void GoToDirection(DirectionPlayer dir)
		{
		}

		public List<DirectionPlayer> GetWalkableDirections()
		{
			return null;
		}

		public List<DirectionPlayer> GetPossibleDirections(bool requireIdle = true)
		{
			return null;
		}

		private bool IsDirectionAllowed(DirectionPlayer dir)
		{
			return false;
		}

		private DirectionPlayer GetDirectionFromInt(int direction)
		{
			return default(DirectionPlayer);
		}

		private void OnSpawnPlayer()
		{
		}

		private void OnReviveOver()
		{
		}

		private void OnCompletingOneChunkListener()
		{
		}

		private void OnArrivedAtDestinationListener()
		{
		}

		[IteratorStateMachine(typeof(_003CConsumeRecordedNextFrame_Co_003Ed__47))]
		private IEnumerator ConsumeRecordedNextFrame_Co(DirectionPlayer dir)
		{
			return null;
		}

		private void TryAddIfPossible(DirectionPlayer dir, List<DirectionPlayer> list)
		{
		}

		private bool CanMoveDir(DirectionPlayer dir)
		{
			return false;
		}

		private bool IsOpposite(DirectionPlayer a, DirectionPlayer b)
		{
			return false;
		}
	}
}
