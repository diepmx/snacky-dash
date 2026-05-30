using System;

namespace Voodoo.ADN
{
	public static class AdnSdkCallbacks
	{
		public static class Interstitial
		{
			public static event Action<AdnAdInfo> OnAdLoaded
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnErrorInfo> OnAdLoadFailed
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdDisplayed
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdClicked
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdImpression
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdHidden
			{
				add
				{
				}
				remove
				{
				}
			}
		}

		public static class Rewarded
		{
			public static event Action<AdnAdInfo> OnAdLoaded
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnErrorInfo> OnAdLoadFailed
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdDisplayed
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdClicked
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<AdnAdInfo> OnAdImpression
			{
				add
				{
				}
				remove
				{
				}
			}

			public static event Action<bool, AdnAdInfo> OnAdHidden
			{
				add
				{
				}
				remove
				{
				}
			}
		}

		private static Action<bool> _onSdkInitialized;

		private static Action<AdnAdInfo> _onInterstitialAdLoaded;

		private static Action<AdnErrorInfo> _onInterstitialAdLoadFailed;

		private static Action<AdnAdInfo> _onInterstitialAdDisplayed;

		private static Action<AdnAdInfo> _onInterstitialAdClicked;

		private static Action<AdnAdInfo> _onInterstitialAdImpression;

		private static Action<AdnAdInfo> _onInterstitialAdHidden;

		private static Action<AdnAdInfo> _onRewardedAdLoaded;

		private static Action<AdnErrorInfo> _onRewardedAdLoadFailed;

		private static Action<AdnAdInfo> _onRewardedAdDisplayed;

		private static Action<AdnAdInfo> _onRewardedAdClicked;

		private static Action<AdnAdInfo> _onRewardedAdImpression;

		private static Action<bool, AdnAdInfo> _onRewardedAdHidden;

		public static event Action<bool> OnSdkInitialized
		{
			add
			{
			}
			remove
			{
			}
		}

		public static void ForwardEvent(string eventPropsStr)
		{
		}

		private static void InvokeEvent<T>(Action<T> evt, T param, string eventName, bool invokeInBackground = false)
		{
		}

		private static void InvokeEvent<T1, T2>(Action<T1, T2> evt, T1 param1, T2 param2, string eventName, bool invokeInBackground = false)
		{
		}

		private static bool CanInvokeEvent(Delegate evt)
		{
			return false;
		}
	}
}
