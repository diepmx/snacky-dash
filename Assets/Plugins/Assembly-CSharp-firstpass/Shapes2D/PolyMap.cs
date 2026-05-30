using UnityEngine;

namespace Shapes2D
{
	internal class PolyMap
	{
		private struct DistanceResult
		{
			public int index;

			public int index2;
		}

		private static float DistanceToLineSegment(Vector2 pos, Vector2 p1, Vector2 p2)
		{
			return 0f;
		}

		private static DistanceResult GetClosestLineSegments(Vector2 pos, Vector2[] vertices)
		{
			return default(DistanceResult);
		}

		private static bool PointIsInsidePoly(Vector2 pos, Vector2[] vertices)
		{
			return false;
		}

		private static bool IntersectsVerticalLineSegment(Vector2 v1, Vector2 v2, Vector2 p1, Vector2 p2)
		{
			return false;
		}

		private static bool IntersectsHorizontalLineSegment(Vector2 v1, Vector2 v2, Vector2 p1, Vector2 p2)
		{
			return false;
		}

		private static int RectIntersectsPolyEdge(Vector2 tl, Vector2 tr, Vector2 bl, Vector2 br, Vector2[] vertices, bool[] results)
		{
			return 0;
		}

		private static int RectContainsVertex(Vector2 tl, Vector2 tr, Vector2 bl, Vector2 br, Vector2[] vertices, bool[] results)
		{
			return 0;
		}

		private static bool PointLineTest(Vector2 pos, Vector2 p1, Vector2 p2)
		{
			return false;
		}

		private static float GetAngleBetween(Vector2 v1, Vector2 v2)
		{
			return 0f;
		}

		public static void GeneratePolyMap(Vector2[] vertices, Texture2D polyMap)
		{
		}
	}
}
