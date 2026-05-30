using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.Tutorial
{
	[Serializable]
	public class BoosterTutorialSaveData
	{
		public List<BoosterId> StarterRewardClaimed;

		public List<BoosterId> FirstFreeUsed;

		public List<BoosterId> ForcedTutorialSeen;
	}
}
