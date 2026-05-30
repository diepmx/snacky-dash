using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core.Ingredients
{
	[CreateAssetMenu(menuName = "JuicedUp/Ingredients/Ingredient Unlock Config", fileName = "IngredientUnlockConfig")]
	public class IngredientUnlockConfig : ScriptableObject
	{
		[Tooltip("Ordered by unlock progression.")]
		public List<IngredientDefinition> definitions;

		public bool TryGetDefinition(IngredientType type, out IngredientDefinition definition)
		{
			definition = null;
			return false;
		}
	}
}
