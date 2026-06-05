using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Quản lý tất cả Arrow (Gate + Switching Arrow) trên level.
	/// Implements IMovementValidator: block snake nếu đi sai hướng.
	///
	/// Gate (IsFixedArrow = true):
	///   - Block vĩnh viễn nếu snake đi sai hướng
	///   - Không bao giờ flip
	///
	/// Switching Arrow (IsFixedArrow = false):
	///   - Cho qua nếu đúng hướng
	///   - Flip direction NGAY KHI snake enter cell (cả arrow vừa qua + partner cùng SwitchID)
	///
	/// Arrows cùng SwitchID được pair với nhau và flip đồng thời.
	/// Arrows có IsUnique = true không có partner.
	/// </summary>
	public class ArrowGroupController : MonoBehaviour, IMovementValidator
	{
		// cell → arrow tại cell đó
		private readonly Dictionary<Vector3Int, ArrowSwitchController> _cellMap
			= new Dictionary<Vector3Int, ArrowSwitchController>();

		// Buffer để build pairs: SwitchID → danh sách arrows chưa pair
		private readonly Dictionary<int, List<ArrowSwitchController>> _pendingGroupBuffer
			= new Dictionary<int, List<ArrowSwitchController>>();

		// arrow → pair nó thuộc về
		private readonly Dictionary<ArrowSwitchController, ArrowPair> _pairByArrow
			= new Dictionary<ArrowSwitchController, ArrowPair>();

		private readonly List<ArrowPair> _pairs = new List<ArrowPair>();

		// ─── Lifecycle ────────────────────────────────────────────────────────

		private void OnEnable()
		{
			Player.OnHeadEnterTile += HandleHeadEnterTile;
		}

		private void OnDisable()
		{
			Player.OnHeadEnterTile -= HandleHeadEnterTile;
		}

		// ─── Registration ─────────────────────────────────────────────────────

		/// <summary>Đăng ký một arrow trong level. Gọi một lần khi build level.</summary>
		public void RegisterArrow(ArrowSwitchController arrow)
		{
			if (arrow == null) return;

			_cellMap[arrow.PositionArrow] = arrow;

			// Arrows không unique → đưa vào buffer để build pair
			if (!arrow.IsUnique)
			{
				int id = arrow.SwitchID;
				if (!_pendingGroupBuffer.TryGetValue(id, out List<ArrowSwitchController> list))
				{
					list = new List<ArrowSwitchController>(2);
					_pendingGroupBuffer[id] = list;
				}
				list.Add(arrow);
			}
		}

		/// <summary>Gọi sau khi đã register tất cả arrows để build pairs từ buffer.</summary>
		public void FinalizeRegistration()
		{
			foreach (KeyValuePair<int, List<ArrowSwitchController>> entry in _pendingGroupBuffer)
			{
				List<ArrowSwitchController> group = entry.Value;
				for (int i = 0; i + 1 < group.Count; i += 2)
				{
					var pair = new ArrowPair(group[i], group[i + 1]);
					_pairs.Add(pair);
					_pairByArrow[group[i]]     = pair;
					_pairByArrow[group[i + 1]] = pair;
				}
			}
			_pendingGroupBuffer.Clear();
		}

		// ─── IMovementValidator ───────────────────────────────────────────────

		bool IMovementValidator.CanPass(Vector3Int cell, DirectionPlayer direction)
		{
			if (!_cellMap.TryGetValue(cell, out ArrowSwitchController arrow))
				return true; // Không có arrow → luôn pass

			// Đúng hướng → pass
			if (arrow.IsDirectionPlayerSameAsArrow(direction))
				return true;

			// Sai hướng → shake và block
			arrow.PlayNotAllowedAnimation();
			return false;
		}

		/// <summary>
		/// Gọi sau khi snake đã thực sự đến cell (direction đã được CanPass chấp nhận).
		/// Với Switching Arrow: flip ngay tại đây.
		/// </summary>
		void IMovementValidator.OnHeadArrived(Vector3Int cell, DirectionPlayer direction)
		{
			if (!_cellMap.TryGetValue(cell, out ArrowSwitchController arrow)) return;

			// Switching arrow: flip ngay khi snake enter (không phải khi exit)
			if (!arrow.IsFixedArrow)
			{
				if (_pairByArrow.TryGetValue(arrow, out ArrowPair pair))
				{
					// Flip cả 2 arrow trong pair đồng thời
					pair.OnSnakeEntered(arrow);
				}
				else
				{
					// Arrow unique (không có pair): tự flip
					arrow.InverseDirection();
				}
			}
		}

		// ─── Private ─────────────────────────────────────────────────────────

		private void HandleHeadEnterTile(Vector3Int cell, TileType tileType)
		{
			// Hook để xử lý thêm nếu cần sau này
		}
	}
}
