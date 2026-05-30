using System;
using System.Runtime.CompilerServices;

namespace JuicedUp.Features.Core
{
	public sealed class GameStateManager : IGameStateReader, IGameStateWriter, IGameStateEvents, IDisposable
	{
		private DefeatType _defeatType;

		private GameState _currentGameState;

		public GameState CurrentGameState => default(GameState);

		public DefeatType DefeatType => default(DefeatType);

		[Obsolete("Legacy bridge for scene components that are not VContainer-managed yet")]
		public static event Action<GameState, DefeatType> OnGameStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Obsolete("Legacy bridge for scene components that are not VContainer-managed yet")]
		public static event Action OnStartingGame
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Obsolete("Legacy bridge for scene components that are not VContainer-managed yet")]
		public static event Action OnVictory
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GameState, DefeatType> GameStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action StartingGame
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action Victory
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Dispose()
		{
		}

		public void SetGameState(GameState state, DefeatType defeatType = DefeatType.None)
		{
		}
	}
}
