using MoreMountains.Feedbacks;
using UnityEngine;

namespace KiraganGames.Lives
{
	public class BlinkingHeart : MonoBehaviour
	{
		[SerializeField]
		private MMF_Player blinkFeedback;

		[SerializeField]
		private MMF_Player breakFeedback;

		[SerializeField]
		private MMF_Player newFeedback;

		[SerializeField]
		private GameObject heart;

		[SerializeField]
		private Transform heartTransform;

		[SerializeField]
		private CanvasGroup heartCanvasGroup;

		private bool isBlinking;

		private Coroutine blinkCoroutine;

		public bool IsBlinking => false;

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void StartBlink()
		{
		}

		public void StopBlink()
		{
		}

		public void Break()
		{
		}

		public void PlayNew()
		{
		}
	}
}
