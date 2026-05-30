using System.Collections.Generic;

namespace ConsentManagementProvider
{
	public class UsnatConsent
	{
		public string? uuid;

		public Dictionary<string, object>? GPPData;

		public bool applies;

		public List<ConsentString> consentStrings;

		public List<Consentable> vendors;

		public List<Consentable> categories;

		public StatusesUsnat statuses;

		public UsnatConsent(string? uuid, bool applies, List<ConsentString> consentStrings, List<Consentable> vendors, List<Consentable> categories, ConsentStatus consentStatus, Dictionary<string, object>? GPPData)
		{
		}

		public UsnatConsent(string? uuid, bool applies, List<ConsentString> consentStrings, List<Consentable> vendors, List<Consentable> categories, StatusesUsnat statuses, Dictionary<string, object>? GPPData)
		{
		}

		public string ToFullString()
		{
			return null;
		}
	}
}
