using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Features.Core;

namespace JuicedUp.Features.LoseTutorial
{
	public sealed class LoseTutorialRepository : ILoseTutorialRepository
	{
		private readonly IDataRepository<TutorialSaveData> _dataRepository;

		public bool HasShown => false;

		public LoseTutorialRepository(IDataRepository<TutorialSaveData> dataRepository)
		{
		}

		public void MarkShown()
		{
		}
	}
}
