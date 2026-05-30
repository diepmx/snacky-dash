using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.QueueManagement;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Scene;
using JuicedUp.Features.WeeklyMissions.Public;
using VContainer;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsAutoClaimHandler : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecuteAutoClaim_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsAutoClaimHandler _003C_003E4__this;

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

		private readonly IRewardPopupViewController _rewardPopupViewController;

		private readonly IFeatureAvailabilityProvider _featureStatusProvider;

		private readonly IWeeklyMissionsFacade _weeklyMissionsFacade;

		private readonly IEconomyService _economyService;

		private readonly ISceneService _sceneService;

		private readonly IActionQueue _queue;

		private IDisposable _featureStatusSubscription;

		public WeeklyMissionsAutoClaimHandler(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, IRewardPopupViewController rewardPopupViewController, [Key(FeatureIds.WeeklyMissions)] IFeatureAvailabilityProvider featureStatusProvider, IWeeklyMissionsFacade weeklyMissionsFacade, IEconomyService economyService, ISceneService sceneService, IActionQueue queue)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnFeatureInitialized(bool isInitialized)
		{
		}

		private void TryToExecuteAutoClaim()
		{
		}

		private bool IsCanShow()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CExecuteAutoClaim_003Ed__14))]
		private UniTask ExecuteAutoClaim(CancellationToken token)
		{
			return default(UniTask);
		}
	}
}
