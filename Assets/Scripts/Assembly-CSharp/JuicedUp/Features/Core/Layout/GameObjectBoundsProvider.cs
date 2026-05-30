using UnityEngine;

namespace JuicedUp.Features.Core.Layout
{
	public class GameObjectBoundsProvider : IBoundsProvider
	{
		private readonly Transform _parent;

		public GameObjectBoundsProvider(Transform parent)
		{
		}

		public bool GetBounds(out Bounds bounds)
		{
			bounds = default(Bounds);
			return false;
		}
	}
}
