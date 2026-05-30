using UnityEngine;

namespace JuicedUp.Features.Core
{
	public abstract class CrateFeedbackView : MonoBehaviour
	{
		public abstract void OnBeginTransitionToActive();

		public abstract void OnArrivedAtActive();

		public abstract void OnBeginTransitionToExit();

		public abstract void OnFruitCollected();

		public abstract void OnCloseLid(int lidIndex);
	}
}
