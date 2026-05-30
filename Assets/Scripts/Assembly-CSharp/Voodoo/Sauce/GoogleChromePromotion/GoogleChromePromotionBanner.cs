using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionBanner : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text1;

		[SerializeField]
		private TextMeshProUGUI _text2;

		[SerializeField]
		private TextMeshProUGUI _install;

		[SerializeField]
		private Button _installButton;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private GoogleChromePromotionMonoBehaviour _googleChromePromotion;

		public void Start()
		{
		}
	}
}
