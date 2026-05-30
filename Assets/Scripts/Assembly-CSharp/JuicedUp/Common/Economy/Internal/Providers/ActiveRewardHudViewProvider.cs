using System.Collections.Generic;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Notifiers;

namespace JuicedUp.Common.Economy.Internal.Providers
{
	internal class ActiveRewardHudViewProvider : IActiveRewardHudViewProvider
	{
		private readonly IRewardHudRegistrationNotifier _rewardHudRegistrationNotifier;

		private readonly List<EntitlementRewardHudView> _entitlementRewardHudViews;

		private readonly List<CurrencyRewardHudView> _currencyRewardHudViews;

		private readonly List<BoosterRewardHudView> _boosterRewardHudViews;

		public ActiveRewardHudViewProvider(IRewardHudRegistrationNotifier rewardHudRegistrationNotifier)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public IRewardHudView GetLastActivatedRewardHudView(EntitlementId entitlementId)
		{
			return null;
		}

		public IRewardHudView GetLastActivatedRewardHudView(CurrencyId currencyId)
		{
			return null;
		}

		public IRewardHudView GetLastActivatedRewardHudView(BoosterId boosterId)
		{
			return null;
		}

		private void OnCurrencyRewardHudRegistered(IRewardHudView rewardHudView)
		{
		}

		private void OnCurrencyRewardHudUnregistered(IRewardHudView rewardHudView)
		{
		}
	}
}
