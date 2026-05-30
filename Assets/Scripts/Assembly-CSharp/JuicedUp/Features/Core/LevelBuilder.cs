using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Analytics;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Core
{
	public class LevelBuilder : MonoBehaviour, IAsyncInitializable
	{
		[Serializable]
		public struct IntRangeMap
		{
			public int startLevelInclusive;

			public int value;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitGameAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LevelBuilder _003C_003E4__this;

			public CancellationToken token;

			private int _003CcurrentLevel_003E5__2;

			private UniTask<LevelResolution>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static Action<LevelDataSO, LevelMeta> OnLevelBuilt;

		public static Action<LevelDataSO, LevelBuilder> OnLevelBuiltAnalytics;

		[Header("[Settings]------------------------------")]
		public LevelController levelController;

		[Header("[Debug]------------------------------")]
		[HideInInspector]
		public List<Chunk> allChunkInstantiated;

		[Header("Editor - Level Prefab Browser")]
		public List<LevelBrowserHeaderData> browserHeaders;

		public List<IntRangeMap> levelsNormalDifficulty;

		private CrateManager crateManager;

		private ILevelRunStats _levelRunStats;

		private ILevelProvider _levelProvider;

		private SnakeOccupancyManager _snakeOccupancyManager;

		private RemoteConfigService _remoteConfigService;

		private IGameStateWriter _gameStateWriter;

		private ICoreGameAnalyticsService _coreGameAnalytics;

		[Inject]
		private void Construct(ILevelRunStats levelRunStats, ILevelProvider levelProvider, SnakeOccupancyManager snakeOccupancyManager, RemoteConfigService remoteConfigService, IGameStateWriter gameStateWriter, ICoreGameAnalyticsService coreGameAnalytics)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static LevelDifficulty DifficultyFromScore(int difficultyScore, int normalDifficulty)
		{
			return default(LevelDifficulty);
		}

		private static void SetupChunk(Chunk chunk)
		{
		}

		public Level SetupLevel(GameObject _level)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CInitGameAsync_003Ed__18))]
		public UniTask InitGameAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private Level CreateLevel(LevelDataSO levelDataSo)
		{
			return null;
		}

		public List<LevelDifficulty> GetDifficultiesRange(int startLevelIndex, int count)
		{
			return null;
		}

		private bool ShouldKeepDirectChildForGameplay(GameObject root)
		{
			return false;
		}
	}
}
