namespace Voodoo.Live
{
	public class RewardedVideoPrice : BasePrice
	{
		public int amount;

		public RewardedVideoPrice(PriceDTO priceDTO)
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
