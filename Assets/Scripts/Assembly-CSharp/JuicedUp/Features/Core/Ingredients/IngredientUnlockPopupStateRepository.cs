using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Core.Ingredients
{
	public class IngredientUnlockPopupStateRepository : IIngredientUnlockPopupStateRepository
	{
		private readonly IDataRepository<PlayerProgressData> _repository;

		public IngredientUnlockPopupStateRepository(IDataRepository<PlayerProgressData> repository)
		{
		}

		public bool HasShownPopup(IngredientType type)
		{
			return false;
		}

		public void MarkPopupShown(IngredientType type)
		{
		}
	}
}
