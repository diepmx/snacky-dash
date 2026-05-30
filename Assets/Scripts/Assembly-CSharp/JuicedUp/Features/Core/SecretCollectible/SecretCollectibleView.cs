using MoreMountains.Feedbacks;
using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	public class SecretCollectibleView : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Transform _visualParent;

		[Header("Feedbacks")]
		[SerializeField]
		private MMF_Player _glowFeedback;

		[SerializeField]
		private MMF_Player _poofFeedback;

		public void PlayGlowFeedback()
		{
		}

		public void StopGlowFeedback()
		{
		}

		public void PlayPoofFeedback()
		{
		}

		public void ShowVisual()
		{
		}

		public void HideVisual()
		{
		}
	}
}
