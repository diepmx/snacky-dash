using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpGdprConsentWrapperIOS : GdprConsentWrapper
	{
		public bool applies;

		public GCMDataWrapper? gcmStatus;
	}
}
