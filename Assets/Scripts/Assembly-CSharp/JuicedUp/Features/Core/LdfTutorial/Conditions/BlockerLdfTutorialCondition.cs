using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class BlockerLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public BlockerLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
