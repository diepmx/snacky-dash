namespace Voodoo.Live.Offers
{
	public abstract class FeatureDTO : IFeatureDTO
	{
		public Conditions offerConditions;

		public string id;

		public string name;

		public string techName;

		public string[] triggers;

		public int multiplier;

		public string campaign;

		public bool showCountdown;

		public string badgeIcon;

		public bool displayMenuBadge;

		public string offerImage;

		public string title;

		public bool showBadgeCountdown;

		public string[] highlightTexts;

		public string type { get; }

		public abstract IFeature ToValidFormat();

		public void ConvertToValidFormat(IFeature feature)
		{
		}
	}
}
