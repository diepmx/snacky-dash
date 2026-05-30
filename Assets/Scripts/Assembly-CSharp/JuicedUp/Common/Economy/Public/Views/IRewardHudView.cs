using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Views
{
	public interface IRewardHudView
	{
		Transform RewardFlyTarget { get; }

		void Show();

		void Hide();

		void SetRewardAmount(string amount);

		void SetRewardIcon(Sprite icon);

		void ActivateImpactAnimation();
	}
}
