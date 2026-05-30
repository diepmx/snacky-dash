using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class SwitchingArrowLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public SwitchingArrowLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
