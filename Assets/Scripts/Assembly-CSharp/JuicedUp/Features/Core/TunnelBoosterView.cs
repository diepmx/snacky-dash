using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	public class TunnelBoosterView : MonoBehaviour
	{
		[Header("Visual")]
		[SerializeField]
		private Transform _overlaysRoot;

		[Header("Configuration")]
		[SerializeField]
		private TunnelController _tunnelPrefab;

		[SerializeField]
		private float _pickRadiusWorld;

		[SerializeField]
		private bool _useNearestCellAssist;

		[Header("Dependencies")]
		[SerializeField]
		private Player _player;

		[SerializeField]
		private TailManager _tailManager;

		private readonly Dictionary<Vector3Int, GameObject> _overlayByCell;

		public TunnelController TunnelPrefab => null;

		public float PickRadiusWorld => 0f;

		public bool UseNearestCellAssist => false;

		public Player Player => null;

		public TailManager TailManager => null;

		public void Init(Tilemap tilemap)
		{
		}

		public IEnumerable<Vector3Int> GetAllOverlayCells()
		{
			return null;
		}

		public void RefreshOverlays(HashSet<Vector3Int> validCells)
		{
		}

		public void HideAllOverlays()
		{
		}

		private void BuildOverlayIndex(Tilemap tilemap)
		{
		}
	}
}
