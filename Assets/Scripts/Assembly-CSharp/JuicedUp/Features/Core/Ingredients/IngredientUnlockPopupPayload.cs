using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockPopupPayload : IPopupPayload
	{
		public Sprite Icon { get; }

		public string FeatureName { get; }

		public IngredientUnlockPopupPayload(Sprite icon, string featureName)
		{
		}
	}
}
