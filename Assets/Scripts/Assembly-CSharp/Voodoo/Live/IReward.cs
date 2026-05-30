namespace Voodoo.Live
{
	public interface IReward : IResultProvider
	{
		string Type { get; }

		Item[] Items { get; }

		ItemQuantity[] Unresolved();

		ItemQuantity[] Resolve();

		void Consume();
	}
}
