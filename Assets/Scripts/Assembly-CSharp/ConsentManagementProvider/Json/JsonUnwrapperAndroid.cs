namespace ConsentManagementProvider.Json
{
	internal class JsonUnwrapperAndroid
	{
		public static SpConsents UnwrapSpConsents(string json)
		{
			return null;
		}

		public static SpGdprConsent UnwrapSpGdprConsent(SpGdprConsentWrapperAndroid wrappedGdpr)
		{
			return null;
		}

		public static SpCustomConsentAndroid UnwrapSpCustomConsent(string spConsentsJson)
		{
			return null;
		}

		private static SpCcpaConsent UnwrapSpCcpaConsent(SpCcpaConsentWrapperAndroid wrappedCcpa)
		{
			return null;
		}

		private static SpUsnatConsent UnwrapSpUsnatConsent(SpUsnatConsentWrapperAndroid wrapped)
		{
			return null;
		}
	}
}
