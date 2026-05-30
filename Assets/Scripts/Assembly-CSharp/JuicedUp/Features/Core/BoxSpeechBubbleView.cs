using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class BoxSpeechBubbleView : CrateSpeechBubbleView
	{
		[SerializeField]
		private MMF_Player _appearFeedback;

		[SerializeField]
		private MMF_Player _disappearFeedback;

		[SerializeField]
		private TextMeshPro _countText;

		private int _remainingCount;

		public override void Initialize(int capacity)
		{
		}

		public override void PlayAppear()
		{
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
