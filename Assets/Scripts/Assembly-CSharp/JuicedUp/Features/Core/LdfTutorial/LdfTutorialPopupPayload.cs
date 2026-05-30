using JuicedUp.Features.Core.Ingredients;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public sealed class LdfTutorialPopupPayload : IPopupPayload
	{
		public readonly IngredientType Type;

		public readonly string Title;

		public readonly string Subtitle;

		public readonly string Description;

		public readonly Sprite Icon;

		public LdfTutorialPopupPayload(IngredientType type, string title, string subtitle, string description, Sprite icon)
		{
		}
	}
}
