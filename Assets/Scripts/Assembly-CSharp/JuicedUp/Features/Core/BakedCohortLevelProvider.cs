using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.Core
{
	public sealed class BakedCohortLevelProvider : ILevelProvider
	{
		private readonly LevelCohortBindings _bindings;

		public string CohortName => null;

		public BakedCohortLevelProvider(LevelCohortBindings bindings)
		{
		}

		public UniTask<LevelResolution> GetLevelAsync(int playerLevelIndex, CancellationToken ct)
		{
			return default(UniTask<LevelResolution>);
		}

		public LevelDifficulty GetDifficulty(int playerLevelIndex)
		{
			return default(LevelDifficulty);
		}

		public bool IsInLoop(int playerLevelIndex)
		{
			return false;
		}

		public int GetTotalContentLevels()
		{
			return 0;
		}

		public int GetGameLoop(int playerLevelIndex)
		{
			return 0;
		}

		public int GetOriginalLevel(int playerLevelIndex)
		{
			return 0;
		}

		public void NotifyLevelCompleted(int playerLevelIndex)
		{
		}

		public UniTask PrewarmAsync(int fromPlayerLevelIndex, CancellationToken ct)
		{
			return default(UniTask);
		}
	}
}
