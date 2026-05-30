using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public static class DirectionScoringUtil
	{
		public static DirectionPlayer ScoreBestDirection(List<DirectionPlayer> allowedDirs, DirectionPlayer comeFrom, Vector3 playerWorldPos, bool avoidBacktracking, Func<Vector3, float> scoreFunction)
		{
			return default(DirectionPlayer);
		}

		public static DirectionPlayer PickDirectionByPriority(List<DirectionPlayer> allowedDirs, DirectionPlayer comeFrom, bool avoidBacktracking)
		{
			return default(DirectionPlayer);
		}

		public static DirectionPlayer Opposite(DirectionPlayer dir)
		{
			return default(DirectionPlayer);
		}

		public static Vector3 CellToCenterWorld(Vector2Int cell)
		{
			return default(Vector3);
		}

		public static Vector2Int DirectionToOffset(DirectionPlayer dir)
		{
			return default(Vector2Int);
		}

		private static DirectionPlayer PickFromPriority(List<DirectionPlayer> allowedDirs, DirectionPlayer comeFrom, bool respectBacktracking, bool avoidBacktracking)
		{
			return default(DirectionPlayer);
		}
	}
}
