using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class ConsentStringWrapper
	{
		public int sectionId;

		public string sectionName;

		public string consentString;
	}
}
