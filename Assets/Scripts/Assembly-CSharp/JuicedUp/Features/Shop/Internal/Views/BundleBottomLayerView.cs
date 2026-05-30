using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Views
{
	[Serializable]
	internal class BundleBottomLayerView
	{
		[SerializeField]
		private TextMeshProUGUI _bundleNameText;

		[SerializeField]
		private Image _bottomLayerBackground;

		public void SetBundleName(string bundleName)
		{
		}

		public void SeLayerBackgroundColor(Color color)
		{
		}
	}
}
