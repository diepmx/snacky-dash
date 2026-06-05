using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class BridgeView : MonoBehaviour
	{
		[SerializeField] private Transform _bridgeAxeToRotate;
		[SerializeField] private GameObject _flatBridge;
		[SerializeField] private float _tweenDuration = 0.35f;
		[SerializeField] private float _pollInterval = 0.1f;

		private Tweener _currentTween;

		public float PollInterval => _pollInterval;

		/// <summary>Immediately snap bridge to open or closed state without animation.</summary>
		public void SnapState(bool open)
		{
			_currentTween?.Kill();

			if (_bridgeAxeToRotate != null)
			{
				// Open = 0° (flat/road), Closed = -90° (raised/blocking)
				float targetAngle = open ? 0f : -90f;
				_bridgeAxeToRotate.localRotation = Quaternion.Euler(targetAngle, 0f, 0f);
			}

			if (_flatBridge != null)
			{
				_flatBridge.SetActive(open);
			}
		}

		/// <summary>Animate bridge transition to the given toggle state.</summary>
		public void AnimateState(SwitchToggleState state, bool withSound)
		{
			_currentTween?.Kill();

			bool open = state == SwitchToggleState.On;
			float targetAngle = open ? 0f : -90f;

			if (_bridgeAxeToRotate != null)
			{
				_currentTween = _bridgeAxeToRotate
					.DOLocalRotate(new Vector3(targetAngle, 0f, 0f), _tweenDuration)
					.SetEase(Ease.InOutSine)
					.OnComplete(() =>
					{
						if (_flatBridge != null)
							_flatBridge.SetActive(open);
					});
			}
			else if (_flatBridge != null)
			{
				_flatBridge.SetActive(open);
			}
		}
	}
}
