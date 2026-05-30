using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IDailyMissionView
	{
		IRewardView EnergyReward { get; }

		IRewardView MissionReward { get; }

		event Action<IDailyMissionView> ClaimButtonClicked;

		void SetLockerValue(bool value);

		void SetNewParent(Transform parent);

		void SetMissionImage(Sprite missionSprite);

		void SetMissionName(string missionName);

		void SetProgressText(string progressText);

		void SetMissionProgress(float currentProgressValue, float maxProgressValue);

		void SetMissionRewardActiveValue(bool value);

		void ActivateLockerShake();

		void ActivateLockerOpening();

		void ActivateReadyToClaimState();

		void ActivateClaimedState();

		void ActivateDefaultState();

		void ActivateDefaultLockedState();

		UniTask ActivateSetupDataState(CancellationToken token);
	}
}
