using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class TunnelLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public TunnelLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
