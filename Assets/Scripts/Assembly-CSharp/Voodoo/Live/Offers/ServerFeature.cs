namespace Voodoo.Live.Offers
{
	public abstract class ServerFeature : IServerFeature
	{
		public Conditions conditions { get; set; }

		public string id { get; set; }

		public string name { get; set; }

		public string techName { get; set; }

		public string[] triggers { get; set; }

		public string campaign { get; set; }

		public bool showCountdown { get; set; }

		public string badgeIcon { get; set; }

		public bool displayMenuBadge { get; set; }

		public string offerImage { get; set; }

		public string title { get; set; }

		public bool showBadgeCountdown { get; set; }

		public string[] highlightTexts { get; set; }

		public string type { get; set; }

		public abstract ProductDTO GetProductDTO();

		public abstract IFeature CreateFeature(Product product);

		protected void ApplyVisualAndConditions(Feature feature, bool applyNonConsumable = true)
		{
		}

		protected void ApplyNonConsumableOperator(Feature feature)
		{
		}
	}
}
