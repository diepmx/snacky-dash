using System;
using System.Collections.Generic;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpVendorGrantWrapper
	{
		public bool granted;

		public Dictionary<string, bool> purposeGrants;
	}
}
