using System;
using System.Collections.Generic;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class CcpaConsentWrapper
	{
		public Dictionary<string, object>? GPPData;

		public string uuid;

		public string status;

		public string uspstring;

		public string[] rejectedVendors;

		public string[] rejectedCategories;

		public string childPmId;

		public bool signedLspa;

		public string webConsentPayload;

		public ConsentStatusWrapper consentStatus;
	}
}
