using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core.Layout
{
	public class JuicedUpLevelBoundsProvider : IBoundsProvider
	{
		public bool GetBounds(out Bounds bounds)
		{
			bounds = default(Bounds);
			return false;
		}

		public bool GetBoundsWithOffset(out Bounds bounds, Vector2 offset)
		{
			bounds = default(Bounds);
			return false;
		}

		private static Bounds ExpandOneSide(Bounds bounds, Vector3 direction, float amount)
		{
			return default(Bounds);
		}

		private static bool HasSideTruckOutsideBounds(Bounds levelBounds)
		{
			return false;
		}

		private static bool HasSideTruckOutsideBoundsFromPrefab(LevelDataSO levelData, Bounds levelBounds)
		{
			return false;
		}

		private static bool HasSideTruckOutsideBoundsFromJson(LevelDataSO levelData, TileDefinitionDatabase tileDb, Bounds levelBounds)
		{
			return false;
		}

		private static List<(float, float, float)> BuildCrateLanePositions(LevelDataSO levelData, TileDefinitionDatabase tileDb)
		{
			return null;
		}

		private static bool IsSideFacingOutsideBounds(float zRotation, float laneX, Bounds levelBounds)
		{
			return false;
		}

		private static bool HasTopTruckOutsideBounds(Bounds levelBounds)
		{
			return false;
		}

		private static bool HasTopTruckOutsideBoundsFromPrefab(LevelDataSO levelData, Bounds levelBounds)
		{
			return false;
		}

		private static bool HasTopTruckOutsideBoundsFromJson(LevelDataSO levelData, TileDefinitionDatabase tileDb, Bounds levelBounds)
		{
			return false;
		}

		private static bool IsTopFacingOutsideBounds(float zRotation, float laneY, Bounds levelBounds)
		{
			return false;
		}
	}
}
