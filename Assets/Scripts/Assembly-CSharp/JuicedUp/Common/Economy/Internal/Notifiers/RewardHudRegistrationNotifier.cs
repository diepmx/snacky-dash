using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Notifiers;

namespace JuicedUp.Common.Economy.Internal.Notifiers
{
	internal class RewardHudRegistrationNotifier : IRewardHudRegistrationNotifier
	{
		public event Action<IRewardHudView> RewardHudRegistered
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

		public event Action<IRewardHudView> RewardHudUnRegistered
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

		public void NotifyRewardHudRegistered(IRewardHudView rewardHudView)
		{
		}

		public void NotifyRewardHudUnregistered(IRewardHudView rewardHudView)
		{
		}
	}
}
