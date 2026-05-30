using JuicesUp.Features.SeasonPass.Internal.Data;

namespace JuicesUp.Features.SeasonPass.Internal.Repositories
{
	internal interface IBattlePassStateRepository
	{
		BattlePassState Data { get; }

		void Save();

		void ResetProgress();

		void Clear();
	}
}
