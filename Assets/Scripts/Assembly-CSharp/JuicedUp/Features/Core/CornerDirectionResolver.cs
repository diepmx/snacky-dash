namespace JuicedUp.Features.Core
{
	public static class CornerDirectionResolver
	{
		public static DirectionPlayer Resolve(DirectionPlayer currentDirection, TileType cornerTileType)
		{
			return default(DirectionPlayer);
		}

		public static bool IsPassThrough(TileType tile, DirectionPlayer dir)
		{
			return false;
		}
	}
}
