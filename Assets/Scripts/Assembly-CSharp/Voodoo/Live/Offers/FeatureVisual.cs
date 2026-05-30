using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class FeatureVisual
	{
		public bool showCountdown;

		public string badgeIcon;

		public bool displayMenuBadge;

		public string offerImage;

		public string title;

		public bool showBadgeCountdown;

		public string[] highlightTexts;

		private Dictionary<string, string> _normalizedHighlightTexts;

		public string GetHighlightTextByKey(string key)
		{
			return null;
		}

		private Dictionary<string, string> InitializeDictionary()
		{
			return null;
		}
	}
}
