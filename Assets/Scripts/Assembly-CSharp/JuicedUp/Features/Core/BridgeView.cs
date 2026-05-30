using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class BridgeView : MonoBehaviour
	{
		[SerializeField]
		private Transform _bridgeAxeToRotate;

		[SerializeField]
		private GameObject _flatBridge;

		[SerializeField]
		private float _tweenDuration;

		[SerializeField]
		private float _pollInterval;

		public float PollInterval => 0f;

		public void SnapState(bool open)
		{
		}

		public void AnimateState(SwitchToggleState state, bool withSound)
		{
		}
	}
}
