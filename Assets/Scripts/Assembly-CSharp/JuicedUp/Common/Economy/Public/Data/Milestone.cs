namespace JuicedUp.Common.Economy.Public.Data
{
	public class Milestone : IMilestone
	{
		public IBundle Bundle { get; }

		public ICost[] Cost { get; }

		public Milestone(IBundle bundle, ICost[] cost)
		{
		}
	}
}
