namespace Voodoo.Live
{
	public interface IPrice : IResultProvider
	{
		string type { get; set; }

		PriceDTO ToDTO();
	}
}
