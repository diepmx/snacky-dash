using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class ArrowView : MonoBehaviour
	{
		private const string Open = "OpenArrow";
		private const string Close = "ArrowClose";

		[Header("References")]
		[SerializeField] private GameObject _objectToToggle;
		[SerializeField] private Transform _gateLeft;
		[SerializeField] private Transform _gateRight;
		[SerializeField] private Transform _shakeOrigin;

		[Header("Animation")]
		[SerializeField] private float _rotateAngle = 60f;
		[SerializeField] private float _animationDuration = 0.25f;
		[SerializeField] private float _notAllowedTweenDuration = 0.2f;
		[SerializeField] private Vector3 _notAllowedShakeAmount = new Vector3(0.15f, 0f, 0f);

		private bool _gateOpen;
		private Tweener _shakeTween;
		private Tweener _gateLeftTween;
		private Tweener _gateRightTween;

		/// <summary>Initialize arrow visual to face the given direction.</summary>
		public void Init(ArrowDirection initialDirection)
		{
			if (_objectToToggle != null)
				_objectToToggle.SetActive(true);

			// Rotate the entire arrow object to face the direction
			transform.rotation = DirectionToRotation(initialDirection);

			// Gates start closed
			_gateOpen = false;
		}

		/// <summary>Called when the arrow direction is flipped/changed.</summary>
		public void HandleDirectionChanged(ArrowDirection newDirection)
		{
			transform.DORotateQuaternion(DirectionToRotation(newDirection), _animationDuration)
				.SetEase(Ease.InOutSine);
		}

		/// <summary>Shake animation to indicate player tried an invalid direction.</summary>
		public void HandleNotAllowedAnimation()
		{
			if (_shakeOrigin == null) return;

			_shakeTween?.Kill();
			Vector3 originalPos = _shakeOrigin.localPosition;
			_shakeTween = _shakeOrigin
				.DOShakePosition(_notAllowedTweenDuration, _notAllowedShakeAmount, vibrato: 10, randomness: 0f)
				.OnComplete(() => _shakeOrigin.localPosition = originalPos);
		}

		/// <summary>Open gate visuals (spread gates apart).</summary>
		public void HandleGateOpen()
		{
			if (_gateOpen) return;
			_gateOpen = true;
			AnimateGateOpen();
		}

		/// <summary>Close gate visuals (bring gates together).</summary>
		public void HandleGateClose()
		{
			if (!_gateOpen) return;
			_gateOpen = false;
			AnimateGateClose();
		}

		private void AnimateGateOpen()
		{
			_gateLeftTween?.Kill();
			_gateRightTween?.Kill();

			if (_gateLeft != null)
				_gateLeftTween = _gateLeft.DOLocalMoveX(-_rotateAngle * 0.01f, _animationDuration).SetEase(Ease.OutBack);
			if (_gateRight != null)
				_gateRightTween = _gateRight.DOLocalMoveX(_rotateAngle * 0.01f, _animationDuration).SetEase(Ease.OutBack);
		}

		private void AnimateGateClose(bool force = false)
		{
			_gateLeftTween?.Kill();
			_gateRightTween?.Kill();

			float duration = force ? 0f : _animationDuration;
			if (_gateLeft != null)
				_gateLeftTween = _gateLeft.DOLocalMoveX(0f, duration).SetEase(Ease.InBack);
			if (_gateRight != null)
				_gateRightTween = _gateRight.DOLocalMoveX(0f, duration).SetEase(Ease.InBack);
		}

		/// <summary>
		/// Map ArrowDirection to a world-space rotation on the Z axis (2D game on XY plane).
		/// Arrow prefab's "default" facing direction is Right (0°).
		/// </summary>
		private static Quaternion DirectionToRotation(ArrowDirection direction)
		{
			switch (direction)
			{
				case ArrowDirection.Right: return Quaternion.Euler(0f, 0f, 0f);
				case ArrowDirection.Up:    return Quaternion.Euler(0f, 0f, 90f);
				case ArrowDirection.Left:  return Quaternion.Euler(0f, 0f, 180f);
				case ArrowDirection.Down:  return Quaternion.Euler(0f, 0f, 270f);
				default:                   return Quaternion.identity;
			}
		}
	}
}
