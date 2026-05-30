using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGameShop
{
	public class GrantPillView : MonoBehaviour
	{
		public Image iconImage;

		public Image bg_icon;

		public TextMeshProUGUI amountText;

		public TextMeshProUGUI labelText;

		public void Bind(Sprite icon, string amount, Sprite backGround, string label = null)
		{
		}
	}
}
