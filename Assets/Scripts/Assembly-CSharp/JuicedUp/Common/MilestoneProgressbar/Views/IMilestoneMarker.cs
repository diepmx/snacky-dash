using System;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public interface IMilestoneMarker
	{
		event Action<IMilestoneMarker> MilestoneButtonClicked;

		void SetXPosition(float xPosition);

		void SetEnergyText(string energyText);

		void ActivateClaimedState();

		void ActivateDefaultState();

		void ActivateInfoOpeningState();

		void ActivateInfoClosingState();
	}
}
