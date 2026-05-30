namespace JuicedUp.Common.Economy.Public.Data
{
	public interface IMilestone
	{
		IBundle Bundle { get; }

		ICost[] Cost { get; }
	}
}
