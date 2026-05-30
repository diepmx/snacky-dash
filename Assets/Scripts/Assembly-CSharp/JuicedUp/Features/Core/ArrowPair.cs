using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class ArrowPair
	{
		private readonly IPairedArrow _firstArrow;

		private readonly IPairedArrow _secondArrow;

		private IPairedArrow _firstEntered;

		private IPairedArrow _pendingExit;

		public bool HasPendingTraversal => false;

		public ArrowPair(IPairedArrow firstArrow, IPairedArrow secondArrow)
		{
		}

		public void NotifyArrowEntered(IPairedArrow crossedArrow)
		{
		}

		public void NotifyHeadInCell(Vector3Int cell)
		{
		}

		public void Reset()
		{
		}
	}
}
