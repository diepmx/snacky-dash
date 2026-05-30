using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicesUp.Features.SeasonPass.Internal.Core;
using JuicesUp.Features.SeasonPass.Internal.Data;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassUIController : IDisposable, IAsyncInitializable, IBattlePassUIController
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass34_0
		{
			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			internal void _003CShowOfferPopup_003Eb__0(bool success)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInstantiateMainView_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<BattlePassMainView>.Awaiter _003C_003Eu__1;

			private UniTask<Voodoo.Live.Utils.SpriteDictionarySO>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CInstantiateOfferPopup_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<BattlePassOfferView> _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<BattlePassOfferView>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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
		private struct _003CShowOfferPopup_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private _003C_003Ec__DisplayClass34_0 _003C_003E8__1;

			private UniTask<BattlePassOfferView>.Awaiter _003C_003Eu__1;

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
		private struct _003CShowPassEndedFlow_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<BattlePassGenericPopupView>.Awaiter _003C_003Eu__1;

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
		private struct _003CShowPurchaseOverlay_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<BattlePassPurchaseOverlayView>.Awaiter _003C_003Eu__1;

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
		private struct _003CShowPurchaseSuccessPopup_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<BattlePassGenericPopupView>.Awaiter _003C_003Eu__1;

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
		private struct _003CTryShowPassStartedAfterEndAsync_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BattlePassUIController _003C_003E4__this;

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

		private readonly IBattlePassManager _manager;

		private readonly IBattlePassCanvasProvider _canvasProvider;

		private readonly IBattlePassAppBridge _appBridge;

		private readonly IBattlePassAnalytics _analytics;

		private readonly IBattlePassAssetLoader _assetLoader;

		private readonly IDisposable _initSubscription;

		private readonly IBattlePassRewardPresenter _rewardPresenter;

		private readonly CancellationTokenSource _cts;

		private BattlePassMainView _battlePassMainView;

		private BattlePassOfferView _offerView;

		private BattlePassGenericPopupView _purchaseSuccessPopup;

		private BattlePassGenericPopupView _passEndedPopup;

		private BattlePassPurchaseOverlayView _purchaseOverlayView;

		private ISpriteDictionary _rewardSpriteMap;

		private MainViewArgs _mainViewArgs;

		public BattlePassUIController(IBattlePassManager manager, IBattlePassCanvasProvider canvasProvider, IBattlePassAppBridge appBridge, IBattlePassRewardPresenter rewardPresenter, IBattlePassAnalytics analytics, IBattlePassAssetLoader assetLoader)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnGracePeriodStarted()
		{
		}

		private void OnNewSeasonStarted()
		{
		}

		private UniTask ShowStartScreenAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnFtueCompletedAndMainUiClosed(Action done)
		{
		}

		[AsyncStateMachine(typeof(_003CInstantiateMainView_003Ed__22))]
		private UniTask InstantiateMainView(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CShowPassEndedFlow_003Ed__23))]
		private UniTask ShowPassEndedFlow(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnPassEndedComplete(Action done)
		{
		}

		private void OnPassUnclaimedRewardsCompleted(Action done)
		{
		}

		[AsyncStateMachine(typeof(_003CTryShowPassStartedAfterEndAsync_003Ed__26))]
		private UniTask TryShowPassStartedAfterEndAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInstantiateOfferPopup_003Ed__27))]
		private UniTask<BattlePassOfferView> InstantiateOfferPopup(CancellationToken token)
		{
			return default(UniTask<BattlePassOfferView>);
		}

		public void ShowMainView()
		{
		}

		private MainViewArgs CreateMainViewArgs()
		{
			return null;
		}

		private void OnMilestonePressed(BattlePassType type, int milestoneIndex, Transform tooltipParent)
		{
		}

		private void OnMilestoneClaimPressed(BattlePassType type, int milestoneIndex)
		{
		}

		private void OnTutorialsSeen()
		{
		}

		private void OnPurchasedSeen()
		{
		}

		[AsyncStateMachine(typeof(_003CShowOfferPopup_003Ed__34))]
		private UniTask ShowOfferPopup(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CShowPurchaseSuccessPopup_003Ed__35))]
		private UniTask ShowPurchaseSuccessPopup(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnPurchaseSuccessDonePressed()
		{
		}

		public void TriggerPurchaseSuccessDoneForTesting()
		{
		}

		[AsyncStateMachine(typeof(_003CShowPurchaseOverlay_003Ed__38))]
		private UniTask ShowPurchaseOverlay(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnPurchaseOverlayComplete()
		{
		}

		private void OnPurchaseButtonClicked()
		{
		}

		private void OnTokensProcessed(int amount)
		{
		}

		private void OnMainPanelClosing()
		{
		}

		private void TrackImpression(ImpressionTrigger trigger)
		{
		}
	}
}
