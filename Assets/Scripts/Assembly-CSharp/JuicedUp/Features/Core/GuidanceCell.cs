using UnityEngine;

namespace JuicedUp.Features.Core
{
	public struct GuidanceCell
	{
		public readonly Vector3Int Cell;

		public readonly DirectionPlayer Direction;

		public GuidanceCell(Vector3Int cell, DirectionPlayer direction)
		{
			Cell = default(Vector3Int);
			Direction = default(DirectionPlayer);
		}
	}
}
