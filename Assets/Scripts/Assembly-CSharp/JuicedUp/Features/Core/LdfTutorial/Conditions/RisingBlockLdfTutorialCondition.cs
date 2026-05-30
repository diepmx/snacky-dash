using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class RisingBlockLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public RisingBlockLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
