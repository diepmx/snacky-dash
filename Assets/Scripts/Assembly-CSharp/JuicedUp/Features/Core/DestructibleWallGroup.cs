using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public readonly struct DestructibleWallGroup
	{
		public readonly int Id;

		public readonly Vector2Int Seed;

		public readonly IReadOnlyList<Vector2Int> Cells;

		public DestructibleWallGroup(int id, Vector2Int seed, IReadOnlyList<Vector2Int> cells)
		{
			Id = 0;
			Seed = default(Vector2Int);
			Cells = null;
		}
	}
}
