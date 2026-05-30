using System;
using System.Collections.Generic;

namespace JuicedUp.Common.Economy.Public.Data
{
	public class RewardPresentationContext
	{
		public readonly IReadOnlyList<RewardVisualSource> Sources;

		public readonly Action<IReward, int> OnSingleParticleArrivedWithDelta;

		public readonly Action<IReward> OnRewardArrived;

		public readonly Action OnCompleted;

		public RewardPresentationContext(IReadOnlyList<RewardVisualSource> sources, Action<IReward, int> onSingleParticleArrivedWithDelta = null, Action<IReward> onRewardArrived = null, Action onCompleted = null)
		{
		}
	}
}
