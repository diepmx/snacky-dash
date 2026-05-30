using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.MilestoneProgressbar.Handlers;
using JuicedUp.Common.MilestoneProgressbar.Views;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionMilestoneMarkersHandler : IFeatureOrientedMilestoneMarkersHandler
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateMilestoneInfoFlow_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public WeeklyMissionMilestoneMarkersHandler _003C_003E4__this;

			public IMilestoneMarker clickedMilestone;

			public IMilestone milestoneData;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<int>.Awaiter _003C_003Eu__2;

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

		private readonly IMilestoneFacade _milestoneFacade;

		private readonly IRewardViewSetuper _rewardViewSetuper;

		private IReadOnlyDictionary<IMilestoneMarker, IMilestone> _milestoneDataByMarkers;

		private bool _isEnergyShowed;

		private CancellationTokenSource _energyShowTokenSource;

		public WeeklyMissionMilestoneMarkersHandler(IMilestoneFacade milestoneFacade, IRewardViewSetuper rewardViewSetuper)
		{
		}

		public void Activate(IReadOnlyDictionary<IMilestoneMarker, IMilestone> milestoneDataByMarkers)
		{
		}

		public void Deactivate()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnMilestoneMarkerClicked(IMilestoneMarker clickedMilestoneMarker)
		{
		}

		[AsyncStateMachine(typeof(_003CActivateMilestoneInfoFlow_003Ed__11))]
		private UniTaskVoid ActivateMilestoneInfoFlow(IMilestoneMarker clickedMilestone, IMilestone milestoneData)
		{
			return default(UniTaskVoid);
		}

		private void SetupInfoTooltip(IRewardView[] rewardViews, IReward[] rewards)
		{
		}
	}
}
