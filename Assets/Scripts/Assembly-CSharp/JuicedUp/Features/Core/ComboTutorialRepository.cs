using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Core
{
	public sealed class ComboTutorialRepository : IComboTutorialRepository
	{
		private readonly IDataRepository<TutorialSaveData> _dataRepository;

		public bool HasShown => false;

		public ComboTutorialRepository(IDataRepository<TutorialSaveData> dataRepository)
		{
		}

		public void MarkShown()
		{
		}
	}
}
