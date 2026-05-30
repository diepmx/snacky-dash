using UnityEngine;
using UnityEngine.EventSystems;

namespace JuicedUp.Common.UI
{
	public class SwipeUiInputHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField]
		private MonoBehaviour _target;

		private const float SwipeThresholdRatio = 0.04f;

		private const float HorizontalDominanceRatio = 1.1f;

		private ISwipeUiTarget _swipeUiTarget;

		private Vector2 _startPos;

		private bool _rejected;

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		private SwipeDirection Evaluate(Vector2 endPosition)
		{
			return default(SwipeDirection);
		}
	}
}
