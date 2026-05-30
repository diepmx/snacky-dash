using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.ChestPopup.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.FeatureOriented.Views;
using JuicedUp.Common.MilestoneProgressbar.Controllers;
using JuicedUp.Common.Network;
using JuicedUp.Common.Time;
using JuicedUp.Common.Tooltips.Controllers;
using JuicedUp.Common.UI;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.WeeklyMissions.Public;
using VContainer;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal sealed class WeeklyMissionsPopupController : IWeeklyMissionsPopupController, IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateControllerLoop_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

			public CancellationToken token;

			private CancellationTokenSource _003ClinkedTokenSource_003E5__2;

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
		private struct _003CExecute_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitBottomDailyItemsController_003Ed__50 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitDailyMissionsController_003Ed__51 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitProgressbarController_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadWeeklyMissionsPopup_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<WeeklyMissionsPopupView>.Awaiter _003C_003Eu__1;

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
		private struct _003CLoadWeeklyMissionsPopupFtue_003Ed__53 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<FeatureFtuePopupView>.Awaiter _003C_003Eu__1;

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
		private struct _003CPrewarmAssets_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsPopupController _003C_003E4__this;

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

		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly INetworkConnectionProvider _networkConnectionProvider;

		private readonly IFeatureAvailabilityProvider _featureStatusProvider;

		private readonly WeeklyMissionsMilestonesHandler _milestonesHandler;

		private readonly IDailyMissionsDescription _missionsDescription;

		private readonly IWeeklyMissionsFacade _weeklyMissionsFacade;

		private readonly IServerTimeProvider _serverTimeProvider;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly IRewardViewSetuper _rewardViewSetuper;

		private readonly IChestsDescription _chestsDescription;

		private readonly IRewardHudRegister _rewardHudRegister;

		private readonly ICanvasesProvider _canvasesProvider;

		private readonly IMilestoneFacade _milestoneFacade;

		private readonly IEconomyService _economyService;

		private readonly IWeeklyMissionsAnalyticsSender _analyticsSender;

		private IMilestoneProgressbarController _milestoneProgressbarController;

		private IBottomDailyItemController _bottomDailyItemController;

		private IDailyMissionsController _dailyMissionsController;

		private ITooltipController _tooltipController;

		private TimerHandler _timerHandler;

		private IWeeklyMissionsPopupView _weeklyMissionsPopupView;

		private FeatureFtuePopupView _weeklyMissionsPopupFtueView;

		private CancellationTokenSource _controllerTokenSource;

		private IDisposable _featureStatusSubscription;

		private IDisposable _networkStatusSubscription;

		private string _impressionTrigger;

		private bool _isDeactivationRequested;

		private bool _isActive;

		public WeeklyMissionsPopupController(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, INetworkConnectionProvider networkConnectionProvider, WeeklyMissionsMilestonesHandler milestonesHandler, IDailyMissionsDescription missionsDescription, [Key(FeatureIds.WeeklyMissions)] IFeatureAvailabilityProvider featureStatusProvider, IWeeklyMissionsFacade weeklyMissionsFacade, IServerTimeProvider serverTimeProvider, IManagedAssetLoader managedAssetLoader, IRewardViewFactory rewardViewFactory, IRewardViewSetuper rewardViewSetuper, IChestsDescription chestsDescription, IRewardHudRegister rewardHudRegister, ICanvasesProvider canvasesProvider, IMilestoneFacade milestoneFacade, IEconomyService economyService, IWeeklyMissionsAnalyticsSender analyticsSender)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CActivateControllerLoop_003Ed__32))]
		public UniTask ActivateControllerLoop(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__33))]
		public UniTask Initialize(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CExecute_003Ed__34))]
		public UniTask Execute(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask Deactivate(CancellationToken token)
		{
			return default(UniTask);
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnFeatureInitialized(bool isInitialized)
		{
		}

		private void OnCurrentWeeklyMissionCompleted()
		{
		}

		private void OnNetworkStatusChanged(bool isOnline)
		{
		}

		private void OnTimerTicked(TimeSpan time)
		{
		}

		private void OnTimerEnded()
		{
		}

		private void OnCloseButtonClicked()
		{
		}

		private void OnInfoButtonClicked()
		{
		}

		[AsyncStateMachine(typeof(_003CPrewarmAssets_003Ed__45))]
		private UniTask PrewarmAssets(CancellationToken token)
		{
			return default(UniTask);
		}

		private void SendImpressionEvent()
		{
		}

		private void ActivateFtuePopupView()
		{
		}

		private void InitTimerHandler(CancellationToken token)
		{
		}

		[AsyncStateMachine(typeof(_003CInitProgressbarController_003Ed__49))]
		private UniTask InitProgressbarController(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInitBottomDailyItemsController_003Ed__50))]
		private UniTask InitBottomDailyItemsController(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInitDailyMissionsController_003Ed__51))]
		private UniTask InitDailyMissionsController(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadWeeklyMissionsPopup_003Ed__52))]
		private UniTask LoadWeeklyMissionsPopup(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadWeeklyMissionsPopupFtue_003Ed__53))]
		private UniTask LoadWeeklyMissionsPopupFtue(CancellationToken token)
		{
			return default(UniTask);
		}

		private void Clear()
		{
		}
	}
}
