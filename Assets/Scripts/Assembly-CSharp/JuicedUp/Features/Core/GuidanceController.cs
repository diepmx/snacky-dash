using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class GuidanceController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunGuidanceCycleAsync_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public GuidanceController _003C_003E4__this;

			public CancellationToken token;

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

		private const int BridgeFollowupSkipCells = 1;

		private readonly Player _player;

		private readonly SwipeController _swipeController;

		private readonly PillManager _pillManager;

		private readonly GuidanceConfig _config;

		private readonly GuidanceArrowView _arrowPrefab;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly GuidanceArrowView _bridgeArrowPrefab;

		private readonly IPopupService _popupService;

		private GuidanceDirectionResolver _directionResolver;

		private GuidanceArrowPool _arrowPool;

		private GuidanceArrowPool _bridgeArrowPool;

		private Transform _arrowParent;

		private CancellationTokenSource _cts;

		private Sequence _animationSequence;

		private bool _isActive;

		private bool _isAtDeliveryPoint;

		private bool _arrowsVisible;

		private bool _deliveryIdleReceived;

		private bool _popupSubscribed;

		public GuidanceController(Player player, SwipeController swipeController, PillManager pillManager, GuidanceConfig config, GuidanceArrowView arrowPrefab, IGameStateEvents gameStateEvents, GuidanceArrowView bridgeArrowPrefab, IPopupService popupService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void SubscribeToPopupEvents()
		{
		}

		private void UnsubscribeFromPopupEvents()
		{
		}

		private void OnPopupShown(PopupId _)
		{
		}

		private void OnPopupHidden(PopupId _)
		{
		}

		private void OnForcedPhaseEnded()
		{
		}

		private void ActivateGuidance()
		{
		}

		public void Dispose()
		{
		}

		private bool ShouldRun()
		{
			return false;
		}

		private static void DisableLegacyAdvisor()
		{
		}

		private void OnArrivedAtCrate(int crateIndex)
		{
		}

		private void OnLeftCrate()
		{
		}

		private void OnDeliveryIdle()
		{
		}

		private void OnSendingOneSegmentToCrate(PillKind _, int __, float ___)
		{
		}

		private void OnPlayerStopped()
		{
		}

		[AsyncStateMachine(typeof(_003CRunGuidanceCycleAsync_003Ed__36))]
		private UniTask RunGuidanceCycleAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private GuidanceArrowView AcquireArrowFor(GuidanceCell guidanceCell, out bool isBridge)
		{
			isBridge = default(bool);
			return null;
		}

		private void OnGameStateChanged(GameState state, DefeatType defeatType)
		{
		}

		private void CancelCurrentCycle()
		{
		}

		private Sequence BuildAnimationSequence(List<GuidanceArrowView> arrows)
		{
			return null;
		}
	}
}
