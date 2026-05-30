using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class SwitchingTubeLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public SwitchingTubeLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
