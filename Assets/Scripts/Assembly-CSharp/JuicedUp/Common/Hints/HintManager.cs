using Deus;
using UnityEngine;
using UnityEngine.Pool;

namespace JuicedUp.Common.Hints
{
	public class HintManager : Singleton<HintManager>
	{
		public enum Direction
		{
			Up = 0,
			Down = 1
		}

		[SerializeField]
		private HintView hintPrefab;

		[SerializeField]
		private Transform mainPosition;

		private ObjectPool<HintView> _pool;

		protected override void Awake()
		{
		}

		public void Show(string text, Transform source, Direction direction)
		{
		}

		public void Show(string text)
		{
		}

		private HintView Create()
		{
			return null;
		}

		private void OnGet(HintView hint)
		{
		}

		private void OnRelease(HintView hint)
		{
		}

		private void OnDestroyHint(HintView hint)
		{
		}
	}
}
