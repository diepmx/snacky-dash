using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.MilestoneProgressbar.Handlers;
using JuicedUp.Features.WeeklyMissions.Public;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsMilestonesHandler : IMilestonesHandler, IProgressbarValueHandler
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateQueueCleaning_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionsMilestonesHandler _003C_003E4__this;

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
		private struct _003CUpdateProgressBarAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Vector2 values;

			public WeeklyMissionsMilestonesHandler _003C_003E4__this;

			private float _003ClastWeeklyMissionEnergy_003E5__2;

			private float _003CnewWeeklyMissionEnergy_003E5__3;

			private IMilestone[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private IMilestone _003Cmilestone_003E5__6;

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

		private const float ProgressBarUpdateDuration = 0.25f;

		private readonly IWeeklyMissionsDataProvider _weeklyMissionsDataProvider;

		private readonly IRewardPopupViewController _rewardPopupViewController;

		private readonly IEconomyOperationsNotifier _economyOperationsNotifier;

		private readonly IMilestoneFacade _milestoneFacade;

		private readonly IEconomyService _economyService;

		private readonly IWallet _wallet;

		private readonly Queue<Vector2> _balanceUpdateQueue;

		private IMilestone _readyToClaimMilestone;

		private bool _isReadyGoToNextMilestone;

		private bool _isActiveQueueCleaning;

		public float StartProgressbarValue => 0f;

		public event Action<float, float> ProgressbarValueChangeRequested
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

		public event Action<IMilestone> MilestoneClaimed
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

		public WeeklyMissionsMilestonesHandler(IWeeklyMissionsDataProvider weeklyMissionsDataProvider, IRewardPopupViewController rewardPopupViewController, IEconomyOperationsNotifier economyOperationsNotifier, IMilestoneFacade milestoneFacade, IEconomyService economyService, IWallet wallet)
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		private void OnRewardGranted(IReward reward)
		{
		}

		[AsyncStateMachine(typeof(_003CActivateQueueCleaning_003Ed__23))]
		private UniTask ActivateQueueCleaning()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUpdateProgressBarAsync_003Ed__24))]
		private UniTask UpdateProgressBarAsync(Vector2 values)
		{
			return default(UniTask);
		}

		private float CalculateProgressBarValue(float weeklyMissionsEnergy)
		{
			return 0f;
		}

		private void SelectClaimBehaviour(IMilestone milestone)
		{
		}

		private void ClaimMilestone()
		{
		}
	}
}
