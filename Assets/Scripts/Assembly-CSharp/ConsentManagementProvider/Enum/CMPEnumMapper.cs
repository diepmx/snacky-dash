using System.Collections.Generic;

namespace ConsentManagementProvider.Enum
{
	internal static class CMPEnumMapper
	{
		private static Dictionary<PRIVACY_MANAGER_TAB, string> privacyManagerTabToJavaEnumKey;

		private static Dictionary<PRIVACY_MANAGER_TAB, string> privacyManagerTabToJavaEnum;

		private static Dictionary<CAMPAIGN_ENV, string> campaignEnvToJavaEnumKey;

		private static Dictionary<MESSAGE_LANGUAGE, string> messageLanguageToJavaKey;

		private static Dictionary<MESSAGE_LANGUAGE, string> messageFullLanguageToJavaKey;

		static CMPEnumMapper()
		{
		}

		public static string GetMessageLanguageKey(MESSAGE_LANGUAGE lang)
		{
			return null;
		}

		public static string GetMessageFullLanguageKey(MESSAGE_LANGUAGE lang)
		{
			return null;
		}

		public static string GetCampaignEnvKey(CAMPAIGN_ENV environment)
		{
			return null;
		}

		public static string GetPrivacyManagerTabKey(PRIVACY_MANAGER_TAB tab)
		{
			return null;
		}

		public static string GetPrivacyManagerTab(PRIVACY_MANAGER_TAB tab)
		{
			return null;
		}

		private static void InitializeMapping()
		{
		}

		private static void InitializeMessageLanguageMapping()
		{
		}

		private static void InitializeMessageFullLanguageMapping()
		{
		}

		private static void InitializeCampaignEnvMapping()
		{
		}

		private static void InitializePrivacyManagerTabMappingKey()
		{
		}

		private static void InitializePrivacyManagerTabMapping()
		{
		}
	}
}
