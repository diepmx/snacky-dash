using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Voodoo.Sauce.Privacy.UI
{
	public class GoogleChromePromotionNotDefaultBrowser : MonoBehaviour
	{
		public class Parameters
		{
			public string mainText;

			public string setDefaultBrowserButtonText;

			public UnityAction setDefaultBrowserAction;

			public UnityAction closeAction;
		}

		[SerializeField]
		private TextMeshProUGUI _mainText;

		[SerializeField]
		private TextMeshProUGUI _setDefaultBrowserButtonText;

		[SerializeField]
		private Button _setDefaultBrowserButton;

		[SerializeField]
		private Button _closeButton;

		public void Initialize(Parameters parameters)
		{
		}
	}
}
