using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Sauce.IAP;

namespace Voodoo.Sauce.Debugger
{
	public class IAPProductWidget : Widget
	{
		[SerializeField]
		private GameObject _statusAvailable;

		[SerializeField]
		private GameObject _statusMissing;

		[SerializeField]
		private GameObject _statusBadID;

		[SerializeField]
		private GameObject _statusOwned;

		[SerializeField]
		private TextMeshProUGUI _productId;

		[SerializeField]
		private TextMeshProUGUI _details;

		[SerializeField]
		private Button _copyButton;

		private void Awake()
		{
		}

		internal void Refresh(IAPDebugProduct product)
		{
		}

		private void UpdateStatus(IAPDebugProduct.Status status)
		{
		}

		private void SetProductID(string text)
		{
		}

		private void SetDetails(string details)
		{
		}
	}
}
