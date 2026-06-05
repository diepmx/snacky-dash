using DG.Tweening;
using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Visual layer for the destructible Wall (Blocker) obstacle.
	/// Displays remaining health, shakes on damage, explodes on destruction.
	/// </summary>
	public class WallView : MonoBehaviour
	{
		[Header("Visual Feedback")]
		[SerializeField] private TextMeshPro _healthText;
		[SerializeField] private float _shakeDuration = 0.3f;
		[SerializeField] private float _shakeStrength = 0.25f;

		[Header("Particles")]
		[SerializeField] private GameObject _particleExplosion;
		[SerializeField] private GameObject _particleDamage;

		/// <summary>Initialize the wall display with starting HP.</summary>
		public void Init(int initialHealth)
		{
			UpdateHealthText(initialHealth);

			if (_particleExplosion != null)
				_particleExplosion.SetActive(false);
			if (_particleDamage != null)
				_particleDamage.SetActive(false);
		}

		/// <summary>Show damage feedback and update remaining HP display.</summary>
		public void HandleDamaged(int remainingHealth)
		{
			UpdateHealthText(remainingHealth);
			PlayDamageFeedback();
		}

		/// <summary>Play destruction animation and disable the wall.</summary>
		public void HandleDestroyed()
		{
			UpdateHealthText(0);
			PlayExplosionFeedback();

			// Hide the main wall mesh; explosion particle takes over
			gameObject.SetActive(false);
		}

		private void PlayDamageFeedback()
		{
			// Shake position
			transform.DOShakePosition(_shakeDuration, strength: _shakeStrength, vibrato: 10, randomness: 45f)
				.SetEase(Ease.OutQuad);

			// Play damage particle burst
			if (_particleDamage != null)
			{
				_particleDamage.SetActive(true);
				ParticleSystem ps = _particleDamage.GetComponent<ParticleSystem>();
				if (ps != null)
				{
					ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
					ps.Play();
				}
			}
		}

		private void PlayExplosionFeedback()
		{
			if (_particleExplosion != null)
			{
				_particleExplosion.SetActive(true);
				ParticleSystem ps = _particleExplosion.GetComponent<ParticleSystem>();
				if (ps != null)
				{
					ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
					ps.Play();
				}
			}
		}

		private void UpdateHealthText(int health)
		{
			if (_healthText != null)
				_healthText.text = health > 0 ? health.ToString() : string.Empty;
		}
	}
}
