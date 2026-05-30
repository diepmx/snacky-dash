using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConsentManagementProvider.iOS
{
	internal class ConsentWrapperIOS : ISpSdk
	{
		private static GameObject IOSListenerGO;

		private static CMPiOSListenerHelper iOSListener;

		public void Initialize(int accountId, int propertyId, string propertyName, MESSAGE_LANGUAGE language, List<SpCampaign> spCampaigns, CAMPAIGN_ENV campaignsEnvironment, long messageTimeoutInSeconds)
		{
		}

		public void LoadMessage(string authId = null)
		{
		}

		public void LoadPrivacyManager(CAMPAIGN_TYPE campaignType, string pmId, PRIVACY_MANAGER_TAB tab)
		{
		}

		public void CustomConsentGDPR(string[] vendors, string[] categories, string[] legIntCategories, Action<GdprConsent> onSuccessDelegate)
		{
		}

		public void DeleteCustomConsentGDPR(string[] vendors, string[] categories, string[] legIntCategories, Action<GdprConsent> onSuccessDelegate)
		{
		}

		public void RejectAll(CAMPAIGN_TYPE campaignType)
		{
		}

		public SpConsents GetSpConsents()
		{
			return null;
		}

		public GdprConsent GetCustomConsent()
		{
			return null;
		}

		public void ClearAllData()
		{
		}

		public void Dispose()
		{
		}

		private static void CreateHelperIOSListener()
		{
		}

		public static string GetBridgeString(string value)
		{
			return null;
		}
	}
}
