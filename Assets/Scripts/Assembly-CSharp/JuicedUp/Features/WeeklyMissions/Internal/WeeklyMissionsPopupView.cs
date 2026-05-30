using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.MilestoneProgressbar.Views;
using JuicedUp.Features.WeeklyMissions.Public;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsPopupView : MonoBehaviour, IWeeklyMissionsPopupView
	{
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _infoButton;

		[Space]
		[SerializeField]
		private TextMeshProUGUI _timer;

		[Space]
		[SerializeField]
		private GameObject _offlineMode;

		[SerializeField]
		private Transform _bottomBar;

		[SerializeField]
		private DailyMissionContainer[] _dailyMissionContainers;

		[Space]
		[SerializeField]
		private MilestoneProgressBarView _milestoneProgressBarView;

		public IMilestoneProgressBarView MilestoneProgressBarView => null;

		public IDailyMissionContainer[] DailyMissionContainers => null;

		public Transform BottomBar => null;

		public event Action CloseButtonClicked
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

		public event Action InfoButtonClicked
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

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void SetTimerText(string text)
		{
		}

		public void SetOfflineModeValue(bool isOffline)
		{
		}

		private void OnCloseButtonClicked()
		{
		}

		private void OnInfoButtonClicked()
		{
		}
	}
}
