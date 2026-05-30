using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Scripts.Public
{
	public interface IEconomyOperationsNotifier
	{
		event Action<IReward> OnRewardGranted;

		event Action<ICost> OnRewardSpent;

		void InvokeOnRewardGranted(IReward reward);

		void InvokeOnRewardsGranted(IEnumerable<IReward> reward);

		void InvokeOnRewardSpent(ICost cost);

		void InvokeOnRewardsSpent(IEnumerable<ICost> costs);
	}
}
