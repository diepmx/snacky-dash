using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public sealed class LdfTutorialRepository : ILdfTutorialRepository
	{
		private readonly IDataRepository<LdfTutorialSaveData> _dataRepository;

		public LdfTutorialRepository(IDataRepository<LdfTutorialSaveData> dataRepository)
		{
		}

		public bool HasSeen(IngredientType type)
		{
			return false;
		}

		public void MarkSeen(IngredientType type)
		{
		}
	}
}
