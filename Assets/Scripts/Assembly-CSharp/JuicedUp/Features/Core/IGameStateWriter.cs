namespace JuicedUp.Features.Core
{
	public interface IGameStateWriter
	{
		void SetGameState(GameState state, DefeatType defeatType = DefeatType.None);
	}
}
