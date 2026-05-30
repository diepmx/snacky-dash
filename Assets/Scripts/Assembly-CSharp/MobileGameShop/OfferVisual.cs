using System;
using UnityEngine;

namespace MobileGameShop
{
	[Serializable]
	public class OfferVisual
	{
		public ShopSectionType shopSectionType;

		public string title;

		[TextArea]
		public string description;

		public Sprite icon;

		public Sprite background;

		public string badgeText;

		public bool showIcon;
	}
}
