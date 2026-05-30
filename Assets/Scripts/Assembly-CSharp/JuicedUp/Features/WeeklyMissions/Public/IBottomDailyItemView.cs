using System;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IBottomDailyItemView
	{
		event Action<IBottomDailyItemView> BottomDailyButtonClicked;

		void SeTitleText(string text);

		void SetActiveValueForNotificationDot(bool isActive);

		void ActivateSelectedOpenedState();

		void ActivateSelectedLockedState();

		void ActivateOpenedState();

		void ActivateLockedState();
	}
}
