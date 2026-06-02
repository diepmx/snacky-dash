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
				if (layer?.Entries == null)
				{
					continue;
				}
				foreach (var entry in layer.Entries)
				{
					Vector3Int item = entry.cell;
					_fixedCells.Add(new Vector2Int(item.x, item.y));
				}
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
				foreach (FixedSpawnLayer layer2 in _layers)
				{
					if (layer2 != null && layer2.BatchIndex == batchIndex)
					{
						layer = layer2;
						return true;
					}
				}
			}
			layer = null;
			return false;
		}
	}
}
