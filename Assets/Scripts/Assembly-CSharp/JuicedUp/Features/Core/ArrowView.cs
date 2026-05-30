using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class ArrowView : MonoBehaviour
	{
		private const string Open = "OpenArrow";

		private const string Close = "ArrowClose";

		[Header("References")]
		[SerializeField]
		private GameObject _objectToToggle;

		[SerializeField]
		private Transform _gateLeft;

		[SerializeField]
		private Transform _gateRight;

		[SerializeField]
		private Transform _shakeOrigin;

		[Header("Animation")]
		[SerializeField]
		private float _rotateAngle;

		[SerializeField]
		private float _animationDuration;

		[SerializeField]
		private float _notAllowedTweenDuration;

		[SerializeField]
		private Vector3 _notAllowedShakeAmount;

		public void Init(ArrowDirection initialDirection)
		{
		}

		public void HandleDirectionChanged(ArrowDirection newDirection)
		{
		}

		public void HandleNotAllowedAnimation()
		{
		}

		public void HandleGateOpen()
		{
		}

		public void HandleGateClose()
		{
		}

		private void AnimateGateOpen()
		{
		}

		private void AnimateGateClose(bool force = false)
		{
		}

		private static Quaternion DirectionToRotation(ArrowDirection direction)
		{
			return default(Quaternion);
		}
	}
}
