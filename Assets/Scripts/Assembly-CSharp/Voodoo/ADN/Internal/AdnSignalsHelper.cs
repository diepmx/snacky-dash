using System.Collections.Generic;

namespace Voodoo.ADN.Internal
{
	internal static class AdnSignalsHelper
	{
		internal static List<Dictionary<string, object>> GetUserPurchases()
		{
			return null;
		}

		internal static List<Dictionary<string, object>> ToDictionaryList(IEnumerable<AdnAdData> ads)
		{
			return null;
		}

		internal static void SaveAdsSession(string key, List<AdnAdData> ads)
		{
		}

		internal static void SaveAdsRevenue(string key, AdnAdsAmount revenue)
		{
		}

		internal static void SaveAttributionData(string key, AdnAttributionData attribution)
		{
		}

		internal static List<AdnAdData> GetAdsSession(string key)
		{
			return null;
		}

		internal static AdnAdsAmount GetAdsRevenue(string key)
		{
			return null;
		}

		internal static AdnAttributionData GetAttributionData(string key)
		{
			return null;
		}

		internal static int GetAdsCount(string key)
		{
			return 0;
		}

		internal static void SaveAdsCount(string key, int count)
		{
		}

		internal static string GetAndUpdateSessionDate(string key, string date)
		{
			return null;
		}

		internal static List<Dictionary<string, object>> GetAdsSessionAsDictionary(string key)
		{
			return null;
		}
	}
}
