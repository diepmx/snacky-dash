using System;
using System.Threading;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.ChestPopup.Data
{
	public class ChestMilestoneRewardPopupPayload
	{
		public readonly IBundle Bundle;

		public readonly CancellationToken Token;

		public readonly Action FallBack;

		public readonly string ViewPrefabKey;

		public ChestMilestoneRewardPopupPayload(IBundle bundle, CancellationToken token = default(CancellationToken), Action fallBack = null, string viewPrefabKey = null)
		{
		}
	}
}
