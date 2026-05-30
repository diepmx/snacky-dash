using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public interface IBoosterCatalog
	{
		bool TryGetBoosterUnlockingAt(int level, out BoosterId boosterId);
	}
}
