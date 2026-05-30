using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(RisingBlockView))]
	public class RisingBlockController : MonoBehaviour
	{
		private static readonly List<RisingBlockController> ActiveControllers;

		[Header("Layers")]
		[SerializeField]
		private string _openLayerName;

		[SerializeField]
		private string _blockLayerName;

		[Header("Cycle config")]
		[Tooltip("Number of crate deliveries required to lower the block after it has risen.")]
		[SerializeField]
		private int _deliveriesToLower;

		[Header("Refs")]
		[SerializeField]
		private RisingBlockView _view;

		[SerializeField]
		private Collider2D _blockCollider;

		private readonly List<Vector3Int> _coveredCells;

		private int _blockLayer;

		private int _openLayer;

		private int _tokens;

		private bool _isOpen;

		private int _deliveryCountSinceRisen;

		private bool _isSnakeInTunnel;

		private SnakeOccupancyManager _occupancy;

		private bool HasCoveredCells => false;

		public bool IsBlockTrigger { get; private set; }

		public event Action StateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		public void Construct(SnakeOccupancyManager occupancy)
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
		}

		private void OnTriggerExit2D(Collider2D col)
		{
		}

		private void OnCrateCompleted(PillKind _)
		{
		}

		public static bool IsCellCoveredByRisenBlockOnly(Vector3Int cell)
		{
			return false;
		}

		public static HashSet<Vector3Int> GetClosedCoveredCellsSnapshot()
		{
			return null;
		}

		private bool CoversCell(Vector3Int cell)
		{
			return false;
		}

		private void OnLevelBuilt(LevelDataSO levelData, LevelMeta __)
		{
		}

		private void OnEnterTunnel(bool isBoosterTunnel)
		{
		}

		private void OnExitTunnel(bool isBoosterTunnel)
		{
		}

		private void OnArrivedAtDestination()
		{
		}

		private void OnTailUpdated(int tailLen)
		{
		}

		private void EvaluateAndApplyState(bool playSound)
		{
		}

		private void EvaluateAndApplyStateIgnoreTunnel(bool playSound)
		{
		}

		private void EvaluateAndApplyState(bool playSound, bool ignoreTunnelGuard)
		{
		}

		private void ApplyState(bool shouldOpen, bool playSound)
		{
		}

		private void SnapState(bool open)
		{
		}

		private bool IsSnakeOnGate()
		{
			return false;
		}

		private void CacheCoveredCells()
		{
		}
	}
}
