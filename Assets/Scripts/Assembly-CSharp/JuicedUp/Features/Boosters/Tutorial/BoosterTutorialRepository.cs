using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public sealed class BoosterTutorialRepository : IBoosterTutorialRepository
	{
		private readonly IDataRepository<BoosterTutorialSaveData> _dataRepository;

		public event Action<BoosterId, bool> FirstFreeAvailabilityChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public BoosterTutorialRepository(IDataRepository<BoosterTutorialSaveData> dataRepository)
		{
		}

		public bool HasClaimedStarterReward(BoosterId id)
		{
			return false;
		}

		public void MarkStarterRewardClaimed(BoosterId id)
		{
		}

		public bool IsFirstFreeAvailable(BoosterId id)
		{
			return false;
		}

		public void ConsumeFirstFree(BoosterId id)
		{
		}

		public bool HasSeenForcedTutorial(BoosterId id)
		{
			return false;
		}

		public void MarkForcedTutorialSeen(BoosterId id)
		{
		}

		private bool IsFirstFreeAvailableInternal(BoosterId id)
		{
			return false;
		}
	}
}
