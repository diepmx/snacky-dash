using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConsentManagementProvider.Android
{
	internal class ConsentWrapperAndroid : ISpSdk
	{
		internal static AndroidJavaObject consentLib;

		private AndroidJavaObject activity;

		private SpClientProxy spClient;

		private AndroidJavaConstruct constructor;

		private CustomConsentClient customConsentClient;

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

		private void RunOnUiThread(Action action)
		{
		}

		private void InvokeLoadMessage()
		{
		}

		private void InvokeLoadPrivacyManager(string pmId, AndroidJavaObject tab, AndroidJavaObject campaignType, CAMPAIGN_TYPE campaignTypeForLog)
		{
		}

		private void InvokeLoadMessageWithAuthID(string authID)
		{
		}

		private bool ValidateSpCampaigns(ref List<SpCampaign> spCampaigns)
		{
			return false;
		}
	}
}
