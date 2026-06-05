using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class ArrowSwitchController : MonoBehaviour, IPairedArrow
	{
		[SerializeField] private ArrowView _view;

		[FormerlySerializedAs("arrowDirection")]
		[Header("Config — assign in prefab Inspector")]
		public ArrowDirection _arrowDirection;

		[FormerlySerializedAs("isFixedArrow")]
		public bool IsFixedArrow;

		[FormerlySerializedAs("switchID")]
		public int SwitchID;

		public bool IsUnique;

		[FormerlySerializedAs("positionArrow")]
		[Header("Runtime — set by Init()")]
		public Vector3Int PositionArrow;

		// Gate is open when snake can pass through
		private bool _isGateOpen;

		Vector3Int IPairedArrow.PositionArrow => PositionArrow;

		private void OnDisable()
		{
			// Unsubscribe from tile arrival events
			Player.OnHeadEnterTile -= HandleTipLiveCell;
		}

		private void OnReviveOver()
		{
			// On revive, close the gate again
			CloseGate();
		}

		/// <summary>Register this arrow's cell position and initialize visuals.</summary>
		public void Init(Vector3Int cellPos)
		{
			PositionArrow = cellPos;
			_isGateOpen = false;

			if (_view != null)
				_view.Init(_arrowDirection);

			// Subscribe to head tile arrival to detect revive
			Player.OnHeadEnterTile += HandleTipLiveCell;
		}

		/// <summary>Flip the arrow direction (for Switching Arrow obstacle).</summary>
		public void InverseDirection()
		{
			_arrowDirection = _arrowDirection switch
			{
				ArrowDirection.Up    => ArrowDirection.Down,
				ArrowDirection.Down  => ArrowDirection.Up,
				ArrowDirection.Left  => ArrowDirection.Right,
				ArrowDirection.Right => ArrowDirection.Left,
				_                    => _arrowDirection
			};

			if (_view != null)
				_view.HandleDirectionChanged(_arrowDirection);
		}

		/// <summary>Play "not allowed" shake animation.</summary>
		public void PlayNotAllowedAnimation()
		{
			if (_view != null)
				_view.HandleNotAllowedAnimation();
		}

		/// <summary>Open the gate to allow snake passage.</summary>
		public void OpenGate()
		{
			if (_isGateOpen) return;
			_isGateOpen = true;
			if (_view != null)
				_view.HandleGateOpen();
		}

		private void CloseGate()
		{
			if (!_isGateOpen) return;
			_isGateOpen = false;
			if (_view != null)
				_view.HandleGateClose();
		}

		/// <summary>Returns true if the given player direction matches this arrow's direction.</summary>
		public bool IsDirectionPlayerSameAsArrow(DirectionPlayer direction)
		{
			switch (_arrowDirection)
			{
				case ArrowDirection.Up:    return direction == DirectionPlayer.Up;
				case ArrowDirection.Down:  return direction == DirectionPlayer.Down;
				case ArrowDirection.Left:  return direction == DirectionPlayer.Left;
				case ArrowDirection.Right: return direction == DirectionPlayer.Right;
				default: return false;
			}
		}

		private void HandleTipLiveCell(Vector3Int cell, TileType type)
		{
			// When snake head leaves this arrow's cell, close the gate
			if (cell != PositionArrow && _isGateOpen)
			{
				CloseGate();
			}
		}
	}
}
