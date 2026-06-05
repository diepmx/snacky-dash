using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Logic controller for the Rising Block (Bollard) obstacle.
	/// 
	/// Lifecycle:
	///   - Starts in CLOSED state (block is raised, cells are blocked).
	///   - Each time a crate delivery is completed, a token is added.
	///   - Once tokens reach _deliveriesToLower, the block lowers (opens).
	///   - If the snake is on the gate when it should lower, it waits until the snake moves off.
	///   - When the block is open (lowered), subsequent deliveries raise it again (cycle resets).
	/// </summary>
	[RequireComponent(typeof(RisingBlockView))]
	public class RisingBlockController : MonoBehaviour
	{
		// Static registry so other systems can query which cells are currently blocked
		private static readonly List<RisingBlockController> ActiveControllers
			= new List<RisingBlockController>();

		[Header("Layers")]
		[SerializeField] private string _openLayerName  = "Ground";
		[SerializeField] private string _blockLayerName = "Block";

		[Header("Cycle config")]
		[Tooltip("Number of crate deliveries required to lower the block after it has risen.")]
		[SerializeField] private int _deliveriesToLower = 1;

		[Header("Refs")]
		[SerializeField] private RisingBlockView _view;
		[SerializeField] private Collider2D _blockCollider;

		private readonly List<Vector3Int> _coveredCells = new List<Vector3Int>();
		private int _blockLayer;
		private int _openLayer;
		private int _tokens;
		private bool _isOpen;
		private int _deliveryCountSinceRisen;
		private bool _isSnakeInTunnel;
		private SnakeOccupancyManager _occupancy;

		private bool HasCoveredCells => _coveredCells.Count > 0;
		public bool IsBlockTrigger { get; private set; }

		public event Action StateChanged;

		// ─── DI ─────────────────────────────────────────────────────────────────

		[Inject]
		public void Construct(SnakeOccupancyManager occupancy)
		{
			_occupancy = occupancy;
		}

		// ─── Lifecycle ───────────────────────────────────────────────────────────

		private void Awake()
		{
			_blockLayer = LayerMask.NameToLayer(_blockLayerName);
			_openLayer  = LayerMask.NameToLayer(_openLayerName);

			// Cache cells covered by this block (used for static queries)
			CacheCoveredCells();

			if (_view != null)
				_view.SetCoveredCells(_coveredCells, _blockCollider);
		}

		private void OnEnable()
		{
			ActiveControllers.Add(this);

			Player.OnArrivedAtCrate  += OnArrivedAtCrateIndex;
			LevelBuilder.OnLevelBuilt            += OnLevelBuilt;
			TunnelTraversalHandler.OnEnterTunnel += OnEnterTunnel;
			TunnelTraversalHandler.OnExitTunnel  += OnExitTunnel;
			Player.OnArrivedAtDestination        += OnArrivedAtDestination;

			// Snap to initial closed state
			_isOpen = false;
			if (_view != null)
			{
				_view.Init();
				_view.SnapState(false);
			}

			if (_blockCollider != null)
				_blockCollider.gameObject.layer = _blockLayer;
		}

		private void OnDisable()
		{
			ActiveControllers.Remove(this);

			Player.OnArrivedAtCrate  -= OnArrivedAtCrateIndex;
			LevelBuilder.OnLevelBuilt            -= OnLevelBuilt;
			TunnelTraversalHandler.OnEnterTunnel -= OnEnterTunnel;
			TunnelTraversalHandler.OnExitTunnel  -= OnExitTunnel;
			Player.OnArrivedAtDestination        -= OnArrivedAtDestination;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			// The block collider acts as a trigger to detect if the snake is on the gate
			// (used by IsSnakeOnGate)
			IsBlockTrigger = true;
			_tokens++;
			EvaluateAndApplyState(playSound: false);
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			IsBlockTrigger = false;
			_tokens = Mathf.Max(0, _tokens - 1);
			EvaluateAndApplyState(playSound: false);
		}

		private void OnCrateCompleted(PillKind _)
		{
			_deliveryCountSinceRisen++;
			EvaluateAndApplyState(playSound: true);
		}

		// Adapter for int-based crate index event
		private void OnArrivedAtCrateIndex(int crateIndex)
		{
			OnCrateCompleted(PillKind.Strawberry);
		}

		// ─── Static queries ──────────────────────────────────────────────────────

		/// <summary>Returns true if the given cell is covered ONLY by a risen (closed) block.</summary>
		public static bool IsCellCoveredByRisenBlockOnly(Vector3Int cell)
		{
			foreach (RisingBlockController ctrl in ActiveControllers)
			{
				if (!ctrl._isOpen && ctrl.CoversCell(cell))
					return true;
			}
			return false;
		}

		/// <summary>Returns a snapshot of all cells currently blocked by closed rising blocks.</summary>
		public static HashSet<Vector3Int> GetClosedCoveredCellsSnapshot()
		{
			HashSet<Vector3Int> result = new HashSet<Vector3Int>();
			foreach (RisingBlockController ctrl in ActiveControllers)
			{
				if (!ctrl._isOpen && ctrl.HasCoveredCells)
				{
					foreach (Vector3Int cell in ctrl._coveredCells)
						result.Add(cell);
				}
			}
			return result;
		}

		private bool CoversCell(Vector3Int cell)
		{
			return _coveredCells.Contains(cell);
		}

		// ─── Tunnel awareness ─────────────────────────────────────────────────

		private void OnLevelBuilt(LevelDataSO levelData, LevelMeta __)
		{
			if (levelData != null)
				_deliveriesToLower = levelData.risingBlockDeliveriesToLower;

			_deliveryCountSinceRisen = 0;
			_isOpen = false;
			SnapState(false);
		}

		private void OnEnterTunnel(bool isBoosterTunnel)
		{
			_isSnakeInTunnel = true;
		}

		private void OnExitTunnel(bool isBoosterTunnel)
		{
			_isSnakeInTunnel = false;
			EvaluateAndApplyStateIgnoreTunnel(playSound: true);
		}

		private void OnArrivedAtDestination()
		{
			EvaluateAndApplyState(playSound: false);
		}

		private void OnTailUpdated(int tailLen)
		{
			EvaluateAndApplyState(playSound: false);
		}

		// ─── State logic ──────────────────────────────────────────────────────

		private void EvaluateAndApplyState(bool playSound)
		{
			EvaluateAndApplyState(playSound, ignoreTunnelGuard: false);
		}

		private void EvaluateAndApplyStateIgnoreTunnel(bool playSound)
		{
			EvaluateAndApplyState(playSound, ignoreTunnelGuard: true);
		}

		private void EvaluateAndApplyState(bool playSound, bool ignoreTunnelGuard)
		{
			if (!ignoreTunnelGuard && _isSnakeInTunnel) return;

			bool shouldOpen = !_isOpen
				&& _deliveryCountSinceRisen >= _deliveriesToLower
				&& !IsSnakeOnGate();

			bool shouldClose = _isOpen && _deliveryCountSinceRisen >= _deliveriesToLower;

			if (shouldOpen)
			{
				_deliveryCountSinceRisen = 0;
				ApplyState(shouldOpen: true, playSound: playSound);
			}
			else if (shouldClose)
			{
				_deliveryCountSinceRisen = 0;
				ApplyState(shouldOpen: false, playSound: playSound);
			}
		}

		private void ApplyState(bool shouldOpen, bool playSound)
		{
			_isOpen = shouldOpen;

			if (_blockCollider != null)
				_blockCollider.gameObject.layer = shouldOpen ? _openLayer : _blockLayer;

			if (_view != null)
				_view.AnimateState(shouldOpen, playSound);

			StateChanged?.Invoke();
		}

		private void SnapState(bool open)
		{
			_isOpen = open;

			if (_blockCollider != null)
				_blockCollider.gameObject.layer = open ? _openLayer : _blockLayer;

			if (_view != null)
				_view.SnapState(open);
		}

		private bool IsSnakeOnGate()
		{
			if (_occupancy == null || !HasCoveredCells) return false;

			foreach (Vector3Int cell in _coveredCells)
			{
				if (_occupancy.IsAnySnakeOnCell(cell))
					return true;
			}
			return false;
		}

		private void CacheCoveredCells()
		{
			_coveredCells.Clear();
			if (_blockCollider == null) return;

			Bounds b = _blockCollider.bounds;
			int minX = Mathf.RoundToInt(b.min.x);
			int maxX = Mathf.RoundToInt(b.max.x - 0.01f);
			int minY = Mathf.RoundToInt(b.min.y);
			int maxY = Mathf.RoundToInt(b.max.y - 0.01f);

			for (int x = minX; x <= maxX; x++)
				for (int y = minY; y <= maxY; y++)
					_coveredCells.Add(new Vector3Int(x, y, 0));
		}
	}
}
