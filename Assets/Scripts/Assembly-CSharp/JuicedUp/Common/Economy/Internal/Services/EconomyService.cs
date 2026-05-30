using System.Collections.Generic;
using JuicedUp.Common.Economy.Internal.Factories;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.Converters;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class EconomyService : IEconomyService
	{
		private readonly IRewardHudParticleTickBinder _rewardHudParticleTickBinder;

		private readonly IRewardPresentationService _rewardPresentationService;

		private readonly IEconomyOperationsNotifier _economyOperationsNotifier;

		private readonly ICoreGameAnalyticsService _coreGameAnalyticsService;

		private readonly IItemTransactionDataFactory _analyticsDataFactory;

		private readonly IHudValueSyncService _hudValueSyncService;

		private readonly IEconomyConverter _economyConverter;

		private readonly IPaymentService _paymentService;

		private readonly IRewardService _rewardService;

		public EconomyService(IRewardHudParticleTickBinder rewardHudParticleTickBinder, IRewardPresentationService rewardPresentationService, IEconomyOperationsNotifier economyOperationsNotifier, ICoreGameAnalyticsService coreGameAnalyticsService, IItemTransactionDataFactory analyticsDataFactory, IHudValueSyncService hudValueSyncService, IEconomyConverter economyConverter, IPaymentService paymentService, IRewardService rewardService)
		{
		}

		public bool CanSpend(ICost[] costs)
		{
			return false;
		}

		public bool TrySpend(ICost[] costs, EconomySource source)
		{
			return false;
		}

		public void Grant(IEnumerable<IReward> rewards, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true)
		{
		}

		public void Grant(IProduct product, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true, string purchaseUuid = null)
		{
		}

		public void Grant(IReward reward, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true)
		{
		}

		public void GrantWithLevelContext(IReward reward, EconomySource source, int level, string levelDifficulty, RewardPresentationContext context = null, bool syncImmediately = true)
		{
		}

		private void HandleGrantPresentationAndTracking(IReward reward, RewardPresentationContext context, bool syncImmediately, ItemTransactionData analyticsData)
		{
		}

		public bool TrySpendAndGrant(ICost[] costs, IEnumerable<IReward> rewards, EconomySource source, RewardPresentationContext context = null, bool syncImmediately = true)
		{
			return false;
		}

		private RewardPresentationContext WrapContext(RewardPresentationContext originalContext)
		{
			return null;
		}
	}
}
