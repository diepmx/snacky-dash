using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpUsnatConsentWrapperIOS : UsnatConsentWrapper
	{
		public ConsentStatusWrapper consentStatus;

		public List<ConsentStringWrapper> consentStrings;

		public UserConsentsWrapper userConsents;

		[JsonIgnore]
		public List<ConsentableWrapper> vendors => null;

		[JsonIgnore]
		public List<ConsentableWrapper> categories => null;
	}
}
