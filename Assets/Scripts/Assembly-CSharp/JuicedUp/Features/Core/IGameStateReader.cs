namespace JuicedUp.Features.Core
{
	public interface IGameStateReader
	{
		GameState CurrentGameState { get; }

		DefeatType DefeatType { get; }
	}
}
