using UnityEngine;

namespace JuicedUp.Features.Core.UI
{
	public class FeedbackInstantScale : MonoBehaviour
	{
		[SerializeField]
		private Transform translation;

		[SerializeField]
		private Vector3 destination;

		[SerializeField]
		private bool initializeOnEnable;

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		public void SetScale()
		{
		}
	}
}
