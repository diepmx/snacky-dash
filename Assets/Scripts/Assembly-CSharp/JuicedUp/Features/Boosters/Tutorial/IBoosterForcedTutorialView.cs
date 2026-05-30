using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public interface IBoosterForcedTutorialView
	{
		void Show(BoosterId id);

		void Hide();
	}
}
