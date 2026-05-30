namespace Voodoo.Live
{
	public class Reward : IReward, IResultProvider
	{
		public static readonly Reward Empty;

		public string hashId;

		public ItemQuantity[] ItemQuantities;

		public Result Validation { get; private set; }

		public string Type => null;

		public Item[] Items => null;

		public ItemQuantity[] Unresolved()
		{
			return null;
		}

		public ItemQuantity[] Resolve()
		{
			return null;
		}

		public void Consume()
		{
		}

		public Reward WithValidation(Result validation)
		{
			return null;
		}

		public void Validate()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
