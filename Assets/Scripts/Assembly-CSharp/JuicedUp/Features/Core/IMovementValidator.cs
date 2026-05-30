using UnityEngine;

namespace JuicedUp.Features.Core
{
	public interface IMovementValidator
	{
		bool CanPass(Vector3Int cell, DirectionPlayer direction);

		void OnHeadArrived(Vector3Int cell, DirectionPlayer direction)
		{
		}
	}
}
