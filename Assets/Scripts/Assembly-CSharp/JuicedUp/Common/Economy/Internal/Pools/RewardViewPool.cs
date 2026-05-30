using JuicedUp.Common.Economy.Internal.Views;
using UnityEngine;
using UnityEngine.Pool;

namespace JuicedUp.Common.Economy.Internal.Pools
{
	internal class RewardViewPool : IRewardViewPool
	{
		private readonly ObjectPool<RewardView> _pool;

		private readonly RewardView _prefab;

		private readonly Transform _parent;

		public RewardViewPool(RewardView prefab, Transform parent)
		{
		}

		public RewardView Rent()
		{
			return null;
		}

		public void Return(RewardView rewardView)
		{
		}

		private RewardView Create()
		{
			return null;
		}

		private void OnGet(RewardView rewardView)
		{
		}

		private void OnRelease(RewardView rewardView)
		{
		}

		private void OnDestroy(RewardView rewardView)
		{
		}
	}
}
