using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public interface ILdfTutorialRepository
	{
		bool HasSeen(IngredientType type);

		void MarkSeen(IngredientType type);
	}
}
