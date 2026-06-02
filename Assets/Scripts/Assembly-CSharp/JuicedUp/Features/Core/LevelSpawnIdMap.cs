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
			_tileIdToKind = new Dictionary<int, PillKind>(7);
			_kindToTileId = new Dictionary<PillKind, int>(7);
			for (int i = 0; i < 7; i++)
			{
				int num = 371 + i;
				PillKind pillKind = (PillKind)i;
				_tileIdToKind[num] = pillKind;
				_kindToTileId[pillKind] = num;
			}
		}

		public bool TryGetKind(int tileId, out PillKind kind)
		{
			return _tileIdToKind.TryGetValue(tileId, out kind);
		}
	}
}
