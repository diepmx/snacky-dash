using System;
using Newtonsoft.Json;
using Voodoo.Live.Offers.Campaigns;
using Voodoo.Tune.Core;

namespace Voodoo.Live.Offers
{
	[Serializable]
	public class FeaturesConfig
	{
		public ItemDTO[] items;

		public IServerFeature[] offers;

		public VoodooConfig config;

		public ServerCampaign[] campaigns;

		public NonConsumableProductToItems nonConsumableProductToItems;

		public FeaturesConfig()
		{
		}

		[JsonConstructor]
		public FeaturesConfig(IServerFeature[] offers, ItemDTO[] items, VoodooConfig Voodoo_Config, NonConsumableProductToItems nonConsumableProductToItems, ServerCampaign[] campaigns)
		{
		}
	}
}
