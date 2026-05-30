using System.Collections.Generic;

namespace ConsentManagementProvider.Json
{
	internal static class JsonUnwrapperHelper
	{
		internal static T Deserialize<T>(string json)
		{
			return default(T);
		}

		internal static GdprConsent UnwrapBaseSpGdprConsent<T>(T wrapped) where T : GdprConsentWrapper
		{
			return null;
		}

		internal static void UnwrapGrantsGdpr(Dictionary<string, SpVendorGrantWrapper> grants, ref GdprConsent unwrapped, string isGrantedString)
		{
		}

		internal static ConsentStatus UnwrapConsentStatus(ConsentStatusWrapper wrappedconsentStatus)
		{
			return null;
		}

		internal static void UnwrapUsnatConsents(List<ConsentStringWrapper> consentStringsWrapped, List<ConsentableWrapper> vendorsWrapped, List<ConsentableWrapper> categoriesWrapped, out List<ConsentString> consentStrings, out List<Consentable> vendors, out List<Consentable> categories)
		{
			consentStrings = null;
			vendors = null;
			categories = null;
		}

		private static List<Consentable> UnwrapConsentable(List<ConsentableWrapper> wrapped)
		{
			return null;
		}

		private static List<ConsentString> UnwrapConsentStrings(List<ConsentStringWrapper> consentStringsWrapped)
		{
			return null;
		}
	}
}
