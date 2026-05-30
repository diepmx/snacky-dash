using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class GateLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public GateLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
