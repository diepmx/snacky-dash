namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassPerksService
	{
		bool IsLivesBoostActive { get; }

		int LivesBoostAmount { get; }

		void UpdatePerks();

		void Dispose();

		void RemoveAllPerks();
	}
}
