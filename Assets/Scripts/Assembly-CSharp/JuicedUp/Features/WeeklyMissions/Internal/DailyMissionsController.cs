using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class DailyMissionsController : IDailyMissionsController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public DailyMissionsController _003C_003E4__this;

			public DailyMissionsPayload payload;

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
		private struct _003CSetupMissionsDataToVew_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public DailyMissionsController _003C_003E4__this;

			public MissionData[] missions;

			public CancellationToken token;

			private bool _003CisLocked_003E5__2;

			private float _003CupdateDelay_003E5__3;

			private List<MissionData> _003CclaimedMissionDataList_003E5__4;

			private int _003ClastDailyMissionContainerIndex_003E5__5;

			private int _003Ci_003E5__6;

			private UniTask.Awaiter _003C_003Eu__1;

			private List<MissionData>.Enumerator _003C_003E7__wrap6;

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

		private const string ProgressTextFormat = "{0}/{1}";

		private Dictionary<IDailyMissionView, MissionData> _dailyMissionDataByView;

		private Dictionary<MissionData, IDailyMissionView> _dailyMissionViewByData;

		private DailyMissionsPayload _payload;

		private CancellationTokenSource _setupAnimationTokenSource;

		private IDisposable _facadeSubscription;

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__6))]
		public UniTask Initialize(DailyMissionsPayload payload, CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask Execute(CancellationToken token)
		{
			return default(UniTask);
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

		private void OnCurrentMissionsChanged(int currentDayIndex)
		{
		}

		[AsyncStateMachine(typeof(_003CSetupMissionsDataToVew_003Ed__12))]
		private UniTask SetupMissionsDataToVew(MissionData[] missions, CancellationToken token)
		{
			return default(UniTask);
		}

		private void SubscribeDailyMissionViews()
		{
		}

		private void UnsubscribeDailyMissionViews()
		{
		}

		private void OnClaimButtonClicked(IDailyMissionView dailyMissionView)
		{
		}

		private void OnMissionClaimed(MissionData missionData)
		{
		}

		private void ActivateClaimBehaviour(IDailyMissionView dailyMissionView, MissionData missionData)
		{
		}

		private void LowerClaimedMissionView(IDailyMissionView dailyMissionView)
		{
		}
	}
}
