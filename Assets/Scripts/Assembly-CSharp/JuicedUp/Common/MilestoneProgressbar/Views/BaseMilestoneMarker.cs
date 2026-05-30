using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public class BaseMilestoneMarker : MonoBehaviour, IMilestoneMarker
	{
		[SerializeField]
		private Animation _milestoneMarkerAnimation;

		[SerializeField]
		private AnimationClip _markerInfoOpening;

		[SerializeField]
		private AnimationClip _markerInfoClosing;

		[Space]
		[SerializeField]
		private Button _rewardButton;

		[Space]
		[SerializeField]
		private TextMeshProUGUI _energyText;

		[Space]
		[SerializeField]
		private GameObject _content;

		[SerializeField]
		private GameObject _checkmark;

		private RectTransform _rectTransform;

		public event Action<IMilestoneMarker> MilestoneButtonClicked
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

		public void SetXPosition(float xPosition)
		{
		}

		public void SetEnergyText(string energyText)
		{
		}

		public void ActivateClaimedState()
		{
		}

		public void ActivateDefaultState()
		{
		}

		public void ActivateInfoOpeningState()
		{
		}

		public void ActivateInfoClosingState()
		{
		}

		private void OnRewardButtonClicked()
		{
		}
	}
}
