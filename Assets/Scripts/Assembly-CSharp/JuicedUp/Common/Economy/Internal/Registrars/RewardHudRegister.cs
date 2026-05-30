using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Notifiers;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;

namespace JuicedUp.Common.Economy.Internal.Registrars
{
	internal class RewardHudRegister : IRewardHudRegister
	{
		private readonly IRewardHudRegistrationNotifier _rewardHudRegistrationNotifier;

		public RewardHudRegister(IRewardHudRegistrationNotifier rewardHudRegistrationNotifier)
		{
		}

		public void RegisterRewardHudView(IRewardHudView rewardHudView)
		{
		}

		public void UnRegisterRewardHudView(IRewardHudView rewardHudView)
		{
		}
	}
}
