using JuicedUp.Common.Economy.Internal.Pools;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Factories
{
	internal class RewardViewFactory : IRewardViewFactory
	{
		private readonly IRewardViewSetuper _rewardViewSetuper;

		private readonly IRewardViewPool _rewardViewPool;

		private readonly Transform _defaultParent;

		private readonly RewardView _prefab;

		public RewardViewFactory(RewardView prefab, Transform defaultParent, IRewardViewSetuper rewardViewSetuper)
		{
		}

		public IRewardView Create(IReward reward, Transform parent, bool withText = true)
		{
			return null;
		}

		public IRewardView CreateFromPool(IReward reward, Transform parent, bool withText = true)
		{
			return null;
		}

		public void ReturnToPool(IRewardView rewardView)
		{
		}
	}
}
