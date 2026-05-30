using UnityEngine;

namespace Shapes2D
{
	public class Bird : MonoBehaviour
	{
		private Rigidbody2D rb;

		public float force;

		private bool dead;

		private bool playing;

		private Vector3 startPosition;

		private int score;

		private void Start()
		{
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
		}

		public int GetScore()
		{
			return 0;
		}

		private void OnCollisionEnter2D(Collision2D coll)
		{
		}

		public bool IsDead()
		{
			return false;
		}

		public void Reset()
		{
		}

		public bool IsPlaying()
		{
			return false;
		}

		public void Play()
		{
		}

		private void Die()
		{
		}

		private void Flap()
		{
		}

		private void Update()
		{
		}
	}
}
