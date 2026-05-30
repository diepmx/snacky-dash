namespace Voodoo.Live
{
	public class VirtualCurrencyPrice : BasePrice
	{
		public string currencyType;

		public int amount;

		public VirtualCurrencyPrice(PriceDTO priceDTO)
		{
		}

		public override PriceDTO ToDTO()
		{
			return null;
		}

		public override void Validate()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
