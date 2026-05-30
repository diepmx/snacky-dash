using System;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Common.Economy.Public
{
	public class RewardPopupPayload
	{
		public readonly IBundle Bundle;

		public readonly string PopupTitleKey;

		public readonly string ViewPrefabKey;

		public readonly Action OnClaim;

		public RewardPopupPayload(IBundle bundle, string viewPrefabKey, string popupTitleKey = null, Action onClaim = null)
		{
		}
	}
}
