using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Tutorial
{
	[DisallowMultipleComponent]
	public sealed class BoosterTutorialArrowBob : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Arrow RectTransform to bob. Required - typically the GameObject this component is attached to.")]
		private RectTransform _arrowTransform;

		[SerializeField]
		[Min(0f)]
		[Tooltip("Half-period of the bob Yoyo loop, in seconds.")]
		private float _bobDuration;

		[SerializeField]
		[Tooltip("Distance the arrow travels at the end of the bob, in the arrow's local anchored-position units. Positive X = right, negative X = left, positive Y = up, negative Y = down. Author the axis you want by zeroing the other component.")]
		private Vector2 _bobOffset;

		private Tween _bobTween;

		private Vector2 _baseAnchoredPosition;

		private bool _baseCaptured;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void CaptureBaseIfNeeded()
		{
		}

		private void StartBob()
		{
		}

		private void StopBob()
		{
		}
	}
}
