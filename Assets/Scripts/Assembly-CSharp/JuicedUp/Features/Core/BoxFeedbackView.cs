using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class BoxFeedbackView : CrateFeedbackView
	{
		[Header("Appear/Exit Tweens")]
		[SerializeField]
		private float _appearDelay;

		[SerializeField]
		private float _appearDuration;

		[SerializeField]
		private Ease _appearEase;

		[SerializeField]
		private float _appearEaseBack;

		[SerializeField]
		private float _exitDelay;

		[SerializeField]
		private float _exitDuration;

		[SerializeField]
		private Ease _exitEase;

		[SerializeField]
		private float _exitEaseBack;

		[Header("Fruits Feedback")]
		[SerializeField]
		private MMF_Player _collectFruitFeedback;

		[Header("Lids Animations")]
		[SerializeField]
		private List<SpriteRenderer> _lidSprites;

		[SerializeField]
		private float _closeLidDelay;

		[SerializeField]
		private float _closeLidDuration;

		[SerializeField]
		private Ease _closeLidEase;

		private Vector3 _originalScale;

		private void Awake()
		{
		}

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

		private void PlayFeedback(MMF_Player feedback)
		{
		}

		public override void OnCloseLid(int lidIndex)
		{
		}
	}
}
