using MoreMountains.Feedbacks;
using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	/// <summary>
	/// Visual layer for the Secret Collectible (Mystery Fruit).
	/// Controls the glow idle animation and poof destruction effect.
	/// </summary>
	public class SecretCollectibleView : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Transform _visualParent;

		[Header("Feedbacks")]
		[SerializeField] private MMF_Player _glowFeedback;
		[SerializeField] private MMF_Player _poofFeedback;

		/// <summary>Start the idle glow loop animation.</summary>
		public void PlayGlowFeedback()
		{
			_glowFeedback?.PlayFeedbacks();
		}

		/// <summary>Stop the idle glow loop animation.</summary>
		public void StopGlowFeedback()
		{
			_glowFeedback?.StopFeedbacks();
		}

		/// <summary>Play the "collected" poof/sparkle effect.</summary>
		public void PlayPoofFeedback()
		{
			_poofFeedback?.PlayFeedbacks();
		}

		/// <summary>Make the collectible visible (show the 3D/2D visual).</summary>
		public void ShowVisual()
		{
			if (_visualParent != null)
				_visualParent.gameObject.SetActive(true);
		}

		/// <summary>Hide the collectible visual.</summary>
		public void HideVisual()
		{
			if (_visualParent != null)
				_visualParent.gameObject.SetActive(false);
		}
	}
}
