using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class Label : MonoBehaviour
	{
		public enum OfferType
		{
			OFFER = 0,
			TWOPO = 1,
			NPO = 2,
			SPIN = 3
		}

		[Header("References")]
		[SerializeField]
		private TextMeshProUGUI _labelText;

		[SerializeField]
		private Button _labelBtn;

		[SerializeField]
		private Transform _arrow;

		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private Image _offerIcon;

		[SerializeField]
		private Sprite[] _offersSprites;

		public List<GameObject> itemsInContent;

		private string _name;

		public void Init(string labelName, string data)
		{
		}

		public void SetupOfferUI(OfferType offerType)
		{
		}

		private void OnClick(string data)
		{
		}

		public void Toggle(bool value)
		{
		}
	}
}
