using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class BridgeLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public BridgeLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
