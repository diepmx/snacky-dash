using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial.Conditions
{
	public sealed class SecretCollectibleLdfTutorialCondition : BaseLdfTutorialCondition
	{
		public override IngredientType Type => default(IngredientType);

		public SecretCollectibleLdfTutorialCondition(ILdfTutorialRepository repository)
			: base(null)
		{
		}
	}
}
