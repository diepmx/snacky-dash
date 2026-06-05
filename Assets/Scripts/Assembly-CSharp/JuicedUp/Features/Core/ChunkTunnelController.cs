using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Controls a single chunk/segment of a Tube (Switch Tube) obstacle.
	/// Plays visual feedback when the snake head enters this tunnel cell.
	/// </summary>
	[RequireComponent(typeof(ChunkTunnelView))]
	public class ChunkTunnelController : MonoBehaviour
	{
		[SerializeField] private ChunkTunnelView _view;
		private Vector3Int _entranceCell;

		private void OnEnable()
		{
			Player.OnHeadEnterTile += OnPlayerHeadEnterTile;
		}

		private void OnDisable()
		{
			Player.OnHeadEnterTile -= OnPlayerHeadEnterTile;
		}

		/// <summary>Register which tile cell this tunnel chunk occupies.</summary>
		public void Init(Vector3Int entranceCell)
		{
			_entranceCell = entranceCell;
		}

		/// <summary>Apply a shared material to this chunk's renderer (e.g. to color-code by tunnel index).</summary>
		public void SetMaterial(Material material)
		{
			if (_view != null)
				_view.SetMaterial(material);
		}

		private void OnPlayerHeadEnterTile(Vector3Int cell, TileType tileType)
		{
			// Play entrance animation when snake head arrives at this chunk's cell
			if (cell == _entranceCell && tileType == TileType.Tunnel)
			{
				if (_view != null)
					_view.AnimateEntrance();
			}
		}
	}
}
