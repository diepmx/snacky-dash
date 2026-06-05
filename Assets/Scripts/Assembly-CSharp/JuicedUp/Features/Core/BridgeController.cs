using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Controller cho Switchable Bridge (Flipping Bridge).
	///
	/// Được điều khiển bởi SwitchController cùng _bridgeGroupId.
	/// Khi Switch toggle:
	///   - Nếu snake KHÔNG trên bridge → animate ngay
	///   - Nếu snake ĐANG trên bridge → defer đến khi snake rời đi
	///
	/// State:
	///   - Off (Closed) = bridge ở vị trí A (chặn một đường)
	///   - On  (Open)   = bridge lật sang vị trí B (mở đường kia)
	/// </summary>
	[RequireComponent(typeof(BridgeView))]
	public class BridgeController : MonoBehaviour
	{
		// ─── Static group registry ────────────────────────────────────────────
		private static readonly Dictionary<int, List<BridgeController>> _groupRegistry
			= new Dictionary<int, List<BridgeController>>();

		/// <summary>
		/// Toggle tất cả BridgeController trong group có groupId = id.
		/// Gọi từ SwitchController.
		/// </summary>
		public static void ToggleGroup(int groupId, SwitchToggleState newState)
		{
			if (!_groupRegistry.TryGetValue(groupId, out List<BridgeController> group)) return;
			foreach (BridgeController bridge in group)
				bridge.SetDesired(newState);
		}

		// ─── Instance ─────────────────────────────────────────────────────────

		[SerializeField] private BridgeView _view;

		[Header("Group — phải khớp với SwitchController._bridgeGroupId")]
		[SerializeField] private int _bridgeGroupId;

		[Header("State ban đầu (do level designer set)")]
		[SerializeField] private SwitchToggleState _initialState = SwitchToggleState.Off;

		private Vector3Int _cell;
		private SnakeOccupancyManager _occupancy;
		private LevelController _levelController;
		private SwitchToggleState _desiredState;
		private CancellationTokenSource _cts;
		private bool _isInitialized;
		private int _requestVersion;

		// ─── Lifecycle ────────────────────────────────────────────────────────

		private void OnEnable()
		{
			// Register vào group
			if (!_groupRegistry.TryGetValue(_bridgeGroupId, out List<BridgeController> list))
			{
				list = new List<BridgeController>();
				_groupRegistry[_bridgeGroupId] = list;
			}
			if (!list.Contains(this)) list.Add(this);

			if (_isInitialized)
				ApplyStateImmediate(_desiredState);
		}

		private void OnDisable()
		{
			_cts?.Cancel();
			_cts?.Dispose();
			_cts = null;

			if (_groupRegistry.TryGetValue(_bridgeGroupId, out List<BridgeController> list))
				list.Remove(this);
		}

		// ─── Init ─────────────────────────────────────────────────────────────

		/// <summary>Gọi từ LevelBuilder sau khi spawn bridge prefab.</summary>
		public void Init(Vector3Int cell, SnakeOccupancyManager occupancy, LevelController levelController)
		{
			_cell            = cell;
			_occupancy       = occupancy;
			_levelController = levelController;
			_desiredState    = _initialState;
			_isInitialized   = true;

			// Snap về trạng thái ban đầu (không animate)
			ApplyStateImmediate(_desiredState);
		}

		// ─── State control ────────────────────────────────────────────────────

		private void SetDesired(SwitchToggleState state)
		{
			_desiredState = state;
			StartDeferredApply();
		}

		/// <summary>Apply ngay (không chờ snake rời), dùng khi init.</summary>
		private void ApplyStateImmediate(SwitchToggleState state)
		{
			_cts?.Cancel();
			_cts?.Dispose();
			_cts = null;

			if (_view != null) _view.SnapState(state == SwitchToggleState.On);
			UpdateTileType(state);
		}

		/// <summary>
		/// Nếu snake không trên bridge → apply ngay.
		/// Nếu snake trên bridge → chờ snake rời rồi mới apply.
		/// </summary>
		private void StartDeferredApply()
		{
			_cts?.Cancel();
			_cts?.Dispose();
			_cts = new CancellationTokenSource();

			int version = ++_requestVersion;
			DeferredApplyAsync(version, _cts.Token).Forget();
		}

		private async UniTaskVoid DeferredApplyAsync(int version, CancellationToken token)
		{
			float pollInterval = (_view != null) ? _view.PollInterval : 0.1f;
			if (pollInterval <= 0f) pollInterval = 0.1f;

			// Chờ đến khi snake rời khỏi cell (nếu đang đứng trên)
			while (!token.IsCancellationRequested && version == _requestVersion)
			{
				if (!IsSnakeOnBridge())
					break;

				await UniTask.Delay(System.TimeSpan.FromSeconds(pollInterval), cancellationToken: token);
			}

			if (token.IsCancellationRequested || version != _requestVersion) return;

			// Apply state với animation
			if (_view != null)
				_view.AnimateState(_desiredState, withSound: true);

			UpdateTileType(_desiredState);
		}

		private bool IsSnakeOnBridge()
		{
			if (_occupancy == null) return false;
			return _occupancy.IsAnySnakeOnCell(_cell);
		}

		private void UpdateTileType(SwitchToggleState state)
		{
			if (_levelController == null) return;

			// Lấy tile type hiện tại để xác định orientation
			if (!_levelController.TryGetTileType(_cell, out TileType currentType))
				return;

			TileType newType;
			if (state == SwitchToggleState.On)
			{
				// Open: bridge lật sang vị trí cho phép đi qua
				newType = BridgeOrientation.IsLR(currentType)
					? TileType.BridgeSwitchableLR
					: TileType.BridgeSwitchableUD;
			}
			else
			{
				// Closed: bridge ở vị trí chặn
				newType = TileType.BridgeDownStop;
			}

			_levelController.SetTileType(_cell, newType);
		}
	}
}
