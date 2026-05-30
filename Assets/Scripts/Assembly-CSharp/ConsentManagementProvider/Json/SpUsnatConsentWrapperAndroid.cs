using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpUsnatConsentWrapperAndroid : UsnatConsentWrapper
	{
		public StatusWrapperAndroid statuses;

		public string consentStrings;

		public string vendors;

		public string categories;
	}
}
