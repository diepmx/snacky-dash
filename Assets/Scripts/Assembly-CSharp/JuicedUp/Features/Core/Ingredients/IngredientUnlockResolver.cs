namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockResolver
	{
		private readonly IngredientUnlockConfig _config;

		public IngredientUnlockResolver(IngredientUnlockConfig config)
		{
		}

		public IngredientDefinition GetUnlockForEnteringLevel(int levelEntering)
		{
			return null;
		}

		private IngredientDefinition GetDefinitionInProgress(int levelCompleted)
		{
			return null;
		}

		public IngredientUnlockProgress CreateProgressForCompletedLevel(int levelCompleted)
		{
			return null;
		}

		private float ComputeProgress01AtLevel(IngredientDefinition definition, int level)
		{
			return 0f;
		}
	}
}
