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
			_tileIdToKind = new Dictionary<int, PillKind>(MaxKinds);
			_kindToTileId = new Dictionary<PillKind, int>(MaxKinds);
			// Fixed mapping: tileId 371 = PillKind 0 (Strawberry) ... 377 = PillKind 6 (Eggplant)
			for (int i = 0; i < MaxKinds; i++)
			{
				int tileId = TileIdMin + i;
				PillKind kind = (PillKind)i;
				_tileIdToKind[tileId] = kind;
				_kindToTileId[kind] = tileId;
			}
		}

		public bool TryGetKind(int tileId, out PillKind kind)
		{
			return _tileIdToKind.TryGetValue(tileId, out kind);
		}
	}
}
