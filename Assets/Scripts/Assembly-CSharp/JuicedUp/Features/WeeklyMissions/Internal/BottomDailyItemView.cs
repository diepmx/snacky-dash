using System;
using System.Runtime.CompilerServices;
using JuicedUp.Features.WeeklyMissions.Public;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class BottomDailyItemView : MonoBehaviour, IBottomDailyItemView
	{
		[SerializeField]
		private Button _dailyButton;

		[SerializeField]
		private TextMeshProUGUI _title;

		[Space]
		[SerializeField]
		private GameObject _notificationDot;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _openedAnimationClip;

		[SerializeField]
		private AnimationClip _lockedAnimationClip;

		[SerializeField]
		private AnimationClip _selectedOpenedDayItem;

		[SerializeField]
		private AnimationClip _selectedLockedDayItem;

		public event Action<IBottomDailyItemView> BottomDailyButtonClicked
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

		public void SeTitleText(string text)
		{
		}

		public void SetActiveValueForNotificationDot(bool isActive)
		{
		}

		public void ActivateSelectedOpenedState()
		{
		}

		public void ActivateSelectedLockedState()
		{
		}

		public void ActivateOpenedState()
		{
		}

		public void ActivateLockedState()
		{
		}

		private void OnBottomDailyItemButtonClicked()
		{
		}
	}
}
