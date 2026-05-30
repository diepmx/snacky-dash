using UnityEngine;

namespace JuicedUp.Features.Core.Analytics
{
	public readonly struct TailBridgeCollisionData
	{
		public Vector3 HeadPosition { get; }

		public Vector3 CollisionPosition { get; }

		public Vector3Int BridgeCell { get; }

		public TileType BridgeTileType { get; }

		public bool ResultedInCut { get; }

		public TailBridgeCollisionData(Vector3 headPosition, Vector3 collisionPosition, Vector3Int bridgeCell, TileType bridgeTileType, bool resultedInCut)
		{
			HeadPosition = default(Vector3);
			CollisionPosition = default(Vector3);
			BridgeCell = default(Vector3Int);
			BridgeTileType = default(TileType);
			ResultedInCut = false;
		}
	}
}
