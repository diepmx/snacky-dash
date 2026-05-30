using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace JuicedUp.Features.Core
{
	public sealed class GuidanceArrowPool : IDisposable
	{
		private readonly GuidanceArrowView _prefab;

		private readonly Transform _parent;

		private readonly ObjectPool<GuidanceArrowView> _pool;

		private readonly List<GuidanceArrowView> _active;

		public GuidanceArrowPool(GuidanceArrowView prefab, Transform parent, int prewarmCount = 5)
		{
		}

		public GuidanceArrowView Get()
		{
			return null;
		}

		public void Return(GuidanceArrowView view)
		{
		}

		public void ReturnAll()
		{
		}

		public void Dispose()
		{
		}

		private GuidanceArrowView Create()
		{
			return null;
		}

		private void OnGet(GuidanceArrowView view)
		{
		}

		private void OnRelease(GuidanceArrowView view)
		{
		}

		private void OnDestroyView(GuidanceArrowView view)
		{
		}

		private void Prewarm(int count)
		{
		}
	}
}
