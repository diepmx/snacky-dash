using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public static class DestructibleWallGroupBuilder
	{
		public static List<DestructibleWallGroup> Build(ICollection<Vector2Int> pathCellKeys)
		{
			return null;
		}

		private static void TryPushNeighbor(int x, int y, HashSet<Vector2Int> pathSet, Dictionary<Vector2Int, int> groupByCell, int groupId, Stack<Vector2Int> pending)
		{
		}
	}
}
