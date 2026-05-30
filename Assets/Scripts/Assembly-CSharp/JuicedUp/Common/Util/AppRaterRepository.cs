using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Common.Util
{
	public class AppRaterRepository
	{
		private readonly IDataRepository<AppRaterData> _repository;

		public AppRaterRepository(IDataRepository<AppRaterData> repository)
		{
		}

		public int LoadPromptCount()
		{
			return 0;
		}

		public void SavePromptCount(int count)
		{
		}
	}
}
