namespace JuicedUp.Common.Economy.Public.Data
{
	public class Reward : IReward
	{
		public RewardType Type { get; }

		public int ItemId { get; }

		public int Amount { get; }

		public bool ReplaceInsteadOfAdd { get; }

		public Reward(RewardType type, int itemId, int amount, bool replaceInsteadOfAdd = false)
		{
		}
	}
}
