namespace Voodoo.Live.Offers
{
	public class FeatureFactory
	{
		private readonly IInventory _inventory;

		public FeatureFactory(IInventory inventory)
		{
		}

		public IFeature CreateFeature(IServerFeature serverFeature)
		{
			return null;
		}

		private void SetupFeatureBaseInfo(IFeature feature)
		{
		}

		public Product CreateProduct(ProductDTO productDTO)
		{
			return null;
		}
	}
}
