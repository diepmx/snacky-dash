using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Features.Boosters.Tutorial;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Shop.Internal.Controllers;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class BoosterButtonUIInitializer : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BoosterButtonUIInitializer _003C_003E4__this;

			public CancellationToken cancellationToken;

			private BoosterButtonUI[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

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

		private readonly BoosterButtonUI[] _buttons;

		private readonly BoosterBuyUI _boosterBuyPanel;

		private readonly BoosterManager _manager;

		private readonly IWallet _wallet;

		private readonly IEconomyService _economyService;

		private readonly IRewardHudRegister _rewardHudRegister;

		private readonly IShopViewController _shopViewController;

		private readonly ICoreGameAnalyticsService _analyticsService;

		private readonly BoosterTutorialState _tutorialState;

		private readonly IGameStateReader _gameStateReader;

		public BoosterButtonUIInitializer(BoosterButtonUI[] buttons, BoosterBuyUI boosterBuyPanel, BoosterManager manager, IWallet wallet, IEconomyService economyService, IShopViewController shopViewController, IRewardHudRegister rewardHudRegister, ICoreGameAnalyticsService analyticsService, BoosterTutorialState tutorialState, IGameStateReader gameStateReader)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__11))]
		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}
	}
}
