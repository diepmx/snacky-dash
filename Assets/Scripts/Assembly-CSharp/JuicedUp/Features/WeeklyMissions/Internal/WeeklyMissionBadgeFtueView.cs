using System;
using System.Runtime.CompilerServices;
using JuicedUp.Features.WeeklyMissions.Public;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionBadgeFtueView : MonoBehaviour, IBadgeFtueView
	{
		[SerializeField]
		private Transform _content;

		[SerializeField]
		private Button _fakeBadgeButton;

		public event Action BadgeButtonClicked
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

		public void SetContentPosition(Vector3 position)
		{
		}

		private void OnBadgeButtonClicked()
		{
		}
	}
}
