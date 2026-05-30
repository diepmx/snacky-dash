using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class SnakeOccupancyManager : MonoBehaviour, IAsyncInitializable
	{
		[SerializeField]
		private TailManager _tailManager;

		[SerializeField]
		private TailCuttingController _cuttingController;

		private readonly Dictionary<Vector3Int, int> _tailCellCountDict;

		private readonly Dictionary<Vector3Int, SnakeOccupant> _occupancyDict;

		private bool _hasHeadCellCached;

		private Vector3Int _headCellCached;

		public bool IsProtected => false;

		public bool IsCuttingTail => false;

		public static event Action OnSnakeOccupancyChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OccupancyChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void NotifyOccupancyChanged()
		{
		}

		public void IncTailCell(Vector3Int cell)
		{
		}

		public void DecTailCell(Vector3Int cell)
		{
		}

		public void RegisterSegmentCell(TailSegment segment)
		{
		}

		public void UnregisterSegmentCell(TailSegment segment)
		{
		}

		private Vector3Int GetSegmentCell(TailSegment segment)
		{
			return default(Vector3Int);
		}

		public void UpdateHeadCellCache(bool hasHeadPositionStateRotation, Vector3 headPosition)
		{
		}

		public void RebuildOccupancy()
		{
		}

		public void RebuildOccupancy(bool hasHeadPositionStateRotation, Vector3 headPosition, List<TailSegment> segments)
		{
		}

		public void RebuildTailCellCount(List<TailSegment> segments)
		{
		}

		public void RefreshSnakeCachesHard(bool notify = true)
		{
		}

		public bool IsHeadOnCellCached(Vector3Int cell)
		{
			return false;
		}

		public bool IsTailOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool IsAnySnakeOnCellCached(Vector3Int cell)
		{
			return false;
		}

		public bool IsAnySnakeOnCell(Vector3Int cell, bool preferCache)
		{
			return false;
		}

		public bool IsHeadOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool IsAnyTailOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool IsAnySnakeOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool HasAnyAboveOnCell(Vector3Int cell)
		{
			return false;
		}

		public bool AreAllCellsEmptyWithOffsets(Vector3Int origin, bool includeOrigin = true, bool preferCache = true, params Vector3Int[] offsets)
		{
			return false;
		}

		private bool IsAnySnakeOnCellsWithOffsets(Vector3Int origin, bool includeOrigin, bool preferCache, params Vector3Int[] offsets)
		{
			return false;
		}

		public int GetTailCountOnTile(Vector3Int cell)
		{
			return 0;
		}

		public SnakeOccupant GetOccupant(Vector3Int cell)
		{
			return default(SnakeOccupant);
		}

		public CellOccupancyInfo GetOccupancyInfo(Vector3Int cell)
		{
			return default(CellOccupancyInfo);
		}

		public IReadOnlyCollection<Vector3Int> GetTailOccupiedCells()
		{
			return null;
		}

		public bool TryGetSegmentNeighborsOnCell(Vector3Int cell, out SegmentNeighbors neighbors, bool ignoreInactive = true)
		{
			neighbors = default(SegmentNeighbors);
			return false;
		}

		public SegmentShape GetSegmentShape(in SegmentNeighbors neighbors)
		{
			return default(SegmentShape);
		}

		private bool TryFindPrevDifferentCell(int fromIndex, out int previousIndex, out Vector3Int previousCell, bool ignoreInactive)
		{
			previousIndex = default(int);
			previousCell = default(Vector3Int);
			return false;
		}

		private bool TryFindNextDifferentCell(int fromIndex, out int nextIndex, out Vector3Int nextCell, bool ignoreInactive)
		{
			nextIndex = default(int);
			nextCell = default(Vector3Int);
			return false;
		}

		private static Vector3Int NormDir(Vector3Int direction)
		{
			return default(Vector3Int);
		}

		private static bool IsAbove(State state)
		{
			return false;
		}

		public Vector3Int WorldToCell(Vector3 world)
		{
			return default(Vector3Int);
		}

		public bool IsSegmentUnderpassOnBridge(int segmentIndex)
		{
			return false;
		}

		private bool TryGetSegmentNeighborsForIndex(int segmentIndex, Vector3Int segmentCell, out SegmentNeighbors neighbors)
		{
			neighbors = default(SegmentNeighbors);
			return false;
		}

		public TileType GetBridgeTileTypeAt(Vector3Int cell)
		{
			return default(TileType);
		}
	}
}
