using JuicedUp.Features.Core;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class LevelsStreakHandler : ILevelsStreakHandler
	{
		private readonly IGameStateEvents _gameStateEvents;

		private readonly IMissionExecutor _missionExecutor;

		public LevelsStreakHandler(IGameStateEvents gameStateEvents, IMissionExecutor missionExecutor)
		{
		}

		public void Initialize()
		{
		}

		public void Clear()
		{
		}

		private void OnGameStateChanged(GameState state, DefeatType defeatType)
		{
		}
	}
}
