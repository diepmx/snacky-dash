using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Voodoo.Sauce.GoogleChromePromotion
{
	public class GoogleChromePromotionScreen : MonoBehaviour
	{
		public class Parameters
		{
			public string text;

			public string downloadButtonText;

			public UnityAction downloadAction;

			public UnityAction closeAction;
		}

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private TextMeshProUGUI _downloadButtonText;

		[SerializeField]
		private Button _downloadButton;

		[SerializeField]
		private Button _closeButton;

		public void Initialize(Parameters parameters)
		{
		}
	}
}
