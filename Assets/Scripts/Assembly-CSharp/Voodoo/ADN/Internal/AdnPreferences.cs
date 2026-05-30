namespace Voodoo.ADN.Internal
{
	internal static class AdnPreferences
	{
		private const string TEST_ADS_KEY = "adn_test_ads_enabled";

		private const string DEBUG_MODE_KEY = "adn_debug_mode_enabled";

		public static bool IsTestAdsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsDebugModeEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private static bool GetBool(string key, bool defaultValue = false)
		{
			return false;
		}

		private static void SetBool(string key, bool value)
		{
		}
	}
}
