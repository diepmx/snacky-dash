using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.ChestPopup.Data;
using JuicedUp.Common.ChestPopup.Views;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Notifiers;
using JuicedUp.Common.UI;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;

namespace JuicedUp.Common.ChestPopup.Controllers
{
	public class ChestMilestoneRewardPopupController : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateAsyncBehaviour_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ChestMilestoneRewardPopupController _003C_003E4__this;

			public ChestMilestoneRewardPopupPayload payload;

			private CancellationTokenSource _003ClinkedTokenSource_003E5__2;

			private CancellationTokenSource _003C_003E7__wrap2;

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
		private struct _003CLoadPopup_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string key;

			public ChestMilestoneRewardPopupController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<ChestMilestoneRewardPopupView>.Awaiter _003C_003Eu__1;

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

		private readonly IRequestListener<ChestMilestoneRewardPopupPayload> _requestListener;

		private readonly IRewardHudParticleTickBinder _rewardHudParticleTickBinder;

		private readonly IRewardPresentationService _rewardPresentationService;

		private readonly IHudValueSyncService _hudValueSyncService;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly ICanvasesProvider _canvasesProvider;

		private readonly Dictionary<IReward, IRewardView> _rewardViewsDictionary;

		private IChestMilestoneRewardPopupView _rewardPopupView;

		private string _loadedPopupAssetKey;

		private CancellationTokenSource _tokenSource;

		private bool _isClaimed;

		public ChestMilestoneRewardPopupController(IRequestListener<ChestMilestoneRewardPopupPayload> requestListener, IRewardHudParticleTickBinder rewardHudParticleTickBinder, IRewardPresentationService rewardPresentationService, IHudValueSyncService hudValueSyncService, IManagedAssetLoader managedAssetLoader, IRewardViewFactory rewardViewFactory, ICanvasesProvider canvasesProvider)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnPopupRequested(ChestMilestoneRewardPopupPayload payload)
		{
		}

		[AsyncStateMachine(typeof(_003CActivateAsyncBehaviour_003Ed__16))]
		private UniTask ActivateAsyncBehaviour(ChestMilestoneRewardPopupPayload payload)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadPopup_003Ed__17))]
		private UniTask LoadPopup(string key, CancellationToken token)
		{
			return default(UniTask);
		}

		private void SetupRewards(IEnumerable<IReward> rewards)
		{
		}

		private void ActivateRewardParticles(IEnumerable<IReward> rewards)
		{
		}

		private void OnClaimButtonClicked()
		{
		}

		private void OnRewardArrived(IReward reward)
		{
		}

		private void OnSingleParticleArrivedWithDelta(IReward reward, int delta)
		{
		}

		private void OnCompleted()
		{
		}

		private void Clear()
		{
		}
	}
}
