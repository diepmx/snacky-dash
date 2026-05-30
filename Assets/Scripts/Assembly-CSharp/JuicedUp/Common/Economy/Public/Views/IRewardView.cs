using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Views
{
	public interface IRewardView
	{
		GameObject GameObject { get; }

		void SetReward(Sprite sprite, string amount);

		void ActivateShowAnimation();

		void ActivateHideAnimation();
	}
}
