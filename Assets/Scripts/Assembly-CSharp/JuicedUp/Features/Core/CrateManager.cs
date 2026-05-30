using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyButtons;
using JuicedUp.Common.Config;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Boosters.Config;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class CrateManager : MonoBehaviour
	{
		private readonly struct BoomerangSkyFruit
		{
			public readonly Transform Pill;

			public readonly GameObject Vfx;

			public BoomerangSkyFruit(Transform pill, GameObject vfx)
			{
				Pill = null;
				Vfx = null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass117_0
		{
			public CrateData crate;

			internal void _003CRemoveQueuedCrateIfFinished_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CCannonDeliveryRoutine_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateManager _003C_003E4__this;

			public int colIndex;

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
			public _003CCannonDeliveryRoutine_003Ed__93(int _003C_003E1__state)
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
		private sealed class _003CDeliverWhileStaying_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateManager _003C_003E4__this;

			public CrateData crate;

			public CrateColumn column;

			public int sessionId;

			private bool _003CdeliveryIdleFired_003E5__2;

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
			public _003CDeliverWhileStaying_003Ed__92(int _003C_003E1__state)
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
		private sealed class _003CHandlePillAbsorptionAfterJump_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateData crate;

			public CrateManager _003C_003E4__this;

			public bool isBoomerang;

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
			public _003CHandlePillAbsorptionAfterJump_003Ed__116(int _003C_003E1__state)
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
		private sealed class _003CRemoveCrateIfFinished_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateData crate;

			public CrateManager _003C_003E4__this;

			public CrateColumn column;

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
			public _003CRemoveCrateIfFinished_003Ed__118(int _003C_003E1__state)
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
		private sealed class _003CRemoveQueuedCrateIfFinished_003Ed__117 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateData crate;

			public CrateColumn column;

			public CrateManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass117_0 _003C_003E8__1;

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
			public _003CRemoveQueuedCrateIfFinished_003Ed__117(int _003C_003E1__state)
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
		private sealed class _003CRunBoomerangSequence_003Ed__94 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateManager _003C_003E4__this;

			public List<BoomerangPlanEntry> plan;

			public int fallbackPointIndex;

			private bool _003CwasPlayerOnCrate_003E5__2;

			private int _003CtokenAtStart_003E5__3;

			private float _003CriseDuration_003E5__4;

			private float _003ChoverDuration_003E5__5;

			private float _003ClaunchInterval_003E5__6;

			private CrateData _003CpreviousCrate_003E5__7;

			private float _003CcrateTransitionMaxWait_003E5__8;

			private BoomerangPlanEntry _003Centry_003E5__9;

			private BoomerangSkyFruit _003Cfruit_003E5__10;

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
			public _003CRunBoomerangSequence_003Ed__94(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CUpdateAfterShortDelay_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateManager _003C_003E4__this;

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
			public _003CUpdateAfterShortDelay_003Ed__101(int _003C_003E1__state)
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
		private sealed class _003CWaitForCrateReadyToReceive_003Ed__97 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrateData crate;

			public CrateColumn column;

			public float maxWaitSeconds;

			private Vector3 _003ClanePos_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CWaitForCrateReadyToReceive_003Ed__97(int _003C_003E1__state)
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

		public static Action<PillKind> OnCrateCompleted;

		public static Action OnLevelComplete;

		public static Action<int> OnComboCrateRewarded;

		private static CrateManager _instance;

		[Header("Delivery Trigger")]
		public DeliveryTriggerMode deliveryTrigger;

		public bool lockSwipeWhileDelivering;

		public int unlockDeliverySwipeLevel;

		[Header("Crate Delivery Reward")]
		public bool rewardCoinsByCrateCompletion;

		[HideInInspector]
		public int activeColumnToken;

		[HideInInspector]
		public int deliverySessionToken;

		public Player player;

		public SwipeController swipeController;

		[Header("Sequence Crate Settings")]
		public float timeBetweenPillsToCrate;

		[Header("Delivery Points Highlight")]
		public bool highlightOnlyIfEnoughToFill;

		public List<CrateDeliverPoint> deliveryPoints;

		[SerializeField]
		private List<CrateColumn> columns;

		private PillManager _pillManager;

		private List<PositionCrates> _lanes;

		private List<ManualColumnSetup> _columnSetup;

		private int _cratesFinishedThisSession;

		private int? _currentPointIndex;

		private Coroutine _deliveryRoutine;

		private bool _hasSwipeTriggeredDeliveryThisSession;

		private bool _isDeliveryButtonHeld;

		private bool _isPlayerOnCrate;

		private bool _isBoomerangDeliverySession;

		private int _numberOfCrateFinished;

		private int _pendingComboCoinsThisSession;

		private int _pillsDeliveredThisSession;

		private bool _level0TutorialFirstDropStepShown;

		[SerializeField]
		private CrateView _view;

		[SerializeField]
		private CrateVisualConfigProvider _configProvider;

		private CrateProgressTracker _progressTracker;

		private WinConditionChecker _winChecker;

		private ILevelRunStats _levelRunStats;

		private BoosterConfigSO _boosterConfig;

		private TailManager _tailManager;

		private readonly Queue<BoomerangSkyFruit> _boomerangSkyQueue;

		private readonly Queue<BoomerangPlanEntry> _boomerangLaunchPlan;

		private readonly Dictionary<Transform, Vector3> _boomerangOriginalPositions;

		public IReadOnlyList<CrateColumn> Columns => null;

		public bool BlockNextActivation { get; set; }

		public event Action<PillKind> CrateCompleted
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

		public static event Action<PillKind, int, float> OnSendingOneSegmentToCrate
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

		public static event Action OnDeliveryIdle
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
		public void Construct(BoosterConfigSO boosterConfig, TailManager tailManager, Transform boomerangFlightVfxParent)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private static void RemoveFromQueue(CrateColumn column, CrateData crate)
		{
		}

		public List<CrateDeliverPoint> GetPotentialDeliveryPoints(bool requireEnoughToFill = false)
		{
			return null;
		}

		public bool CanUseCannon(bool requireEnoughToFill = false)
		{
			return false;
		}

		public static int GetTotalCrates()
		{
			return 0;
		}

		public static int GetTotalRequired()
		{
			return 0;
		}

		public static int GetTotalRemaining()
		{
			return 0;
		}

		public static Dictionary<PillKind, int> GetTailColorCount()
		{
			return null;
		}

		public static Dictionary<PillKind, int> GetRemainingPerKind()
		{
			return null;
		}

		public GameObject GetFirstActiveCrateObject()
		{
			return null;
		}

		public void RefreshCannonAvailability()
		{
		}

		private void GiveCoins(int amount)
		{
		}

		private void EndComboSession()
		{
		}

		private void ResetPointDelivery()
		{
		}

		public void OnSwipeUpDelivery()
		{
		}

		[Button("DEBUG: Cannon Delivery (Choosing column)")]
		public void CannonDeliveryColumn(int colIndex)
		{
		}

		private void ShootCutSegmentToMatchingCrate(Transform pillTransform, PillKind pillKind)
		{
		}

		public int GetTotalCrateCount()
		{
			return 0;
		}

		public int GetTotalRequiredAllCrates()
		{
			return 0;
		}

		public int GetTotalRemainingToDeliverRaw()
		{
			return 0;
		}

		private void OnUpdatingTailColors(Dictionary<PillKind, int> tailKindCount)
		{
		}

		private void OnTriggerBoosterFocus(BoosterId type)
		{
		}

		private void OnCancelBoosterFocus(BoosterId type)
		{
		}

		private void CacheLanes()
		{
		}

		private void OnLevelBuilt(LevelDataSO data, LevelMeta levelMeta)
		{
		}

		private void BlockDeliverySwipe()
		{
		}

		private void AllowDeliverySwipe()
		{
		}

		private void OnTailCollision()
		{
		}

		private void OnTouchingCannonArrow(int deliveryPointIndex)
		{
		}

		private void OnSwipe(DirectionPlayer direction)
		{
		}

		private void OnArrivedAtDeliverPoint(int pointIndex)
		{
		}

		private void OnLeftCrate()
		{
		}

		[IteratorStateMachine(typeof(_003CDeliverWhileStaying_003Ed__92))]
		private IEnumerator DeliverWhileStaying(CrateColumn column, CrateData crate, int sessionId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCannonDeliveryRoutine_003Ed__93))]
		private IEnumerator CannonDeliveryRoutine(int colIndex)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRunBoomerangSequence_003Ed__94))]
		private IEnumerator RunBoomerangSequence(List<BoomerangPlanEntry> plan, int fallbackPointIndex)
		{
			return null;
		}

		private void LaunchBoomerangFruitToCrate(BoomerangPlanEntry entry, BoomerangSkyFruit fruit)
		{
		}

		private void AnimateBoomerangPillToCrate(Transform pillTransform, CrateData crate, GameObject preAttachedVfx)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForCrateReadyToReceive_003Ed__97))]
		private IEnumerator WaitForCrateReadyToReceive(CrateData crate, CrateColumn column, float maxWaitSeconds)
		{
			return null;
		}

		private void DrainBoomerangSkyQueueDefensively()
		{
		}

		private bool CanDeliverNow()
		{
			return false;
		}

		private void OnPillEaten(Vector3Int cellPos)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateAfterShortDelay_003Ed__101))]
		private IEnumerator UpdateAfterShortDelay()
		{
			return null;
		}

		private void ActivateNextCrate(CrateColumn column, bool instant)
		{
		}

		private void RaiseCrateCompleted(PillKind pillKind)
		{
		}

		public void ResumePendingActivations()
		{
		}

		public bool HasFinishableNextCrateAtActiveColumn()
		{
			return false;
		}

		public void SetupCrateManager(List<ManualColumnSetup> manualColumnSetup, ILevelRunStats levelRunStats, RemoteConfigService remoteConfig = null)
		{
		}

		private void UpdateNextCrateSigns(CrateColumn column)
		{
		}

		private CrateVisualConfig GetVisualVariant(RemoteConfigService remoteConfig)
		{
			return null;
		}

		private void SpawnCratesVisuals()
		{
		}

		private void GenerateManualSetup()
		{
		}

		private void OnDestroyingOneSegment(Transform pillTransform, PillKind pillKind)
		{
		}

		private void EnqueueBoomerangSkyFruit(Transform pillTransform)
		{
		}

		private void PreCaptureBoomerangOriginalPositions(List<BoomerangPlanEntry> plan)
		{
		}

		private void RouteOrphanedPillVisualToCrate(Transform pillTransform, PillKind pillKind)
		{
		}

		private void AnimatePillToCrate(Transform pillTransform, CrateData crate, float jumpHeight = 5f)
		{
		}

		[IteratorStateMachine(typeof(_003CHandlePillAbsorptionAfterJump_003Ed__116))]
		private IEnumerator HandlePillAbsorptionAfterJump(CrateData crate, bool isBoomerang)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRemoveQueuedCrateIfFinished_003Ed__117))]
		private IEnumerator RemoveQueuedCrateIfFinished(CrateColumn column, CrateData crate)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRemoveCrateIfFinished_003Ed__118))]
		private IEnumerator RemoveCrateIfFinished(CrateColumn column, CrateData crate, bool isRevive)
		{
			return null;
		}

		public void UpdateCrateProgress(int tailLength)
		{
		}

		public void ForceLevelComplete()
		{
		}

		private void PlayCrateConfetti(CrateData crate)
		{
		}
	}
}
