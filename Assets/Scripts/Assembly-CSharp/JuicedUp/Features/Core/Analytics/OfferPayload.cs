using Voodoo.Live;

namespace JuicedUp.Features.Core.Analytics
{
	public struct OfferPayload
	{
		public ProductDTO Product { get; }

		public int Count { get; }

		public PlacementId PlacementId { get; }

		public OfferPayload(ProductDTO product, int count, PlacementId placementId)
		{
			Product = null;
			Count = 0;
			PlacementId = default(PlacementId);
		}
	}
}
