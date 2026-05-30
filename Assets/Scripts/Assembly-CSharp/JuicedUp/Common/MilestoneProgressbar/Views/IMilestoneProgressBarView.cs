using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public interface IMilestoneProgressBarView : IProgressBarView
	{
		RectTransform MilestoneMarkersContainer { get; }

		GrandMilestoneView GrandMilestone { get; }

		IRewardHudView EnergyHudView { get; }

		void SetEnergyIcon(Sprite energyIcon);

		void SetFinishEnergyValue(string energyValue);

		void SetCurrentEnergyValue(string energyValue);

		void SetCompletedState(bool isVisible);

		void SetInProgressState(bool isVisible);
	}
}
