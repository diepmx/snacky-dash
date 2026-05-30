using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Views
{
	public interface IRewardPopupView
	{
		Transform FreeRewardsContainer { get; }

		Transform NoAdsRewardFlyTarget { get; }

		GameObject RewardParent { get; }

		event Action TapToClaimButtonClicked;

		void SetPopupTitle(string title);

		UniTask Show(CancellationToken token);

		UniTask Hide(CancellationToken token);
	}
}
