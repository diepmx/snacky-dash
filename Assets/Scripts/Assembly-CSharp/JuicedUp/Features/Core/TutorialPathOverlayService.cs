using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	public sealed class TutorialPathOverlayService : IDisposable
	{
		private const string RootName = "TutorialPathOverlayRoot";

		private const string HoleName = "PathHole";

		private static readonly Vector2 PerCellPadding;

		private const float MinHoleExtent = 2.25f;

		private static readonly Vector2 PathHoleLocalOffset;

		private readonly DarkOverlayController _overlayController;

		private readonly List<Transform> _spawnedHoles;

		private Transform _root;

		public TutorialPathOverlayService(DarkOverlayController overlayController)
		{
		}

		public void ShowPath(IReadOnlyList<Vector3Int> orderedCells, Tilemap tilemap)
		{
		}

		public void Clear()
		{
		}

		public void Dispose()
		{
		}

		private void EnsureRoot()
		{
		}

		private void SpawnSegmentHole(IReadOnlyList<Vector3Int> orderedCells, int startIndex, int endIndex, Tilemap tilemap)
		{
		}

		private static void ComputeSegmentBounds(IReadOnlyList<Vector3Int> orderedCells, int startIndex, int endIndex, Tilemap tilemap, out Vector3 center, out Vector2 size)
		{
			center = default(Vector3);
			size = default(Vector2);
		}

		private static Vector3Int StepDirection(Vector3Int from, Vector3Int to)
		{
			return default(Vector3Int);
		}
	}
}
