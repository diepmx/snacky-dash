using UnityEngine;

namespace JuicedUp.Features.Core.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class FeedbackInstantCanvasGroup : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float destination;

		[SerializeField]
		private bool initializeOnEnable;

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		public void SetValue()
		{
		}
	}
}
