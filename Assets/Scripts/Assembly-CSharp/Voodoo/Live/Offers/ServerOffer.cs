namespace Voodoo.Live.Offers
{
	public class ServerOffer : ServerFeature, IServerFeature
	{
		public RewardDTO reward;

		public PriceDTO price;

		public override ProductDTO GetProductDTO()
		{
			return null;
		}

		public override IFeature CreateFeature(Product product)
		{
			return null;
		}
	}
}
