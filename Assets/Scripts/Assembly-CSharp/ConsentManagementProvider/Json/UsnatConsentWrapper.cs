using System;
using System.Collections.Generic;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class UsnatConsentWrapper
	{
		public string? uuid;

		public Dictionary<string, object>? GPPData;

		public bool applies;
	}
}
