using System;
using Newtonsoft.Json;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpCcpaConsentWrapperAndroid : CcpaConsentWrapper
	{
		[JsonProperty("apply")]
		public bool applies;
	}
}
