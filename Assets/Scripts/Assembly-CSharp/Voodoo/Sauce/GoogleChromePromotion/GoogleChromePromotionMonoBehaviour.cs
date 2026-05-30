using System;
using UnityEngine;
using Voodoo.Sauce.Privacy.UI;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionMonoBehaviour : MonoBehaviour
	{
		private enum State
		{
			NotInitialized = 0,
			DisplayBanner = 1,
			DisplayPromotionScreen = 2,
			DisplayClaimingRewardScreen = 3,
			DisplayNotDefaultBrowserScreen = 4,
			DisplayRewardScreen = 5,
			Closed = 6
		}

		public class Parameters
		{
			public GoogleChromePromotionLocalisation localisation;

			public Action download;

			public Action<Action<bool>> claimReward;

			public Action openBrowserSettings;

			public Action onDisplayPromotionScreen;

			public string countryCode;
		}

		[SerializeField]
		private GameObject _Popup;

		[SerializeField]
		private GameObject _promotionScreenPrefab;

		[SerializeField]
		private GameObject _claimingRewardScreenPrefab;

		[SerializeField]
		private GameObject _notDefaultBrowserScreenPrefab;

		[SerializeField]
		private GameObject _rewardScreenPrefab;

		private GoogleChromePromotionScreen _promotionScreen;

		private GoogleChromePromotionClaimingRewardScreen _claimingRewardScreen;

		private GoogleChromePromotionNotDefaultBrowser _notDefaultBrowserScreen;

		private GoogleChromePromotionRewardScreen _rewardScreen;

		private Parameters _parameters;

		private State _state;

		private void Start()
		{
		}

		private void OnApplicationPause(bool paused)
		{
		}

		public void Initialize(Parameters parameters)
		{
		}

		private void EnableBanner()
		{
		}

		public void DisplayPromotionScreen()
		{
		}

		private void HidePromotionScreen()
		{
		}

		private void DisplayClaimingRewardScreen()
		{
		}

		private void HideClaimingRewardScreen()
		{
		}

		private void ClaimRewardCallback(bool granted)
		{
		}

		private void DisplayNotDefaultBrowserScreen()
		{
		}

		private void HideNotDefaultBrowserScreen()
		{
		}

		private void DisplayRewardScreen()
		{
		}

		private void HideRewardScreen()
		{
		}
	}
}
