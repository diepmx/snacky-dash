using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Features.Core;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class BottomDailyItemController : IBottomDailyItemController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BottomDailyItemController _003C_003E4__this;

			public BottomDailyItemsPayload payload;

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
		private struct _003CLoadAllDailyItems_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BottomDailyItemController _003C_003E4__this;

			public CancellationToken token;

			private int _003CdailyMissionsCount_003E5__2;

			private int _003Ci_003E5__3;

			private UniTask<BottomDailyItemView>.Awaiter _003C_003Eu__1;

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

		private readonly IManagedAssetLoader _managedAssetLoader;

		private IBottomDailyItemView[] _bottomDailyItemViews;

		private BottomDailyItemsPayload _payload;

		private IDisposable _facadeSubscription;

		public BottomDailyItemController(IManagedAssetLoader managedAssetLoader)
		{
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__5))]
		public UniTask Initialize(BottomDailyItemsPayload payload, CancellationToken token)
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

		private void OnCurrentMissionsChanged(int dayIndex)
		{
		}

		private void OnMissionClaimed(MissionData missionData)
		{
		}

		private void OnBottomDailyButtonClicked(IBottomDailyItemView clickedView)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAllDailyItems_003Ed__13))]
		private UniTask LoadAllDailyItems(CancellationToken token)
		{
			return default(UniTask);
		}

		private string SelectLoadedPrefabKeyByOrder(int orderIndex)
		{
			return null;
		}

		private void ChangeDailyItemsStates()
		{
		}
	}
}
