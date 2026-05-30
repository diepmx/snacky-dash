using System.Collections.Generic;

namespace JuicedUp.Features.Core
{
	public sealed class LevelSpawnIdMap
	{
		private const int TileIdMin = 371;

		private const int TileIdMax = 377;

		private const int MaxKinds = 7;

		private readonly Dictionary<int, PillKind> _tileIdToKind;

		private readonly Dictionary<PillKind, int> _kindToTileId;

		public LevelSpawnIdMap(RespawnSequence sequence)
		{
		}

		public bool TryGetKind(int tileId, out PillKind kind)
		{
			kind = default(PillKind);
			return false;
		}
	}
}
