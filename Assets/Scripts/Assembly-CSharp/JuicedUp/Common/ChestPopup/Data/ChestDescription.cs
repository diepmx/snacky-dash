using System;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.ChestPopup.Data
{
	[Serializable]
	public class ChestDescription
	{
		public RarityType RarityType;

		public Sprite DefaultSprite;

		public Sprite OpenedSprite;
	}
}
