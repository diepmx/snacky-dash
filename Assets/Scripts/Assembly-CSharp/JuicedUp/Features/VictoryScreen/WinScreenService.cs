using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Util;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Ingredients;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Core.Scene;
using JuicedUp.Features.WeeklyMissions.Public;

namespace JuicedUp.Features.VictoryScreen
{
	public class WinScreenService : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunVictoryFlowAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public WinScreenService _003C_003E4__this;

			public CancellationToken ct;

			private WinScreenPayload _003Cpayload_003E5__2;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForSkipInputAsync_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken ct;

			private UniTask.Awaiter _003C_003Eu__1;

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

		private readonly IPopupService _popupService;

		private readonly WinScreenConfig _config;

		private readonly IngredientUnlockResolver _ingredientUnlockResolver;

		private readonly IEconomyService _economyService;

		private readonly ILevelRunStats _levelRunStats;

		private readonly ICoreGameAnalyticsService _analyticsService;

		private readonly AppRaterHelper _appRaterHelper;

		private readonly LevelController _levelController;

		private readonly ILevelProvider _levelProvider;

		private readonly RewardManager _rewardManager;

		private readonly ISceneService _sceneService;

		private readonly Loading _loading;

		private readonly IGameStateReader _gameStateReader;

		private readonly IGameStateEvents _gameStateEvents;

		private readonly IMissionExecutor _missionExecutor;

		private bool _flowInProgress;

		private CancellationTokenSource _lifetimeCts;

		private int _wonLevel;

		private string _wonDifficulty;

		public WinScreenService(IPopupService popupService, WinScreenConfig config, IngredientUnlockResolver ingredientUnlockResolver, IEconomyService economyService, ILevelRunStats levelRunStats, ICoreGameAnalyticsService analyticsService, AppRaterHelper appRaterHelper, LevelController levelController, ILevelProvider levelProvider, RewardManager rewardManager, ISceneService sceneService, Loading loading, IGameStateReader gameStateReader, IGameStateEvents gameStateEvents, IMissionExecutor missionExecutor)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnVictory()
		{
		}

		[AsyncStateMachine(typeof(_003CRunVictoryFlowAsync_003Ed__23))]
		private UniTaskVoid RunVictoryFlowAsync(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}

		private int ResolveBaseReward()
		{
			return 0;
		}

		private int ResolveRewardMultiplier()
		{
			return 0;
		}

		[AsyncStateMachine(typeof(_003CWaitForSkipInputAsync_003Ed__26))]
		private static UniTask WaitForSkipInputAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		private void ApplyLevelCompletionData()
		{
		}

		private int GrantRewardedVideoBonus(int multiplier)
		{
			return 0;
		}

		private void CompleteLevelTransition()
		{
		}
	}
}
