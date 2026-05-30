using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TruckFeedbackView : CrateFeedbackView
	{
		[Header("Appear/Exit Feedbacks")]
		[SerializeField]
		private MMF_Player _drivingFeedback;

		[SerializeField]
		private MMF_Player _stopFeedback;

		[SerializeField]
		private MMF_Player _startFeedback;

		[Header("Fruits Feedback")]
		[SerializeField]
		private MMF_Player _collectFruitFeedback;

		[Header("Lids Animations")]
		[SerializeField]
		private List<Transform> _lidPivots;

		[SerializeField]
		private float _closeLidDelay;

		[SerializeField]
		private float _closeLidDuration;

		[SerializeField]
		private Ease _closeLidEase;

		public override void OnBeginTransitionToActive()
		{
		}

		public override void OnArrivedAtActive()
		{
		}

		public override void OnBeginTransitionToExit()
		{
		}

		public override void OnFruitCollected()
		{
		}

		public override void OnCloseLid(int lidIndex)
		{
		}
	}
}
