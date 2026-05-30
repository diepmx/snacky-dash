using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Voodoo.Sauce.Common.Utils;
using Voodoo.Sauce.Core.Model;
using Voodoo.Sauce.IAP;
using Voodoo.Sauce.Internal.Ads;
using Voodoo.Sauce.Internal.Analytics;
using Voodoo.Sauce.Internal.Editor;

namespace Voodoo.Sauce.Core
{
	[Serializable]
	[CreateAssetMenu(fileName = "Assets/Resources/VoodooSettings", menuName = "VoodooSauce/Settings file", order = 1000)]
	public class VoodooSettings : ScriptableObject, IVoodooSettings
	{
		public enum Position
		{
			Right = 0,
			Left = 1
		}

		public const string NAME = "VoodooSettings";

		public const string STORE_WORLDWIDE = "worldwide";

		public const string STORE_CHINA = "china";

		public const string DEFAULT_STORE = "worldwide";

		private static VoodooSettings _instance;

		[HideInInspector]
		public string Store;

		[CustomLabel("Voodoo Server Access Token")]
		[ExplanationText("This token is mandatory to retrieve the VoodooSauce settings of your game. Ask your Voodoo contact to give you this token.")]
		public string AccessTokenID;

		[ReadOnly]
		[LargeHeader("Settings that you must edit yourself to control AB Tests, IAP, and Splash Screen", "Manual Settings")]
		[Separator]
		public string LastUpdateDate;

		[Header("Android Specific Options")]
		[Space]
		public VoodooSauceAndroidBuildTargetEnum AndroidBuildTargetEnum;

		[Tooltip("The new manifest merge is using nested node to ensure that all manifest added is merged regardless of it's level of nodes. If this cause an issue during the build, you can switch to the Legacy Manifest Merge Tools")]
		public bool UseLegacyManifestMergeTools;

		[Tooltip("By default the manifest wont merge attributes, if you need it, then you can enable this")]
		public bool UseAttributesMerging;

		[Tooltip("To debug the new manifest merging, enable the flag below and rebuild")]
		public bool NewManifestMergeDebug;

		[Tooltip("String should look like: 'Assets/[custom]/[path]/'; This path will be used in addition to the default path to get AndroidTemplate.json files, and use them for the build. So if you need to use AndroidTemplate.json you can maintain them in any path you want.")]
		public string AndroidTemplateJsonCustomPath;

		public VoodooJvmHeapSizeEnum JvmHeapSize;

		[Header("iOS Specific Options")]
		[Space]
		public bool RunXcode16BitcodeRemoval;

		[FormerlySerializedAs("EnableFakeInUnityAds")]
		[Header("In Editor Ads")]
		public bool EnableInEditorUnityAds;

		public bool EnableInEditorRVAds;

		public bool EnableInEditorFSAds;

		public bool EnableInEditorAOAds;

		[Header("Super Premium Mode")]
		[Tooltip("[ONLY ON DEVELOPMENT MODE] Super Premium mode will automatically enable Premium mode, and Rewarded will always be ready and can trigger reward without watching the ads")]
		public bool EnableSuperPremiumMode;

		public VoodooFunnelsSettings VoodooFunnels;

		[Header("In-app Purchases")]
		[ReadOnly]
		public bool AndroidIAPEnabled;

		[ReadOnly]
		public bool iOSIAPEnabled;

		[FormerlySerializedAs("NoAdsBundleId")]
		[Tooltip("Your No-Ads in-app purchase product id for Android. You need to use the NoAdsButton component if you fill that field.")]
		public string AndroidNoAdsProductId;

		[FormerlySerializedAs("NoAdsBundleId")]
		[Tooltip("Your No-Ads in-app purchase product id for iOS. You need to use the NoAdsButton component if you fill that field.")]
		public string iOSNoAdsProductId;

		[Tooltip("Represents subscription upgrade/downgrade groups. Use these groups to specify which subscriptions can be upgraded/downgraded together within the same group. Setting it to \"None\" means that the subscription cannot be upgraded/downgraded.")]
		public string[] SubscriptionGroups;

		[Tooltip("Represents the family of products.Use these groups to specify which family exist.")]
		public string[] ProductsFamily;

		[Tooltip("The list of all products available for sale in the app")]
		public ProductDescriptor[] Products;

		[Header("In-app subscriptions, Apple's App-Specific Shared Secret")]
		[Tooltip("Get Verification Credentials from the app store connect. This key allows you to verify the auto-renewable subscriptions")]
		public string SubscriptionSharedKey;

		[Header("SplashScreen")]
		[Tooltip("Please provide your White studio logo on a transparent background with no margin.")]
		public Texture2D StudioLogoForSplashScreen;

		[Tooltip("Disable VS management of your Unity Splash Screen settings.  Any existing settings will not be reset.")]
		public bool DisableVSManagedSplashScreen;

		[Header("App Rater")]
		[Tooltip("Apple Store Id of the game")]
		[ReadOnly]
		public string AppleStoreId;

		[ReadOnly]
		public bool iOSAppRaterEnabled;

		[ReadOnly]
		public bool AndroidAppRaterEnabled;

		[Tooltip("Minimum delay when the App Rater can be displayed after the launch of the game (in seconds)")]
		public int AppRaterDelayAfterLaunchInSeconds;

		[Tooltip("Minimum delay between two App Rater displays (in seconds)")]
		public int AppRaterPostponeCooldownInSeconds;

		[Tooltip("Minimum number of games at which the App Rater will starts to be shown.If 0, the App Rater will never be shown after a game played")]
		public int AppRaterMinimumNumberOfGamesPlayed;

		[Header("Misc")]
		[Tooltip("The primary color that will show on the GDPR popup")]
		public Color GdprPrimaryColor;

		[ReadOnly]
		public bool iOSCrossPromotionEnabled;

		[ReadOnly]
		public bool AndroidCrossPromotionEnabled;

		[Header("Banner")]
		[ReadOnly]
		public bool iOSBannerCloseButtonEnabled;

		[ReadOnly]
		public bool AndroidBannerCloseButtonEnabled;

		[Tooltip("Color of the banner background")]
		public Color BannerBackgroundColor;

		[Tooltip("Sprite of the banner close button, if not set use the default one")]
		public Sprite BannerCloseButtonSprite;

		[Tooltip("Position of the banner close button")]
		public Position BannerCloseButtonPosition;

		[Tooltip("If enabled the banner background and close button position will automatically being adjusted based on Banner height from Mediation")]
		public bool EnableAutomaticBannerHeightAdjustment;

		[Header("Interstitial ad frequency configuration : Default value")]
		[Tooltip("The number of cumulative seconds between sessions to wait before displaying the first interstitial ad. If the value is higher than -1, we will use cumulativeDelayInSecondsBeforeFirstInterstitialAd to delay the first interstitial based on the cumulative value instead of using delayInSecondsBeforeFirstInterstitialAd")]
		public int cumulativeDelayInSecondsBeforeFirstInterstitialAd;

		[Tooltip("The number of seconds to wait before displaying the first interstitial ad.")]
		public int delayInSecondsBeforeFirstInterstitialAd;

		[Tooltip("The number of seconds to wait before displaying the first interstitial ad during a session.")]
		public int delayInSecondsBeforeSessionFirstInterstitialAd;

		[Tooltip("The time interval, in seconds, between consecutive interstitial ad displays within an app or game.")]
		public int delayInSecondsBetweenInterstitialAds;

		[Tooltip("The maximum number of games or gameplay sessions that will occur before displaying an interstitial ad within a gaming application.")]
		public int maxGamesBetweenInterstitialAds;

		[Tooltip("The time interval, in seconds, between displaying a rewarded video ad and an interstitial ad within an app or game.")]
		public int delayInSecondsBetweenRewardedVideoAndInterstitial;

		[Tooltip("If true, enable the functionality to replace a rewarded ad with an interstitial ad if the interstitial's CPM (Cost Per Mille) rate is higher.")]
		public bool enableReplaceRewardedIfInterstitialCpmHigher;

		[Tooltip("If true, enable the functionality to replace a rewarded ad with an alternative ad format if the rewarded ad fails to load or is unavailable.")]
		public bool enableReplaceRewardedIfNotLoaded;

		[Header("Build in Batch Mode")]
		[Tooltip("When building in batch mode (usually when using CI), VS would fetches the last changes from the Kitchen and updates the VS settings in prebuild phase.")]
		public bool RefreshKitchenSettingsBeforeBuildInBatchMode;

		[Header("VoodooLog")]
		[Tooltip("If true, a timestamp would add to the start of the log message")]
		public bool voodooLogAddTimestamp;

		[Header("Voodoo Analytics")]
		[Tooltip("If true, a local timestamp would add to context variables of every Voodoo Analytics event")]
		public bool EnableVoodooAnalyticsLocalTimestamp;

		public bool SendFirebaseInstallEvent;

		[LargeHeader("Settings sent from Voodoo Servers. Update by clicking 'Update from Online'", "Automatic Settings")]
		[WarningMessage("By checking the checkbox above, you understand that you need to obfuscate your google public key before building for Android release. Check the toggle above to ignore the error. (CHECK ONLY FOR DEBUG OR TEST PURPOSES)")]
		[Tooltip("If checked, the Android build won't be stopped because the Google Public Key is missing.")]
		public bool IgnoreTheGoogleKeyError;

		[Header("Bundle identifiers")]
		[ReadOnly]
		public string IOSBundleID;

		[ReadOnly]
		public string AndroidBundleID;

		[Header("Remote A/B Tests")]
		[Tooltip("Use Legacy A/B Tests or Remote A/B Tests via VoodooTune Config for Android")]
		[ReadOnly]
		public bool UseAndroidRemoteConfig;

		[Tooltip("Use Legacy A/B Tests or Remote A/B Tests via VoodooTune Config for iOS")]
		[ReadOnly]
		public bool UseIosRemoteConfig;

		[Header("Rewarded Ads Config")]
		[Tooltip("Display Interstitial instead of Rewarded Video if CPM Higher for iOS")]
		[ReadOnly]
		public bool EnableIosReplaceRewardedOnCpm;

		[Tooltip("Display Interstitial instead of Rewarded Video if CPM Higher for Android")]
		[ReadOnly]
		public bool EnableAndroidReplaceRewardedOnCpm;

		[Header("Rewarded Ads Config")]
		[Tooltip("Display Interstitial instead of Rewarded Video if RV is not loaded for iOS")]
		[ReadOnly]
		public bool EnableIosReplaceRewardedIfNotLoaded;

		[Tooltip("Display Interstitial instead of Rewarded Video if RV is not loaded for Android")]
		[ReadOnly]
		public bool EnableAndroidReplaceRewardedIfNotLoaded;

		[Header("Voodoo Analytics")]
		[Tooltip("Use Voodoo Analytics for iOS")]
		[ReadOnly]
		public bool UseIosVoodooAnalytics;

		[Tooltip("Use Voodoo Analytics for Android")]
		[ReadOnly]
		public bool UseAndroidVoodooAnalytics;

		[Header("Firebase Analytics")]
		[Tooltip("Use Firebase Analytics for iOS")]
		[ReadOnly]
		public bool UseIosFirebaseAnalytics;

		[Tooltip("Use Firebase Analytics for Android")]
		[ReadOnly]
		public bool UseAndroidFirebaseAnalytics;

		[Header("GameAnalytics")]
		[Tooltip("Your GameAnalytics iOS Game Key - copy/paste from the GA website")]
		[ReadOnly]
		public string GameAnalyticsIosGameKey;

		[Tooltip("Your GameAnalytics iOS Secret Key - copy/paste from the GA website")]
		[ReadOnly]
		public string GameAnalyticsIosSecretKey;

		[Tooltip("Exclude GameAnalytics SDK from iOS build")]
		[ReadOnly]
		public bool ExcludeGameAnalyticsIosSDK;

		[Tooltip("Your GameAnalytics Android Game Key - copy/paste from the GA website")]
		[ReadOnly]
		public string GameAnalyticsAndroidGameKey;

		[Tooltip("Your GameAnalytics Android Secret Key - copy/paste from the GA website")]
		[ReadOnly]
		public string GameAnalyticsAndroidSecretKey;

		[Tooltip("Exclude GameAnalytics SDK from Android build")]
		[ReadOnly]
		public bool ExcludeGameAnalyticsAndroidSDK;

		[Header("MaxAds - Ads keys")]
		[Tooltip("Leave the field blank if you don't want a certain kind of ads in your game")]
		[ReadOnly]
		public AdsKeys MaxAdsIosAdsKeys;

		[Tooltip("Leave the field blank if you don't want a certain kind of ads in your game")]
		[ReadOnly]
		public AdsKeys MaxAdsAndroidAdsKeys;

		[ReadOnly]
		public string MaxIosSdkKey;

		[ReadOnly]
		public string MaxAndroidSdkKey;

		[Tooltip("If true, disable MaxAds Quality Service SDK")]
		public bool DisableMaxAdsQualityServiceSDK;

		[Header("IronSource Mediation - keys")]
		[Tooltip("Leave the field blank if you don't want a certain kind of ads in your game")]
		[ReadOnly]
		public string IronSourceMediationIosAppKey;

		[ReadOnly]
		public string IronSourceMediationAndroidAppKey;

		[Header("AdMob")]
		[Tooltip("Ask your Voodoo agents for AdMob Android App Id")]
		[ReadOnly]
		public string AdMobAndroidAppId;

		[Tooltip("Ask your Voodoo agents for AdMob iOS App Id")]
		[ReadOnly]
		public string AdMobIosAppId;

		[Header("Amazon APS")]
		[ReadOnly]
		public AmazonKey amazonIosKey;

		[ReadOnly]
		public AmazonKey amazonAndroidKey;

		[Header("Adjust")]
		[Tooltip("Adjust iOS App Token")]
		[ReadOnly]
		public string AdjustIosAppToken;

		[Tooltip("Adjust Android App Token")]
		[ReadOnly]
		public string AdjustAndroidAppToken;

		[Tooltip("Conversion iOS Events")]
		[ReadOnly]
		public ConversionEventsSettings ConversionIosEvents;

		[Tooltip("Conversion Android Events")]
		[ReadOnly]
		public ConversionEventsSettings ConversionAndroidEvents;

		[Header("AppOpen Ads")]
		[ReadOnly]
		public bool EnableIosAppOpenAdSoftLaunch;

		[ReadOnly]
		public bool EnableAndroidAppOpenAdSoftLaunch;

		[ReadOnly]
		public AppOpenAdConfig iOSAppOpenAdConfig;

		[ReadOnly]
		public AppOpenAdConfig AndroidAppOpenAdConfig;

		[Header("Audio Ads")]
		[ReadOnly]
		public AudioAdConfig iOSAudioAdConfig;

		[ReadOnly]
		public AudioAdConfig AndroidAudioAdConfig;

		[Header("Audiomob")]
		[ReadOnly]
		public AudioMobConfig iOSAudioMobConfig;

		[ReadOnly]
		public AudioMobConfig AndroidAudioMobConfig;

		[Header("Sourcepoint")]
		[ReadOnly]
		public SourcepointConfiguration sourcepointIosConfiguration;

		[ReadOnly]
		public SourcepointConfiguration sourcepointAndroidConfiguration;

		[Header("Google Chrome Promotion")]
		[ReadOnly]
		public string googleChromePromotionAdjustToken;

		[CanBeNull]
		public AmazonKey AmazonKey => null;

		public bool IsIAPEnabled => false;

		public string MaxSdkKey => null;

		public bool MaxAdsQualityServiceEnabled => false;

		public ConversionEventsSettings ConversionEvents => null;

		public bool UseFirebaseAnalytics => false;

		public bool UseRemoteConfig => false;

		public bool EnableReplaceRewardedOnCpm => false;

		public bool EnableReplaceRewardedIfNotLoaded => false;

		public bool UseVoodooAnalytics => false;

		public bool BannerCloseButtonEnabled => false;

		public bool EnableAppOpenAdSoftLaunch => false;

		public AppOpenAdConfig AppOpenAdConfig => null;

		public SourcepointConfiguration SourcepointConfiguration => null;

		public string NoAdsBundleId => null;

		public AudioAdConfig GetIosAudioAdConfig => null;

		public AudioAdConfig GetAndroidAudioAdConfig => null;

		public static VoodooSettings Get(bool forceReload = false)
		{
			return null;
		}

		[Obsolete]
		public static VoodooSettings Load()
		{
			return null;
		}

		public bool IsChinaStore()
		{
			return false;
		}

		public string GetAdjustAppToken()
		{
			return null;
		}

		public string GetIronSourceMediationAppKey()
		{
			return null;
		}

		public static bool IsAdUnitFieldName(string fieldName)
		{
			return false;
		}
	}
}
