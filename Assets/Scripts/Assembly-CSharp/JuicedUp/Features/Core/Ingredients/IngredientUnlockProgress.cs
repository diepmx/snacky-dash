namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockProgress
	{
		public IngredientDefinition Definition { get; }

		public float From01 { get; }

		public float To01 { get; }

		public bool JustUnlocked { get; }

		public IngredientUnlockProgress(IngredientDefinition definition, float from01, float to01, bool justUnlocked)
		{
		}
	}
}
