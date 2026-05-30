namespace JuicedUp.Features.Core.Ingredients
{
	public interface IIngredientUnlockPopupStateRepository
	{
		bool HasShownPopup(IngredientType type);

		void MarkPopupShown(IngredientType type);
	}
}
