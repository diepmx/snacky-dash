namespace JuicedUp.Features.Core
{
	public static class BridgeOrientation
	{
		public static bool IsLR(TileType type)
		{
			return false;
		}

		public static bool IsUD(TileType type)
		{
			return false;
		}

		public static bool IsBridgeLike(TileType type)
		{
			return false;
		}

		public static bool IsUnderpassShape(SegmentShape shape, TileType bridgeType)
		{
			return false;
		}
	}
}
