using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Analytics;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class TutorialController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowOneOffPopupAsync_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public TutorialController _003C_003E4__this;

			public int messageIndex;

			private GameObject _003CmessageObject_003E5__2;

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

		private static readonly string[] StepNames;

		private const int PopLevelTailLengthThreshold = 9;

		private const float TapToContinueDelaySeconds = 2f;

		private static readonly Vector2 PlayerHoleLocalOffset;

		private readonly SwipeController _swipeController;

		private readonly TutorialFocusService _focusService;

		private readonly TutorialPathOverlayService _pathOverlayService;

		private readonly Player _player;

		private readonly TailManager _tailManager;

		private readonly ICoreGameAnalyticsService _analyticsService;

		private readonly TutorialView _tutorialViewPrefab;

		private ForceSwipeZoneUI _popupUi;

		private HandAnimation _handAnimation;

		private TutorialSwipeAdvisor _guidanceAdvisor;

		private CrateManager _crateManager;

		private TutorialView _tutorialView;

		private GameObject _spawnedTutorialInstance;

		private bool _guidanceWasEnabled;

		private bool _isForcedPhaseActive;

		private bool _shouldRun;

		private float _forcedPhaseStartTime;

		private int _tutorialSwipeCount;

		private int _currentLevel;

		private int _pendingPopupMessageIndex;

		private bool _oneOffPopupActive;

		private CancellationTokenSource _oneOffPopupCts;

		private Transform _tapToContinueOriginalParent;

		private bool _hasCachedTapToContinueParent;

		public static event Action OnForcedPhaseEnded
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

		public TutorialController(SwipeController swipeController, TutorialFocusService focusService, TutorialPathOverlayService pathOverlayService, Player player, TailManager tailManager, ICoreGameAnalyticsService analyticsService, TutorialView tutorialViewPrefab)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static bool ShouldRunForCurrentLevel()
		{
			return false;
		}

		public static bool HasForcedPhaseActive()
		{
			return false;
		}

		public bool IsForcedPhaseActive()
		{
			return false;
		}

		private void OnSpawnPlayer()
		{
		}

		private void OnTutorialSwipe(DirectionPlayer direction)
		{
		}

		private void BeginStep(int step)
		{
		}

		private void OnStep0Completed()
		{
		}

		private void OnStep1Completed()
		{
		}

		private void OnStep2Completed()
		{
		}

		private void TrackTutorialStep(int stepIndex)
		{
		}

		private void EndForcedPhase()
		{
		}

		private void ShowPopup(SwipeController.DirMask directionMask)
		{
		}

		private void HidePopup()
		{
		}

		private void ShowHand(DirectionPlayer direction)
		{
		}

		private void HideHand()
		{
		}

		private void SpawnTutorialView()
		{
		}

		private void DestroyTutorialView()
		{
		}

		private void HideLegacyTutorialVisuals()
		{
		}

		private void ShowStepTutorialMessage(int step)
		{
		}

		private void HighlightForcedPath(DirectionPlayer direction)
		{
		}

		private void HighlightCollectedTailFruits()
		{
		}

		private void OnTailUpdated(int _)
		{
		}

		private void OnFirstBatchCollected()
		{
		}

		private void OnTailLengthReached(int tailLength)
		{
		}

		private void EnqueueOneOffPopup(int messageIndex)
		{
		}

		private void OnPlayerStoppedForPopup()
		{
		}

		private void FlushPendingPopup()
		{
		}

		[AsyncStateMachine(typeof(_003CShowOneOffPopupAsync_003Ed__60))]
		private UniTask ShowOneOffPopupAsync(int messageIndex)
		{
			return default(UniTask);
		}

		private void DismissOneOffPopup()
		{
		}

		private void SetTapToContinueVisible(bool visible, GameObject parentMessage = null)
		{
		}

		private void HighlightFinalStageTruck()
		{
		}

		private void ResolveSceneReferences()
		{
		}

		private static T FindSceneComponent<T>() where T : Component
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
