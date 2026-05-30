using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConsentManagementProvider
{
	public class CMP : ICmpSdk, ISpSdk
	{
		private GameObject mainThreadBroadcastEventsExecutor;

		private static ISpSdk concreteInstance;

		private static ICmpSdk instance;

		public static ICmpSdk Instance => null;

		public bool UseGDPR { get; private set; }

		public bool UseCCPA { get; private set; }

		public bool UseUSNAT { get; private set; }

		public bool UseIOS14 { get; private set; }

		internal static ISpSdk ConcreteInstance => null;

		public void Initialize(int accountId, int propertyId, string propertyName, MESSAGE_LANGUAGE language, List<SpCampaign> spCampaigns, CAMPAIGN_ENV campaignsEnvironment, long messageTimeoutInSeconds = 3L)
		{
		}

		public void LoadMessage(string authId = null)
		{
		}

		public void ClearAllData()
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

		public void Dispose()
		{
		}

		private void CreateBroadcastExecutorGameObject()
		{
		}

		private bool IsSpCampaignsValid(List<SpCampaign> spCampaigns)
		{
			return false;
		}

		public static string GetBridgeString(string value)
		{
			return null;
		}

		private bool IsPropertyNameValid(ref string propertyName)
		{
			return false;
		}

		private bool IsCampaignSetUp(CAMPAIGN_TYPE campaignType)
		{
			return false;
		}
	}
}
