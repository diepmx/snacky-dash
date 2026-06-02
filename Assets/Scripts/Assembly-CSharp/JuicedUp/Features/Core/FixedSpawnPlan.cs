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
			_layers = layers ?? new List<FixedSpawnLayer>();
			_fixedCells = new HashSet<Vector2Int>();
			foreach (FixedSpawnLayer layer in _layers)
			{
				if (layer?.Entries == null) continue;
				foreach ((Vector3Int cell, int _) in layer.Entries)
					_fixedCells.Add(new Vector2Int(cell.x, cell.y));
			}
		}

		public bool IsFixedCell(Vector2Int xy)
		{
			return _fixedCells.Contains(xy);
		}

		public bool TryGetLayer(int batchIndex, out FixedSpawnLayer layer)
		{
			if (_layers != null)
			{
				foreach (FixedSpawnLayer l in _layers)
				{
					if (l != null && l.BatchIndex == batchIndex)
					{
						layer = l;
						return true;
					}
				}
			}
			layer = null;
			return false;
		}
	}
}
