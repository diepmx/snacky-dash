using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(ChunkTunnelView))]
	public class ChunkTunnelController : MonoBehaviour
	{
		[SerializeField]
		private ChunkTunnelView _view;

		private Vector3Int _entranceCell;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Init(Vector3Int entranceCell)
		{
		}

		public void SetMaterial(Material material)
		{
		}

		private void OnPlayerHeadEnterTile(Vector3Int cell, TileType tileType)
		{
		}
	}
}
