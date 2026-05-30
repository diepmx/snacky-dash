using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class WallView : MonoBehaviour
	{
		[Header("Visual Feedback")]
		[SerializeField]
		private TextMeshPro _healthText;

		[SerializeField]
		private float _shakeDuration;

		[SerializeField]
		private float _shakeStrength;

		[Header("Particles")]
		[SerializeField]
		private GameObject _particleExplosion;

		[SerializeField]
		private GameObject _particleDamage;

		public void Init(int initialHealth)
		{
		}

		public void HandleDamaged(int remainingHealth)
		{
		}

		public void HandleDestroyed()
		{
		}

		private void PlayDamageFeedback()
		{
		}

		private void PlayExplosionFeedback()
		{
		}

		private void UpdateHealthText(int health)
		{
		}
	}
}
