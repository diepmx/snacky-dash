using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.Core
{
	public interface ILevelProvider
	{
		string CohortName { get; }

		UniTask<LevelResolution> GetLevelAsync(int playerLevelIndex, CancellationToken ct);

		LevelDifficulty GetDifficulty(int playerLevelIndex);

		bool IsInLoop(int playerLevelIndex);

		int GetTotalContentLevels();

		int GetGameLoop(int playerLevelIndex);

		int GetOriginalLevel(int playerLevelIndex);

		void NotifyLevelCompleted(int playerLevelIndex);

		UniTask PrewarmAsync(int fromPlayerLevelIndex, CancellationToken ct);
	}
}
