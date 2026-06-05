using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Visual-only controller for a tunnel tile pair.
	/// Hides the entrance cap when the snake head enters the tunnel,
	/// hides the exit cap while the snake tail is still inside,
	/// and restores both caps once the snake is fully clear.
	/// </summary>
	[RequireComponent(typeof(TunnelView))]
	public class TunnelController : MonoBehaviour
	{
		[SerializeField] private TunnelView _view;
		[SerializeField] private TailManager _tailManager;
		[SerializeField] private Transform _entranceTransform;
		[SerializeField] private Transform _exitTransform;

		private bool _entranceHidden;
		private bool _exitHidden;
		private bool _isReady;

		public GameObject TunnelEntrance => _view != null ? _view.TunnelEntrance : null;
		public GameObject TunnelExit => _view != null ? _view.TunnelExit : null;

		private void OnDisable()
		{
			TailManager.OnUpdatedTail -= OnTailUpdated;
			Player.OnArrivedAtDestination -= OnSnakeMovementEnded;
		}

		/// <summary>Initialize and begin monitoring tail positions for entrance/exit visibility.</summary>
		public void Init(TailManager tailManager)
		{
			_tailManager = tailManager;
			_isReady = false;
			WaitAndStartMonitoringAsync().Forget();
		}

		private async UniTaskVoid WaitAndStartMonitoringAsync()
		{
			// Wait one frame so all level objects are fully initialized
			await UniTask.Yield();

			TailManager.OnUpdatedTail += OnTailUpdated;
			Player.OnArrivedAtDestination += OnSnakeMovementEnded;
			_isReady = true;

			EvaluateTunnelVisibility();
		}

		private void OnTailUpdated(int tailLength)
		{
			if (!_isReady) return;
			EvaluateTunnelVisibility();
		}

		private void OnSnakeMovementEnded()
		{
			if (!_isReady) return;
			EvaluateTunnelVisibility();
		}

		private void EvaluateTunnelVisibility()
		{
			if (_view == null || _tailManager == null) return;

			// Get the tilemap cell positions for entrance and exit caps
			Vector3Int entranceCell = _entranceTransform != null
				? Vector3Int.RoundToInt(_entranceTransform.position)
				: Vector3Int.RoundToInt(transform.position);
			Vector3Int exitCell = _exitTransform != null
				? Vector3Int.RoundToInt(_exitTransform.position)
				: Vector3Int.RoundToInt(transform.position);

			// Use SnakeOccupancyManager if available via LevelController
			bool tailAtEntrance = IsAnySnakeOnCell(entranceCell);
			bool tailAtExit     = IsAnySnakeOnCell(exitCell);

			// Hide entrance cap while snake body occupies the entrance
			if (tailAtEntrance && !_entranceHidden)
			{
				_entranceHidden = true;
				_view.HideEntrance();
			}
			else if (!tailAtEntrance && _entranceHidden)
			{
				_entranceHidden = false;
				_view.ShowAll();
			}

			// Hide exit cap while snake body occupies the exit
			if (tailAtExit && !_exitHidden)
			{
				_exitHidden = true;
				_view.HideExit();
			}
			else if (!tailAtExit && _exitHidden)
			{
				_exitHidden = false;
				_view.ShowAll();
			}
		}

		private bool IsAnySnakeOnCell(Vector3Int cell)
		{
			// Use TailManager's occupancy check (it has access to the snake positions)
			if (_tailManager != null)
				return _tailManager.IsAnySnakeOnCell(cell);

			return false;
		}
	}
}
