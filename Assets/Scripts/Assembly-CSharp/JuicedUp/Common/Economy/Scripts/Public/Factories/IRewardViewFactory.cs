using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;
using UnityEngine;

namespace JuicedUp.Common.Economy.Scripts.Public.Factories
{
	public interface IRewardViewFactory
	{
		IRewardView Create(IReward reward, Transform parent, bool withText = true);

		IRewardView CreateFromPool(IReward reward, Transform parent, bool withText = true);

		void ReturnToPool(IRewardView rewardView);
	}
}
