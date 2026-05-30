using UnityEngine;

namespace Voodoo.ADN.Internal
{
	internal class AdnSdkAndroid : AdnSdkBase, IAdnSdk
	{
		private class BackgroundEventCallbackProxy : AndroidJavaProxy
		{
			public BackgroundEventCallbackProxy()
				: base((string)null)
			{
			}

			public void onEvent(string propsStr)
			{
			}
		}

		private const string ADN_PLUGIN_PACKAGE = "io.adn.unityplugin.publisher";

		private static readonly AndroidJavaClass PluginClass;

		private static readonly BackgroundEventCallbackProxy CallbackProxy;

		protected override void InitializeSdk()
		{
		}

		public bool IsInitialized()
		{
			return false;
		}

		public void SetHasUserConsent(bool hasUserConsent)
		{
		}

		public void SetDoNotSell(bool doNotSell)
		{
		}

		public void SetPublisherSignal(string key, string value)
		{
		}

		public void SetPublisherSignals(string json)
		{
		}

		public void SetDebugModeEnabled(bool enabled)
		{
		}

		public void SetTestAdsEnabled(bool enabled)
		{
		}

		public string LogSdkDebugInfo()
		{
			return null;
		}

		public void SetSdkParameter(string key, string value)
		{
		}

		public void LoadInterstitial()
		{
		}

		public bool IsInterstitialReady()
		{
			return false;
		}

		public void ShowInterstitial()
		{
		}

		public void LoadRewardedAd()
		{
		}

		public bool IsRewardedAdReady()
		{
			return false;
		}

		public void ShowRewardedAd()
		{
		}

		private static AndroidJavaClass PluginClassInstance()
		{
			return null;
		}

		private static BackgroundEventCallbackProxy EventCallbackInstance()
		{
			return null;
		}
	}
}
