using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Voodoo.Sauce.Ads;
using Voodoo.Sauce.Ads.Internal;
using Voodoo.Sauce.Internal.Ads;

namespace Voodoo.Sauce.Debugger
{
	public class AdsDebugScreen : Screen
	{
		[CompilerGenerated]
		private sealed class _003CRefreshPeriodically_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AdsDebugScreen _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRefreshPeriodically_003Ed__16(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private DebugButtonWithInputField _showInterstitialButton;

		private DebugButtonWithInputField _forceShowInterstitialButton;

		private DebugButtonWithInputField _showRewardedVideoButton;

		private DebugButtonWithInputField _showAppOpenButton;

		private DebugButtonWithInputField _triggerAndShowRewardedVideoButton;

		private DebugButtonWithInputField _showBackupInterstitialButton;

		private DebugButtonWithInputField _showBackupRewardedButton;

		private int _lastTime;

		private TwoAdsInARow _twoAdsInARow;

		private AppHarbrConfig _appHarbrConfig;

		private const int TIME_REFRESH_INTERVAL = 5;

		private const string INTERSTITIAL_ADS_CONDITION = "(sec before first FS, sec before session's first FS, sec between FS, games between FS)";

		private const string APP_OPEN_ADS_CONDITION = "(sec in background, sec between AO, sec between FS and AO, sec between RV and AO, sec between AO and FS)";

		private Coroutine _refreshCoroutine;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshPeriodically_003Ed__16))]
		private IEnumerator RefreshPeriodically()
		{
			return null;
		}

		private void Refresh()
		{
		}

		private void ShowAdsInfo()
		{
		}

		private void ShowBannerAdInfo()
		{
		}

		private void ShowInterstitialAdInfo()
		{
		}

		private static string GetInterstitialConditionsInfo()
		{
			return null;
		}

		private void ShowAppOpenAdInfo()
		{
		}

		private static string GetAppOpenConditionsInfo()
		{
			return null;
		}

		private void ShowRewardedVideoAdInfo()
		{
		}

		private void AddDebugUnityPauseWhenDisplayingAds()
		{
		}

		private void ShowRewardedVideoCallbackPopup(bool reward)
		{
		}

		private void ShowMrecAdInfo()
		{
		}

		private void ShowAudioAdInfo()
		{
		}

		private void ShowNativeAdInfo()
		{
		}

		private void ShowBackupInterstitialInfo()
		{
		}

		private void ShowAppHarbrInfo()
		{
		}

		private static void UpdateButtonState(DebugButtonWithInputField button, AdLoadingState state)
		{
		}

		private static void UpdateButtonState(DebugButtonWithInputField button, bool enable)
		{
		}

		private static string FormatLoadingTime(AdTimer loadingTime)
		{
			return null;
		}

		private static string GetLastDisplayedBackupInterstitial()
		{
			return null;
		}

		private static string GetBackupAdsAssets()
		{
			return null;
		}

		private string GetBackupAdsApiResponse()
		{
			return null;
		}
	}
}
