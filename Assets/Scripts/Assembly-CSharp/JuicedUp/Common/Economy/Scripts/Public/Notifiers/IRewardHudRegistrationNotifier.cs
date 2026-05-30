using System;
using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Scripts.Public.Notifiers
{
	internal interface IRewardHudRegistrationNotifier
	{
		event Action<IRewardHudView> RewardHudRegistered;

		event Action<IRewardHudView> RewardHudUnRegistered;

		void NotifyRewardHudRegistered(IRewardHudView rewardHudView);

		void NotifyRewardHudUnregistered(IRewardHudView rewardHudView);
	}
}
