using System;

namespace JuicedUp.Features.Core
{
	public interface IGameStateEvents
	{
		event Action<GameState, DefeatType> GameStateChanged;

		event Action StartingGame;

		event Action Victory;
	}
}
