using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpConsentsWrapperIOS
	{
		public SpGdprWrapperIOS gdpr;

		public SpCcpaWrapperIOS ccpa;

		public SpUsnatWrapperIOS usnat;
	}
}
