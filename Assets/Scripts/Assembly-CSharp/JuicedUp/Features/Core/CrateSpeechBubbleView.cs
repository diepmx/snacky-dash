using UnityEngine;

namespace JuicedUp.Features.Core
{
	public abstract class CrateSpeechBubbleView : MonoBehaviour
	{
		public abstract void Initialize(int capacity);

		public abstract void PlayAppear();

		public abstract void PlayDisappear();

		public abstract void UpdateCount(int remaining);
	}
}
