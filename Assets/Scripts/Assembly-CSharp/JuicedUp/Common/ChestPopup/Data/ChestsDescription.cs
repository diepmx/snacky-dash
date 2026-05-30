using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.ChestPopup.Data
{
	[CreateAssetMenu(fileName = "ChestDescription", menuName = "ChestDescription")]
	public class ChestsDescription : ScriptableObject, IChestsDescription
	{
		[SerializeField]
		private List<ChestDescription> _descriptions;

		public ChestDescription GetDescriptionByRarityType(RarityType rarity)
		{
			return null;
		}
	}
}
