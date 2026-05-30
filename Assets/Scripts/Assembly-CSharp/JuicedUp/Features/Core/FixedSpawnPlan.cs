using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class FixedSpawnPlan
	{
		private readonly IReadOnlyList<FixedSpawnLayer> _layers;

		private readonly HashSet<Vector2Int> _fixedCells;

		public FixedSpawnPlan(IReadOnlyList<FixedSpawnLayer> layers)
		{
		}

		public bool IsFixedCell(Vector2Int xy)
		{
			return false;
		}

		public bool TryGetLayer(int batchIndex, out FixedSpawnLayer layer)
		{
			layer = null;
			return false;
		}
	}
}
