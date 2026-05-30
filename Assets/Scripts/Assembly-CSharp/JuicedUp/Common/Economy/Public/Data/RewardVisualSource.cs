using UnityEngine;

namespace JuicedUp.Common.Economy.Public.Data
{
	public class RewardVisualSource
	{
		public readonly IReward Reward;

		public readonly Transform FromTransform;

		public readonly Transform ToTransform;

		public RewardVisualSource(IReward reward, Transform fromTransform, Transform toTransform = null)
		{
		}
	}
}
