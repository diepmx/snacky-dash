using System;
using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Views
{
	[Serializable]
	internal class ShopSectionView
	{
		[SerializeField]
		private GameObject _shopSection;

		[SerializeField]
		private Transform _productsContainer;

		public Transform ProductsContainer => null;
	}
}
