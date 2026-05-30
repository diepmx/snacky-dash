using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	[Serializable]
	internal class ProductLabelView
	{
		[SerializeField]
		private GameObject _labelRoot;

		[SerializeField]
		private Image _labelBackground;

		[SerializeField]
		private TextMeshProUGUI _labelText;

		public void SetLabelActiveValue(bool value)
		{
		}

		public void SetLabelText(string text)
		{
		}

		public void SetLabelBackgroundColor(Color color)
		{
		}
	}
}
