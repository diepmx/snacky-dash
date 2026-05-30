using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionClaimingRewardScreen : MonoBehaviour
	{
		public class Parameters
		{
			public string claimRewardButtonText;

			public string setDefaultBrowserButtonText;

			public UnityAction claimRewardAction;

			public UnityAction setDefaultBrowserAction;

			public UnityAction closeAction;
		}

		[SerializeField]
		private TextMeshProUGUI _claimRewardButtonText;

		[SerializeField]
		private TextMeshProUGUI _setDefaultBrowserButtonText;

		[SerializeField]
		private Button _claimRewardButton;

		[SerializeField]
		private Button _setDefaultBrowserButton;

		[SerializeField]
		private Button _closeButton;

		public void Initialize(Parameters parameters)
		{
		}
	}
}
