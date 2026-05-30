using System;
using JetBrains.Annotations;
using Voodoo.Sauce.Core;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionManager
	{
		private const string GUID = "GUID";

		private const string USER_AGENT = "userAgent";

		private const string CHROME_IOS_USER_AGENT = "CriOS";

		private const string PLAYER_PREF_DISPLAY_COUNT = "Voodoo.Sauce.Ads.GoogleChromePromotion.DisplayCount";

		private const string PLAYER_PREF_LAST_DISPLAY_DATE = "Voodoo.Sauce.Ads.GoogleChromePromotion.LastDisplayDate";

		private const string PLAYER_PREF_CLICKED_ON_INSTALL = "Voodoo.Sauce.Ads.GoogleChromePromotion.ClickedOnInstall";

		private const string USER_AGENT_GETTER_URL = "https://voodoosauce-sdk.voodoo-tech.io/GoogleChromePromotion/index.html?GUID={0}&urlScheme={1}";

		private const string DEFAULT_BROWSER_APP_URL = "googlechromes://ChromeExternalAction/DefaultBrowserSettings";

		private GoogleChromePromotionMonoBehaviour _behaviour;

		private GoogleChromePromotionConfig _config;

		[CanBeNull]
		private string _guid;

		private int _displayCount;

		private DateTime? _lastDisplayDate;

		private Action<bool> _claimRewardCallback;

		public void Initialize(GoogleChromePromotionMonoBehaviour behaviour, VoodooSauceInitCallbackResult result)
		{
		}

		private void DownloadGoogleChrome()
		{
		}

		private void ClaimReward(Action<bool> callback)
		{
		}

		private void OpenUserAgentGetterUrl(string guid, string urlScheme)
		{
		}

		private void OpenBrowserSettings()
		{
		}

		private void CacheDisplay()
		{
		}

		private void OnDeepLinkActivated(string url)
		{
		}

		private bool IsGoogleChrome(string userAgent)
		{
			return false;
		}

		private string GetUrlScheme()
		{
			return null;
		}

		private bool IsActive(GoogleChromePromotionConfig config, int displayCount, DateTime? lastDisplayDate)
		{
			return false;
		}

		private void CacheDisplayCount(int count)
		{
		}

		private int GetDisplayCount()
		{
			return 0;
		}

		private void CacheLastDisplayDate()
		{
		}

		private DateTime? GetLastDisplayDate()
		{
			return null;
		}

		private void CacheClickedOnInstall()
		{
		}

		private bool GetClickedOnInstall()
		{
			return false;
		}
	}
}
