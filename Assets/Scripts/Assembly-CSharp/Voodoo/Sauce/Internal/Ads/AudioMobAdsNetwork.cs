using System;
using System.Runtime.CompilerServices;
using Audiomob;
using UnityEngine;
using UnityEngine.Scripting;
using Voodoo.Sauce.Internal.Analytics;

namespace Voodoo.Sauce.Internal.Ads
{
	[Preserve]
	public class AudioMobAdsNetwork : IAudioAdsNetwork
	{
		private const string TAG = "AudioMobAdsNetwork";

		private AudiomobPlugin _audioMobPlugin;

		private AudioMobCanvas _audioMobCanvas;

		private string _adUnitId;

		private bool _stoppedCalled;

		private AudioMobConfig _config;

		private bool _sdkInitialized;

		private bool _initializeCalled;

		private IAudioAdsAnalyticsManager _analytics;

		public string Name => null;

		public event Action UserSkipTriggered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action AudioAdFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action AudioAdShown
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action AudioAdClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initialize(bool consent, bool isCcpaApplicable, IAudioAdsAnalyticsManager analytics)
		{
		}

		private void OnAudioMobInitialized(bool success)
		{
		}

		public void OnApplicationPause(bool pauseStatus)
		{
		}

		public AudioAdState GetState()
		{
			return default(AudioAdState);
		}

		public bool ShowAudioAd(IAudioAdPositionBehaviour positionObject)
		{
			return false;
		}

		public void CloseAudioAd()
		{
		}

		public bool IsShowingAd()
		{
			return false;
		}

		public void OnFullscreenAdShow()
		{
		}

		public double GetLoadedCpm()
		{
			return 0.0;
		}

		private bool IsNetworkReadyToShowAd()
		{
			return false;
		}

		private void OnAdPlaybackStatusChanged(AdSequence adSequence, AdPlaybackStatus adPlaybackStatus)
		{
		}

		private void SetPosition(Vector2 percentPosition)
		{
		}

		private void OnAdClicked(string value)
		{
		}

		private void OnAdPaid(IAudioAd obj)
		{
		}

		private void OnAdFailed(string arg1, AdFailureReason arg2)
		{
		}

		private void RaiseAdTrigger(bool adLoaded)
		{
		}

		private void RaiseAdFailure<T>(T result) where T : Enum
		{
		}
	}
}
