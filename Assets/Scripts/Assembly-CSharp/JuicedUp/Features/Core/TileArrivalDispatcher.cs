using System;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TileArrivalDispatcher : MonoBehaviour
	{
		public static readonly DirectionPlayer[] AllDirections;

		private Vector3Int _previousTileCell;

		private MovementGatekeeper _movementGatekeeper;

		public Func<DirectionPlayer> GetCurrentDirection;

		public Action<DirectionPlayer> OnContinueMovement;

		public Action<State> OnStateChanged;

		public Action<Vector3Int, TileType> OnTileEntered;

		public Vector3Int LastTileCell { get; private set; }

		public void Init(MovementGatekeeper movementGatekeeper)
		{
		}

		public void SetStartCell(Vector3Int startCell)
		{
		}

		public void Tick(Vector3Int cell)
		{
		}

		public bool Tick(Vector3 position)
		{
			return false;
		}

		public void OnArrived(Vector3Int cell, ref TileType nextTargetTile, TailManager tailManager, ref bool firstSwipe)
		{
		}

		public bool TryContinueAfterArrival(Vector3 target, TileType nextTargetTile)
		{
			return false;
		}

		private DirectionPlayer TryGetSingleAvailableDirection()
		{
			return default(DirectionPlayer);
		}
	}
}
