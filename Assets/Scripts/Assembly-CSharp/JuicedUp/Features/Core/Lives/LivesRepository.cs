using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Core.Lives
{
	public class LivesRepository
	{
		private static class LivesLog
		{
			public static void Info(string msg)
			{
			}
		}

		private readonly IDataRepository<LivesData> _repository;

		public LivesRepository(IDataRepository<LivesData> repository)
		{
		}

		public LivesState Load()
		{
			return null;
		}

		public void Save(LivesState state)
		{
		}

		private static LivesState ToLivesState(LivesData data)
		{
			return null;
		}

		private static void CopyStateToData(LivesData d, LivesState state)
		{
		}

		private static bool ApplyDefaultsIfChanged(LivesState state)
		{
			return false;
		}

		private static void Sanitize(LivesState state)
		{
		}
	}
}
