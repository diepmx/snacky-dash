using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.ChestPopup.Data;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Controllers;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.UI;
using JuicedUp.Features.Ads.Scripts.Controllers;
using JuicedUp.Features.Core;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Controllers
{
	internal class RewardPopupViewController : IRewardPopupViewController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivate_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPopupViewController _003C_003E4__this;

			public RewardPopupPayload payload;

			public CancellationToken cancellationToken;

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
		private struct _003CLoadPopup_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string assetKey;

			public RewardPopupViewController _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask<JuicedUp.Common.Economy.Internal.Views.RewardPopupView>.Awaiter _003C_003Eu__1;

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
		private struct _003CSetupRewards_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPopupViewController _003C_003E4__this;

			public IReadOnlyList<IReward> rewards;

			public CancellationToken cancellationToken;

			private int _003Ci_003E5__2;

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

		private const float RewardsDelaySpawn = 0.1f;

		private readonly IRewardHudParticleTickBinder _rewardHudParticleTickBinder;

		private readonly IRewardPresentationService _rewardPresentationService;

		private readonly INoAdsFtueController _noAdsFtueController;

		private readonly IHudValueSyncService _hudValueSyncService;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private readonly IChestsDescription _chestsDescription;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly ICanvasesProvider _canvasesProvider;

		private IRewardPopupView _view;

		private string _loadedPopupAssetKey;

		private List<GameObject> _rewardParents;

		private List<IRewardView> _rewardViews;

		private List<IReward> _sortedRewards;

		private RewardPopupPayload _payload;

		public RewardPopupViewController(IRewardHudParticleTickBinder rewardHudParticleTickBinder, IRewardPresentationService rewardPresentationService, IHudValueSyncService hudValueSyncService, INoAdsFtueController noAdsFtueController, IManagedAssetLoader managedAssetLoader, IRewardViewFactory rewardViewFactory, IChestsDescription chestsDescription, ICanvasesProvider canvasesProvider)
		{
		}

		[AsyncStateMachine(typeof(_003CActivate_003Ed__16))]
		public UniTask Activate(RewardPopupPayload payload, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Deactivate()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadPopup_003Ed__18))]
		private UniTask LoadPopup(string assetKey, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void UnloadPopupInstance()
		{
		}

		private void SetupTitle(string localizedTitleKey)
		{
		}

		private void SetupRewardParents(IReadOnlyList<IReward> rewards)
		{
		}

		private void TryToSetupChest(RarityType rarityType)
		{
		}

		[AsyncStateMachine(typeof(_003CSetupRewards_003Ed__23))]
		private UniTask SetupRewards(IReadOnlyList<IReward> rewards, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void OnTapToClaimButtonClicked()
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
	}
}
