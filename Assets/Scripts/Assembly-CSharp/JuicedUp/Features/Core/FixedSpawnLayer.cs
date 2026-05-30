using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class FixedSpawnLayer
	{
		public int BatchIndex { get; }

		public IReadOnlyList<(Vector3Int cell, int tileId)> Entries { get; }

		public FixedSpawnLayer(int batchIndex, IReadOnlyList<(Vector3Int cell, int tileId)> entries)
		{
		}
	}
}
