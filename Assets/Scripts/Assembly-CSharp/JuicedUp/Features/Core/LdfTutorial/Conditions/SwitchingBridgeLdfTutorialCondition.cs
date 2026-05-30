using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class SwitchingBridgeLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public SwitchingBridgeLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
