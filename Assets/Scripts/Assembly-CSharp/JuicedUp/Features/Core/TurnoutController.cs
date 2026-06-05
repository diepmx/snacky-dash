using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Logic controller for a Turnout (aiguillage / switch junction) tile.
	/// Toggles between two tile types (path configurations A and B) when the snake passes through.
	/// Defers the toggle until the snake body is clear of the cell.
	/// </summary>
	[RequireComponent(typeof(TurnoutView))]
	public class TurnoutController : MonoBehaviour
	{
		[SerializeField] private TileType _tileTypeA;
		[SerializeField] private TileType _tileTypeB;
		[SerializeField] private TurnoutState _currentTurnoutState;
		[SerializeField] private TurnoutView _view;

		private TurnoutState _currentState;
		private Vector3Int _positionTile;
		private bool _awaitingToggleWhenClear;
		private SnakeOccupancyManager _waitOccupancy;
		private Vector3Int _waitGroundCell;

		public TurnoutState CurrentTurnoutState => _currentState;

		// ─── Lifecycle ───────────────────────────────────────────────────────────

		private void OnDisable()
		{
			if (_waitOccupancy != null)
				_waitOccupancy.OccupancyChanged -= OnSnakePoseUpdatedForPendingToggle_Adapter;

			_awaitingToggleWhenClear = false;
		}

		// ─── Public API ──────────────────────────────────────────────────────────

		/// <summary>Initialize this turnout's cell position and starting state.</summary>
		public void Init(Vector3Int positionTile, TurnoutState initialState)
		{
			_positionTile = positionTile;
			SetInitialState(initialState);
		}

		/// <summary>
		/// Request a toggle. If the snake is currently on this cell, defer until it moves away.
		/// </summary>
		public void RequestToggle(SnakeOccupancyManager occupancy, Vector3Int groundCell)
		{
			if (occupancy != null && occupancy.IsAnySnakeOnCell(groundCell))
			{
				// Defer: wait for snake to leave
				_awaitingToggleWhenClear = true;
				_waitOccupancy  = occupancy;
				_waitGroundCell = groundCell;

				occupancy.OccupancyChanged += OnSnakePoseUpdatedForPendingToggle_Adapter;
			}
			else
			{
				Toggle();
			}
		}

		/// <summary>Immediately toggle between state PositionA and PositionB.</summary>
		public void Toggle()
		{
			_currentState = _currentState == TurnoutState.PositionA
				? TurnoutState.PositionB
				: TurnoutState.PositionA;
			UpdateTileType(GetTileTypeForPosition(_currentState));

			if (_view != null)
				_view.ShowPosition(_currentState);
		}

		// ─── Private helpers ──────────────────────────────────────────────────

		// Adapter because the real event passes IReadOnlyList<PositionStateRotation> + Player,
		// but we subscribe to the simpler OccupancyChanged Action.
		private void OnSnakePoseUpdatedForPendingToggle_Adapter()
		{
			if (!_awaitingToggleWhenClear) return;
			if (_waitOccupancy == null) return;

			if (!_waitOccupancy.IsAnySnakeOnCell(_waitGroundCell))
			{
				StopListeningForSnakeMovement();
				Toggle();
			}
		}

		private void OnSnakePoseUpdatedForPendingToggle(
			IReadOnlyList<PositionStateRotation> psr, Player player)
		{
			OnSnakePoseUpdatedForPendingToggle_Adapter();
		}

		private void StopListeningForSnakeMovement()
		{
			if (_waitOccupancy != null)
				_waitOccupancy.OccupancyChanged -= OnSnakePoseUpdatedForPendingToggle_Adapter;

			_awaitingToggleWhenClear = false;
			_waitOccupancy = null;
		}

		private void SetInitialState(TurnoutState startState)
		{
			_currentState = startState;
			// No tile update needed at init (tile already set correctly in tilemap)
			if (_view != null)
				_view.Init(startState);
		}

		private TileType GetTileTypeForPosition(TurnoutState state)
		{
			return state == TurnoutState.PositionA ? _tileTypeA : _tileTypeB;
		}

		private void UpdateTileType(TileType newType)
		{
			LevelController lc = LevelController.Instance;
			if (lc != null)
				lc.SetTileType(_positionTile, newType);
		}
	}
}
