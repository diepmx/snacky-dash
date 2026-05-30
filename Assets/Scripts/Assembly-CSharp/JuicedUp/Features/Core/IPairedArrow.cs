using UnityEngine;

namespace JuicedUp.Features.Core
{
	public interface IPairedArrow
	{
		Vector3Int PositionArrow { get; }

		void InverseDirection();
	}
}
