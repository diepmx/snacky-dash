using JuicesUp.Features.SeasonPass.Internal.Data;

namespace JuicesUp.Features.SeasonPass.Internal.Repositories
{
	internal class BattlePassStateRepository : IBattlePassStateRepository
	{
		private readonly IBattlePassDataPersistence _persistence;

		public BattlePassState Data => null;

		public BattlePassStateRepository(IBattlePassDataPersistence persistence)
		{
		}

		public void Save()
		{
		}

		public void ResetProgress()
		{
		}

		public void Clear()
		{
		}
	}
}
