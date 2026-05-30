using System.Collections.Generic;
using UnityEngine.Scripting;
using Voodoo.ADN.Internal;

namespace Voodoo.ADN
{
	[Preserve]
	public class AdnSdk
	{
		private readonly IAdnSdk platformSdk;

		private static AdnSdk _instance;

		private static AdnSdk Instance => null;

		public static string PluginVersion => null;

		private AdnSdk()
		{
		}

		public static void Initialize(AdnSdkInitializationMode initializationMode = AdnSdkInitializationMode.WithMediation, bool hasUserConsent = true, bool isCcpaApplicable = false, Dictionary<string, string> extraParameters = null)
		{
		}

		public static bool IsSdkInitialized()
		{
			return false;
		}

		public static void SetHasUserConsent(bool hasUserConsent)
		{
		}

		public static void SetDoNotSell(bool doNotSell)
		{
		}

		public static void SetTestAdsEnabled(bool enabled)
		{
		}

		public static void SetDebugModeEnabled(bool enabled)
		{
		}

		public static void SetPublisherSignal(string key, string value)
		{
		}

		public static void SetPublisherSignals(string json)
		{
		}

		public static void SetSdkParameter(string key, string value)
		{
		}

		public static string LogSdkStateSnapshot()
		{
			return null;
		}

		public static void LoadInterstitial()
		{
		}

		public static bool IsInterstitialReady()
		{
			return false;
		}

		public static void ShowInterstitial()
		{
		}

		public static void LoadRewardedAd()
		{
		}

		public static bool IsRewardedAdReady()
		{
			return false;
		}

		public static void ShowRewardedAd()
		{
		}

		public static string LogSdkDebugInfo()
		{
			return null;
		}

		public static void SetExtraParameters(string json)
		{
		}

		public static void SetExtraParameter(string key, string value)
		{
		}
	}
}
