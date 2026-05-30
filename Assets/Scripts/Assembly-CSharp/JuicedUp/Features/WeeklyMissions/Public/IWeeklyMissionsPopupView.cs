using System;
using JuicedUp.Common.MilestoneProgressbar.Views;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IWeeklyMissionsPopupView
	{
		IMilestoneProgressBarView MilestoneProgressBarView { get; }

		IDailyMissionContainer[] DailyMissionContainers { get; }

		Transform BottomBar { get; }

		event Action CloseButtonClicked;

		event Action InfoButtonClicked;

		void Show();

		void Hide();

		void SetTimerText(string text);

		void SetOfflineModeValue(bool isOffline);
	}
}
