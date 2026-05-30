using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AppHarbrSdkCallbacks : MonoBehaviour
{
	public static AppHarbrSdkCallbacks Instance { get; private set; }

	public static event Action<string> OnAppHarbrInitializationComplete
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

	public static event Action<AHIncidentData> OnAdBlockedEvent
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

	public static event Action<AHIncidentData> OnAdIncidentEvent
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

	public static event Action<AHIncidentData> OnAdAnalyzedEvent
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

	private void Awake()
	{
	}

	internal void HandleBackgroundCallback(string propsStr)
	{
	}

	internal void ForwardEvent(string eventPropsStr)
	{
	}

	public void ProcessWatchAppAds()
	{
	}

	private void ProcessBannerAds(List<WatchAppHarbrBannerAd> bannerAds)
	{
	}

	private void ProcessMRECAds(List<WatchAppHarbrBannerAd> mrecAds)
	{
	}

	private void ProcessFullScreenAds(List<string> adUnitIds, Action<string> adAction)
	{
	}
}
