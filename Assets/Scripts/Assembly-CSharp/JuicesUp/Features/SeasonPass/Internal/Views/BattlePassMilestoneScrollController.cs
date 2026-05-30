using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneScrollController : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private RectTransform _viewport;

		[SerializeField]
		private RectTransform _content;

		private Tween _scrollTween;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void StopScrollAnimation()
		{
		}

		public void ScrollFromBottomToTop(float normalizedSpeed, float endCallbackDelay, Action onComplete)
		{
		}

		public void CenterOnIndex(IReadOnlyList<BattlePassMilestoneView> milestoneViews, int index)
		{
		}

		private bool CanControlScroll()
		{
			return false;
		}

		private void RefreshLayout()
		{
		}

		private float GetNormalizedPositionForCenter(RectTransform item)
		{
			return 0f;
		}

		private void InvokeWithDelay(float delay, Action onComplete)
		{
		}
	}
}
