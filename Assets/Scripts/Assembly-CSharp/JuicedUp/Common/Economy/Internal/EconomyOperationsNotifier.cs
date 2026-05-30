using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Scripts.Public;

namespace JuicedUp.Common.Economy.Internal
{
	internal class EconomyOperationsNotifier : IEconomyOperationsNotifier
	{
		public event Action<IReward> OnRewardGranted
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

		public event Action<ICost> OnRewardSpent
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

		public void InvokeOnRewardGranted(IReward reward)
		{
		}

		public void InvokeOnRewardsGranted(IEnumerable<IReward> rewards)
		{
		}

		public void InvokeOnRewardSpent(ICost cost)
		{
		}

		public void InvokeOnRewardsSpent(IEnumerable<ICost> costs)
		{
		}
	}
}
