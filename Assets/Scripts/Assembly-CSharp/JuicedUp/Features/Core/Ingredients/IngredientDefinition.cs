using System;
using UnityEngine;

namespace JuicedUp.Features.Core.Ingredients
{
	[Serializable]
	public class IngredientDefinition
	{
		public string name;

		public IngredientType type;

		public Sprite icon;

		public string tutorialTitle;

		[TextArea]
		public string tutorialDescription;

		public int levelToStartShowingUp;

		public int levelToUnlock;

		public string ResolveDisplayTitle()
		{
			return null;
		}
	}
}
