using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Boosters.Config;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public sealed class BoosterForcedTutorialController : IAsyncInitializable, IDisposable
	{
		private enum FlowState
		{
			Idle = 0,
			Popup = 1,
			AwaitingTrigger = 2,
			Spotlight = 3,
			AwaitingActivation = 4
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunFlowAsync_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken token;

			public BoosterForcedTutorialController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShowPopupAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BoosterForcedTutorialController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__1;

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

		private const int FlowStartDelayMs = 300;

		private readonly IBoosterTutorialRepository _repository;

		private readonly BoosterConfigSO _config;

		private readonly TutorialFocusService _focusService;

		private readonly SwipeController _swipeController;

		private readonly TailManager _tailManager;

		private readonly CrateManager _crateManager;

		private readonly IPopupService _popupService;

		private readonly BoosterTutorialState _tutorialState;

		private readonly BoosterButtonUI[] _boosterButtons;

		private readonly BoosterManager _boosterManager;

		private readonly Loading _loading;

		private readonly TutorialController _tutorialController;

		private readonly IBoosterCatalog _boosterCatalog;

		private readonly IAssetLoader _assetLoader;

		private readonly IGameStateReader _gameStateReader;

		private readonly IGameStateEvents _gameStateEvents;

		private CancellationTokenSource _lifetimeCts;

		private CancellationTokenSource _runCts;

		private IBoosterForcedTutorialView _view;

		private BoosterId _activeBoosterId;

		private FlowState _state;

		private ForcedBoosterFlowType _activeFlowType;

		private int _delayedThreshold;

		private bool _disposed;

		private bool _isMonitoringSpotlight;

		public BoosterForcedTutorialController(IBoosterTutorialRepository repository, BoosterConfigSO config, TutorialFocusService focusService, SwipeController swipeController, TailManager tailManager, CrateManager crateManager, IPopupService popupService, BoosterTutorialState tutorialState, BoosterManager boosterManager, Loading loading, TutorialController tutorialController, IBoosterCatalog boosterCatalog, BoosterButtonUI[] boosterButtons, IAssetLoader assetLoader, IGameStateReader gameStateReader, IGameStateEvents gameStateEvents)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void HandleStartingGame()
		{
		}

		private void TryStartForLevel()
		{
		}

		[AsyncStateMachine(typeof(_003CRunFlowAsync_003Ed__31))]
		private UniTask RunFlowAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CShowPopupAsync_003Ed__32))]
		private UniTask ShowPopupAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private void HandleTailUpdated(int length)
		{
		}

		private bool IsBoosterUsableNow(BoosterId boosterId, int currentTailLength)
		{
			return false;
		}

		private void SkipForcedTutorialAsSeen()
		{
		}

		private void BeginSpotlight()
		{
		}

		private void StartSpotlightMonitoring()
		{
		}

		private void StopSpotlightMonitoring()
		{
		}

		private void HandleSpotlightTailUpdated(int _)
		{
		}

		private void HandleSpotlightArrivedAtCrate(int _)
		{
		}

		private void RecheckUsabilityDuringSpotlight()
		{
		}

		private void AbortActiveSpotlightAsSeen()
		{
		}

		private void HandleBoosterFocusOpened(BoosterId id)
		{
		}

		private void HandleBoosterActivated(BoosterId id)
		{
		}

		private void HandleGameStateChanged(GameState state, DefeatType _)
		{
		}

		private void AbortRun()
		{
		}

		private void DisposeRunCts()
		{
		}

		private void TeardownSpotlight()
		{
		}

		private Transform ResolveBoosterButtonTransform(BoosterId id)
		{
			return null;
		}

		private BoosterButtonUI ResolveBoosterButtonUI(BoosterId id)
		{
			return null;
		}

		private static void LogFlowError(Exception exception)
		{
		}
	}
}
