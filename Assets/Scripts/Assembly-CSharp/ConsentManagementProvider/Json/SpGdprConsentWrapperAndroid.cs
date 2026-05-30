using System;
using Newtonsoft.Json;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpGdprConsentWrapperAndroid : GdprConsentWrapper
	{
		[JsonProperty("apply")]
		public bool applies;

		[JsonProperty("googleConsentMode")]
		public GCMDataWrapper gcmStatus;
	}
}
