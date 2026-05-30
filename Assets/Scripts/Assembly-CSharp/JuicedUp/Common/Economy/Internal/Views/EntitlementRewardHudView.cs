using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class EntitlementRewardHudView : RewardHudView
	{
		[field: Space]
		[field: SerializeField]
		public EntitlementId EntitlementId { get; private set; }

		public override void Show()
		{
		}

		public override void Hide()
		{
		}
	}
}
