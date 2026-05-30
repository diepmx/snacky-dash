namespace Voodoo.ADN.Internal
{
	public interface IAdnSdk
	{
		void Initialize(AdnSdkInitializationMode initializationMode);

		bool IsInitialized();

		void SetHasUserConsent(bool hasUserConsent);

		void SetDoNotSell(bool doNotSell);

		void SetDebugModeEnabled(bool enabled);

		void SetSdkParameter(string key, string value);

		void SetPublisherSignal(string key, string value);

		void SetPublisherSignals(string json);

		void SetTestAdsEnabled(bool enabled);

		string LogSdkDebugInfo();

		void LoadInterstitial();

		bool IsInterstitialReady();

		void ShowInterstitial();

		void LoadRewardedAd();

		bool IsRewardedAdReady();

		void ShowRewardedAd();
	}
}
