namespace ConsentManagementProvider.Json
{
	internal class JsonUnwrapperIOS
	{
		public static SpConsents UnwrapSpConsents(string json)
		{
			return null;
		}

		public static GdprConsent UnwrapGdprConsent(string json)
		{
			return null;
		}

		private static SpGdprConsent UnwrapSpGdprConsent(SpGdprWrapperIOS wrappedGdpr)
		{
			return null;
		}

		private static GdprConsent UnwrapGdprConsent(SpGdprConsentWrapperIOS wrapped)
		{
			return null;
		}

		private static SpCcpaConsent UnwrapSpCcpaConsent(SpCcpaWrapperIOS wrappedCcpa)
		{
			return null;
		}

		private static CcpaConsent UnwrapCcpaConsent(SpCcpaConsentWrapperIOS wrapped)
		{
			return null;
		}

		private static SpUsnatConsent UnwrapSpUsnatConsent(SpUsnatWrapperIOS wrappedUsnat)
		{
			return null;
		}

		private static UsnatConsent UnwrapUsnatConsent(SpUsnatConsentWrapperIOS wrapped)
		{
			return null;
		}
	}
}
