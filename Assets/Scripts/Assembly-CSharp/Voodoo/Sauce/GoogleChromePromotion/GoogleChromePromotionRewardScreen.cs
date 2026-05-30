using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionRewardScreen : MonoBehaviour
	{
		public class Parameters
		{
			public string mainText;

			public string closeButtonText;

			public UnityAction closeAction;
		}

		[SerializeField]
		private TextMeshProUGUI _mainText;

		[SerializeField]
		private TextMeshProUGUI _closeButtonText;

		[SerializeField]
		private Button _closeButton;

		public void Initialize(Parameters parameters)
		{
		}
	}
}
