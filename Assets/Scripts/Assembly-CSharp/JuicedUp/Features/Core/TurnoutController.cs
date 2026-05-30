using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(TurnoutView))]
	public class TurnoutController : MonoBehaviour
	{
		[SerializeField]
		private TileType _tileTypeA;

		[SerializeField]
		private TileType _tileTypeB;

		[SerializeField]
		private TurnoutState _currentTurnoutState;

		[SerializeField]
		private TurnoutView _view;

		private TurnoutState _currentState;

		private Vector3Int _positionTile;

		private bool _awaitingToggleWhenClear;

		private SnakeOccupancyManager _waitOccupancy;

		private Vector3Int _waitGroundCell;

		public TurnoutState CurrentTurnoutState => default(TurnoutState);

		private void OnDisable()
		{
		}

		public void Init(Vector3Int positionTile, TurnoutState initialState)
		{
		}

		public void RequestToggle(SnakeOccupancyManager occupancy, Vector3Int groundCell)
		{
		}

		private void OnSnakePoseUpdatedForPendingToggle(IReadOnlyList<PositionStateRotation> psr, Player player)
		{
		}

		private void StopListeningForSnakeMovement()
		{
		}

		public void Toggle()
		{
		}

		private void SetInitialState(TurnoutState startState)
		{
		}

		private TileType GetTileTypeForPosition(TurnoutState state)
		{
			return default(TileType);
		}

		private void UpdateTileType(TileType newType)
		{
		}
	}
}
