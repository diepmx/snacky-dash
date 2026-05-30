using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Common.Ftue
{
	internal class FtueRepository : IFtueRepository
	{
		private readonly IDataRepository<FtueSaveData> _dataRepository;

		public bool IsTutorialCompleted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FtueRepository(IDataRepository<FtueSaveData> dataRepository)
		{
		}
	}
}
