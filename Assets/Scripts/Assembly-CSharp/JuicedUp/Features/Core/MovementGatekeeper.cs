using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class MovementGatekeeper : MonoBehaviour
	{
		private readonly List<IMovementValidator> _validators;

		private Transform _raycastOrigin;

		private LayerMask _enemyLayer;

		public void Init(Transform raycastOrigin, LayerMask enemyLayer)
		{
		}

		public void RegisterValidator(IMovementValidator validator)
		{
		}

		public void UnregisterValidator(IMovementValidator validator)
		{
		}

		public bool CanMove(DirectionPlayer direction, Action onBump, Action onRescale, Action<DirectionPlayer> onBumpArrow)
		{
			return false;
		}

		public bool CanPassValidators(Vector3Int cell, DirectionPlayer direction)
		{
			return false;
		}

		public static bool IsOppositeDirection(DirectionPlayer a, DirectionPlayer b)
		{
			return false;
		}

		public void NotifyHeadArrived(Vector3Int cell, DirectionPlayer direction)
		{
		}
	}
}
