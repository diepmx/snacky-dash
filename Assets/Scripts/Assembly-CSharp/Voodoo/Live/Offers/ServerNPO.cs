using System.Collections.Generic;
using Newtonsoft.Json;

namespace Voodoo.Live.Offers
{
	public class ServerNPO : ServerFeature, IServerFeatureSet, IServerFeature
	{
		public bool onePurchaseOnly;

		public bool isChained;

		public bool isEndless;

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public PriceDTO buyAllPrice;

		public List<ProductDTO> Features { get; set; }

		public List<IServerFeature> GetFeature()
		{
			return null;
		}

		public override ProductDTO GetProductDTO()
		{
			return null;
		}

		public override IFeature CreateFeature(Product product)
		{
			return null;
		}

		public FeatureGroup GetMultipleProductOffer()
		{
			return null;
		}

		private MultipleOffer CreateMultipleOffer()
		{
			return null;
		}

		private ChainedOffer CreateChainedOffer()
		{
			return null;
		}

		private EndlessOffer CreateEndlessOffer()
		{
			return null;
		}

		private void PopulateFeatureSet(FeatureGroup featureSet)
		{
		}
	}
}
