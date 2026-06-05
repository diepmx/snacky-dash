using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	/// <summary>
	/// Logic controller for the Secret Collectible (Mystery Fruit) obstacle.
	/// 
	/// Lifecycle:
	///   - Initialize(): show visual + start glow animation
	///   - Explode(): stop glow + play poof + hide visual (snake collected it)
	///   - Cleanup(): stop effects + hide visual (level reset / revive)
	/// </summary>
	public class SecretCollectibleController : MonoBehaviour
	{
		[SerializeField] private SecretCollectibleView _view;

		/// <summary>Called when the mystery fruit spawns — show and start glowing.</summary>
		public void Initialize()
		{
			if (_view == null) return;

			_view.ShowVisual();
			_view.PlayGlowFeedback();
		}

		/// <summary>Called when the snake collects the mystery fruit — animate collection.</summary>
		public void Explode()
		{
			if (_view == null) return;

			_view.StopGlowFeedback();
			_view.PlayPoofFeedback();
			_view.HideVisual();
		}

		/// <summary>Called on revive or level reset — silently hide without collection effects.</summary>
		public void Cleanup()
		{
			if (_view == null) return;

			_view.StopGlowFeedback();
			_view.HideVisual();
		}
	}
}
