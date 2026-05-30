using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class BoosterRewardHudView : RewardHudView
	{
		[field: Space]
		[field: SerializeField]
		public BoosterId BoosterId { get; private set; }

		public override void Show()
		{
		}

		public override void Hide()
		{
		}
	}
}
