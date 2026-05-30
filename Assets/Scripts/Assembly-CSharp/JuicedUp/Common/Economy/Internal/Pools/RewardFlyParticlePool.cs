using JuicedUp.Common.Economy.Internal.Components;
using UnityEngine;
using UnityEngine.Pool;

namespace JuicedUp.Common.Economy.Internal.Pools
{
	internal class RewardFlyParticlePool : IRewardFlyParticlePool
	{
		private readonly ObjectPool<RewardFlyParticle> _pool;

		private readonly RewardFlyParticle _prefab;

		private readonly Transform _parent;

		public RewardFlyParticlePool(RewardFlyParticle prefab, Transform parent)
		{
		}

		public RewardFlyParticle Rent()
		{
			return null;
		}

		public void Return(RewardFlyParticle particle)
		{
		}

		private RewardFlyParticle Create()
		{
			return null;
		}

		private void OnGet(RewardFlyParticle particle)
		{
		}

		private void OnRelease(RewardFlyParticle particle)
		{
		}

		private void OnDestroy(RewardFlyParticle particle)
		{
		}
	}
}
