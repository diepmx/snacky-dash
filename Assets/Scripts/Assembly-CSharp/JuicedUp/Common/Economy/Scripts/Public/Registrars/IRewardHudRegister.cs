using JuicedUp.Common.Economy.Public.Views;

namespace JuicedUp.Common.Economy.Scripts.Public.Registrars
{
	public interface IRewardHudRegister
	{
		void RegisterRewardHudView(IRewardHudView rewardHudView);

		void UnRegisterRewardHudView(IRewardHudView rewardHudView);
	}
}
