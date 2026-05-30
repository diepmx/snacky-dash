using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Shop.Internal.Tools
{
	internal class ShopItemGridController : MonoBehaviour
	{
		[Serializable]
		public class Layout
		{
			public int ContainersCount;

			public int MaxItemsCount;

			public Vector2 CellSize;

			public Vector2 Spacing;

			public GridLayoutGroup.Constraint Constraint;

			public int Columns;

			public RectOffset Padding;
		}

		[SerializeField]
		private GridLayoutGroup grid;

		[SerializeField]
		private List<Layout> layouts;

		public void Initialize(int containersCount, int itemCount)
		{
		}

		private Layout GetLayoutSettingsBySize(int containersCount, int itemCount)
		{
			return null;
		}
	}
}
