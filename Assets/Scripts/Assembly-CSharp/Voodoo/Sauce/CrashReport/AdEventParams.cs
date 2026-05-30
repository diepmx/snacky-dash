using System.Collections.Generic;
using Voodoo.Sauce.Internal.Analytics;

namespace Voodoo.Sauce.CrashReport
{
	public class AdEventParams
	{
		public enum AdEventName
		{
			banner_shown = 0,
			fs_shown = 1,
			ao_shown = 2,
			rv_shown = 3,
			audio_ad_shown = 4,
			thumbnail_shown = 5,
			native_shown = 6,
			fs_watched = 7,
			ao_watched = 8,
			rv_watched = 9,
			native_closed = 10,
			fs_loaded = 11,
			rv_loaded = 12,
			fs_clicked = 13,
			ao_clicked = 14,
			rv_clicked = 15,
			banner_clicked = 16,
			thumbnail_clicked = 17,
			native_clicked = 18,
			fs_triggered = 19,
			ao_triggered = 20,
			rv_triggered = 21,
			native_triggered = 22,
			fs_load_requested = 23,
			ao_load_requested = 24,
			rv_load_requested = 25,
			fs_show_failed = 26,
			rv_show_failed = 27,
			ao_show_failed = 28,
			native_show_failed = 29
		}

		private string Network;

		private string AdType;

		private string Creative;

		private string ImpressionId;

		public AdEventParams(string network, string adType, string creative, string impressionId)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public Dictionary<string, string> ToDictionary()
		{
			return null;
		}

		public static AdEventParams FromAnalyticsInfo(AdAnalyticsInfo adAnalyticsInfo)
		{
			return null;
		}
	}
}
