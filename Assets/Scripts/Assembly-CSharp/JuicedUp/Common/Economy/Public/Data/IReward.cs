namespace JuicedUp.Common.Economy.Public.Data
{
	public interface IReward
	{
		RewardType Type { get; }

		int ItemId { get; }

		int Amount { get; }

		bool ReplaceInsteadOfAdd { get; }
	}
}
