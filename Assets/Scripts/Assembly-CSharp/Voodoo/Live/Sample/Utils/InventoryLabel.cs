using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Sample.Utils
{
	public class InventoryLabel : MonoBehaviour
	{
		[Header("References")]
		public Image itemIcon;

		public TextMeshProUGUI amountTxt;

		[Header("Settings")]
		public string item;

		private void Start()
		{
		}

		private void UpdateLabel(string itemName, int amount)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
