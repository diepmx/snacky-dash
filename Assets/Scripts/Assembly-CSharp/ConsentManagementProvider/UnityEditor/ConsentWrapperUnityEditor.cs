using System;
using System.Collections.Generic;

namespace ConsentManagementProvider.UnityEditor
{
	public class ConsentWrapperUnityEditor : ISpSdk
	{
		public void Initialize(int accountId, int propertyId, string propertyName, MESSAGE_LANGUAGE language, List<SpCampaign> spCampaigns, CAMPAIGN_ENV campaignsEnvironment, long messageTimeoutInSeconds = 3L)
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
	}
}
