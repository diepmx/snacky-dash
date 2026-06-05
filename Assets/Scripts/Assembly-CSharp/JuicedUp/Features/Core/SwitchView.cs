using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Visual layer for the Switch (Flipping Bridge lever / CrossRoad toggle).
	/// Shows On or Off mesh, and optionally repositions itself flush against the nearest wall.
	/// </summary>
	public class SwitchView : MonoBehaviour
	{
		[SerializeField] private GameObject _meshOn;
		[SerializeField] private GameObject _meshOff;
		[SerializeField] private bool _canChangePosition;
		[SerializeField] private float _wallOffsetLeft;
		[SerializeField] private float _wallOffsetRight;
		[SerializeField] private float _wallOffsetUp;
		[SerializeField] private float _wallOffsetDown;

		private LevelController _levelController;

		/// <summary>Initialize the switch visual with the starting toggle state.</summary>
		public void Init(SwitchToggleState initialState, LevelController levelController)
		{
			_levelController = levelController;

			// Show correct mesh for initial state
			HandleActivated(initialState);

			// Push the visual into the nearest wall for a clean look
			if (_canChangePosition)
				PushViewIntoNearestWall();
		}

		/// <summary>Swap On/Off mesh when the switch is activated.</summary>
		public void HandleActivated(SwitchToggleState state)
		{
			bool isOn = state == SwitchToggleState.On;
			if (_meshOn != null) _meshOn.SetActive(isOn);
			if (_meshOff != null) _meshOff.SetActive(!isOn);
		}

		/// <summary>Move this switch prefab to be flush against the nearest adjacent wall tile.</summary>
		public void PushViewIntoNearestWall()
		{
			Vector2Int cellXY = new Vector2Int(
				Mathf.RoundToInt(transform.position.x),
				Mathf.RoundToInt(transform.position.y));

			if (!TryFindWallDirection(cellXY, out Vector2Int wallDir)) return;

			Vector3 offset = Vector3.zero;
			if (wallDir == Vector2Int.left)   offset = new Vector3(-_wallOffsetLeft, 0f, 0f);
			if (wallDir == Vector2Int.right)  offset = new Vector3(_wallOffsetRight, 0f, 0f);
			if (wallDir == Vector2Int.up)     offset = new Vector3(0f,  _wallOffsetUp,   0f);
			if (wallDir == Vector2Int.down)   offset = new Vector3(0f, -_wallOffsetDown, 0f);

			transform.localPosition += offset;
		}

		private bool TryFindWallDirection(Vector2Int cell, out Vector2Int wallDir)
		{
			wallDir = default;
			if (_levelController == null) return false;

			// Check four cardinal neighbors for a Wall tile type
			Vector2Int[] candidates =
			{
				Vector2Int.left, Vector2Int.right,
				Vector2Int.up,   Vector2Int.down
			};

			foreach (Vector2Int dir in candidates)
			{
				Vector2Int neighbor = cell + dir;
				TileType type = _levelController.GetTileTypeAt(neighbor);
				if (type == TileType.Wall || type == TileType.Contour)
				{
					wallDir = dir;
					return true;
				}
			}

			return false;
		}
	}
}
