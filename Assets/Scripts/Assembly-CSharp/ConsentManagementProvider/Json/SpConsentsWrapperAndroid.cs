using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class SpConsentsWrapperAndroid
	{
		public SpCcpaConsentWrapperAndroid? ccpa;

		public SpGdprConsentWrapperAndroid? gdpr;

		public SpUsnatConsentWrapperAndroid? usnat;
	}
}
