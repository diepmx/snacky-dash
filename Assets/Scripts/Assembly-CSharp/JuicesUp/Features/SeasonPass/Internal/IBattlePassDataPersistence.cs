using JuicesUp.Features.SeasonPass.Internal.Data;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IBattlePassDataPersistence
	{
		BattlePassState Load();

		void Save(BattlePassState state);

		void Clear();
	}
}
