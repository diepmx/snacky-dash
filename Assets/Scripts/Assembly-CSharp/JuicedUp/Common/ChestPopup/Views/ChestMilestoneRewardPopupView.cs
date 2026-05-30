using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Views;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.ChestPopup.Views
{
	public class ChestMilestoneRewardPopupView : MonoBehaviour, IChestMilestoneRewardPopupView
	{
		[SerializeField]
		private Button _claimButton;

		[Space]
		[SerializeField]
		private RewardsContainer[] _rewardContainers;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _openAnimation;

		[SerializeField]
		private AnimationClip _waitingAnimation;

		[SerializeField]
		private AnimationClip _claimAnimation;

		public Transform GetFreeRewardsContainer => null;

		public GameObject GameObject => null;

		public event Action ClaimButtonClicked
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

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public UniTask Show(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask Hide(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask ActivateWaitingState(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask ActivateClaimedState(CancellationToken token)
		{
			return default(UniTask);
		}

		private Transform SelectFreeRewardsContainer()
		{
			return null;
		}

		private void OnClaimButtonClicked()
		{
		}
	}
}
