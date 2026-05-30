using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpGdprWrapperIOS
	{
		public bool applies;

		public SpGdprConsentWrapperIOS consents;
	}
}
