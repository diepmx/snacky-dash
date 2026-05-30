using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Common.ChestPopup.Views
{
	public interface IChestMilestoneRewardPopupView
	{
		Transform GetFreeRewardsContainer { get; }

		GameObject GameObject { get; }

		event Action ClaimButtonClicked;

		UniTask Show(CancellationToken token);

		UniTask Hide(CancellationToken token);

		UniTask ActivateWaitingState(CancellationToken token);

		UniTask ActivateClaimedState(CancellationToken token);
	}
}
