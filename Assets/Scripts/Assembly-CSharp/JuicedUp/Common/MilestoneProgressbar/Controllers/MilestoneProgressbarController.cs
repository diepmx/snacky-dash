using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.ChestPopup.Data;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Common.MilestoneProgressbar.Data;
using JuicedUp.Common.MilestoneProgressbar.Views;
using JuicedUp.Features.Core;

namespace JuicedUp.Common.MilestoneProgressbar.Controllers
{
	public class MilestoneProgressbarController : IMilestoneProgressbarController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MilestoneProgressbarController _003C_003E4__this;

			public MilestoneProgressbarPayload payload;

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
		private struct _003CLoadAllMilestoneMarkers_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MilestoneProgressbarController _003C_003E4__this;

			public CancellationToken token;

			private IReadOnlyList<IMilestone> _003Cmilestones_003E5__2;

			private float _003Cgap_003E5__3;

			private int _003Ci_003E5__4;

			private UniTask<IMilestoneMarker>.Awaiter _003C_003Eu__1;

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
		private struct _003CSetupAsChestMilestone_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<IMilestoneMarker> _003C_003Et__builder;

			public MilestoneProgressbarController _003C_003E4__this;

			public CancellationToken token;

			public IMilestone milestone;

			private UniTask<ChestMilestone>.Awaiter _003C_003Eu__1;

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
		private struct _003CSetupAsSingleRewardMilestone_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<IMilestoneMarker> _003C_003Et__builder;

			public MilestoneProgressbarController _003C_003E4__this;

			public CancellationToken token;

			public IMilestone milestone;

			private UniTask<SingleRewardMilestone>.Awaiter _003C_003Eu__1;

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

		private readonly IChestsDescription _chestsDescription;

		private readonly IEconomyService _economyService;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private readonly IRewardViewSetuper _rewardViewSetuper;

		private readonly IRewardHudRegister _rewardHudRegister;

		private CancellationTokenSource _controllerTokenSource;

		private Dictionary<IMilestoneMarker, IMilestone> _milestoneDataByMarkers;

		private Dictionary<IMilestone, IMilestoneMarker> _milestoneMarkersByData;

		private MilestoneProgressbarPayload _payload;

		private CancellationTokenSource _valueUpdateTokenSource;

		public MilestoneProgressbarController(IChestsDescription chestsDescription, IEconomyService economyService, IManagedAssetLoader managedAssetLoader, IRewardViewSetuper rewardViewSetuper, IRewardHudRegister rewardHudRegister)
		{
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__11))]
		public UniTask Initialize(MilestoneProgressbarPayload payload, CancellationToken token)
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

		private void CleanupLoadedObjects()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAllMilestoneMarkers_003Ed__17))]
		private UniTask LoadAllMilestoneMarkers(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CSetupAsSingleRewardMilestone_003Ed__18))]
		private UniTask<IMilestoneMarker> SetupAsSingleRewardMilestone(IMilestone milestone, CancellationToken token)
		{
			return default(UniTask<IMilestoneMarker>);
		}

		[AsyncStateMachine(typeof(_003CSetupAsChestMilestone_003Ed__19))]
		private UniTask<IMilestoneMarker> SetupAsChestMilestone(IMilestone milestone, CancellationToken token)
		{
			return default(UniTask<IMilestoneMarker>);
		}

		private void SetupGrandMilestone()
		{
		}

		private void OnProgressbarValueChangeRequested(float value, float updateDuration)
		{
		}

		private void OnMilestoneDataClaimed(IMilestone milestoneData)
		{
		}

		private void SetStartProgressbarValue()
		{
		}
	}
}
