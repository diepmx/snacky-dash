using System.Collections.Generic;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public static class GoogleChromePromotionAnalytics
	{
		public enum EventName
		{
			promo_shown = 0,
			promo_clicked = 1,
			promo_rewarded = 2,
			promo_not_rewarded = 3
		}

		private const string EVENT_TYPE = "custom";

		private const string PROMO_COUNT = "promo_count";

		private static readonly Dictionary<string, float> _countriesPrices;

		private static Dictionary<string, object> _eventProperties;

		private static List<VoodooSauce.AnalyticsProvider> vanProviders;

		public static void SetProperties(int promoCount)
		{
		}

		public static void TrackEvent(EventName eventName)
		{
		}

		public static void TrackRevenue(string countryCode, string adjustToken)
		{
		}

		private static void TrackRevenueOnAdjust(float revenue, string adjustToken)
		{
		}

		private static void TrackRevenueOnVAN(float revenue)
		{
		}

		public static void AddRangeOverride<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
		{
		}
	}
}
