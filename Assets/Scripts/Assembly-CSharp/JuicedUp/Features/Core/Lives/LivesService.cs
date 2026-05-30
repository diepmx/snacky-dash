using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Common.Time;
using JuicedUp.Core.Bootstrap;

namespace JuicedUp.Features.Core.Lives
{
	public class LivesService : IAsyncInitializable, IDisposable
	{
		private readonly LivesRepository _repository;

		private readonly LivesTickRunner _tickRunner;

		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IEconomyService _economyService;

		private readonly IWallet _wallet;

		private readonly IServerTimeProvider _serverTimeProvider;

		private Action<int> _onTickSecondsToNext;

		private int _livesBeforeReconcile;

		public static LivesService Instance { get; private set; }

		public LivesState State { get; private set; }

		public static event Action<LivesService> OnInstanceReady
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

		public event Action<int, int> OnLivesChanged
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

		public event Action<int> OnSecondsToNextChanged
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

		public LivesService(IDataRepository<LivesData> livesRepository, IEntitlementStorage entitlementStorage, IEconomyService economyService, IWallet wallet, IServerTimeProvider serverTimeProvider)
		{
		}

		public int GetLifeCount()
		{
			return 0;
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		public bool CanPlay()
		{
			return false;
		}

		public bool IsUnlimitedActive()
		{
			return false;
		}

		public int SecondsToNextLife()
		{
			return 0;
		}

		public int SecondsOfUnlimitedRemaining()
		{
			return 0;
		}

		public void TryConsumeLife()
		{
		}

		public bool AddLife(int count = 1)
		{
			return false;
		}

		public void SetSessionActive(bool active)
		{
		}

		public void MarkFreeRefillUsed()
		{
		}

		private void OnEntitlementChanged(EntitlementId id, int remainingSeconds)
		{
		}

		private void EnsureRegenRunningDuringUnlimited()
		{
		}

		private void GrantRegenLivesToWalletSince(int livesBeforeReconcile, int livesAfterReconcile)
		{
		}

		private void BeforeReconcileTick()
		{
		}

		private void AfterReconcileGrantRegen(int livesAfterReconcile)
		{
		}

		private void OnWalletCurrencyChanged(CurrencyId id, int _)
		{
		}

		private void RaiseLivesChanged(int current, int max)
		{
		}

		private void WireTickRunner()
		{
		}

		private void UnwireTickRunner()
		{
		}

		private void OnTickStateChanged()
		{
		}
	}
}
