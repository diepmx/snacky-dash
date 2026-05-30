using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class ServerSpin : ServerFeature, IServerFeature
	{
		public List<int> probabilities;

		public List<RewardDTO> rewards;

		public SpinType spinType;

		public PriceDTO spinPrice;

		public PriceDTO rerollPrice;

		public int rerollLimit;

		public override ProductDTO GetProductDTO()
		{
			return null;
		}

		public override IFeature CreateFeature(Product product)
		{
			return null;
		}

		private Feature CreateBasicSpin(Product product)
		{
			return null;
		}

		private Feature CreateSpinWithReroll(Product product)
		{
			return null;
		}

		private IPrice GetRerollPrice()
		{
			return null;
		}
	}
}
