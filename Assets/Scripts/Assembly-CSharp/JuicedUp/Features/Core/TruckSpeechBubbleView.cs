using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TruckSpeechBubbleView : CrateSpeechBubbleView
	{
		[SerializeField]
		private MMF_Player _setStateFeedback;

		[SerializeField]
		private MMF_Player _appearFeedback;

		[SerializeField]
		private MMF_Player _disappearFeedback;

		[SerializeField]
		private TextMeshPro _countText;

		[Header("Orientation")]
		[SerializeField]
		private Transform _orientationReference;

		[SerializeField]
		private Transform _sideOrientation;

		[SerializeField]
		private Transform _upOrientation;

		[SerializeField]
		private Transform _downOrientation;

		private int _remainingCount;

		public override void Initialize(int capacity)
		{
		}

		public override void PlayAppear()
		{
		}

		private void ApplyOrientation()
		{
		}

		private Transform ResolveOrientationPivot()
		{
			return null;
		}

		public override void PlayDisappear()
		{
		}

		public override void UpdateCount(int remaining)
		{
		}

		private void UpdateDisplay()
		{
		}
	}
}
