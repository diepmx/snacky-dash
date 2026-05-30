using System;
using System.Collections.Generic;
using System.Threading;
using JuicesUp.Features.SeasonPass.Internal.Data;
using JuicesUp.Features.SeasonPass.Internal.Views;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal sealed class BattlePassRewardPresenter : IBattlePassRewardPresenter
	{
		public void Initialize(CancellationToken ct)
		{
		}

		public void Deactivate()
		{
		}

		public void ShowChestPopup(List<BattlePassReward> rewards, string viewPrefabKey, bool grantRewards, Action onDone)
		{
		}

		public void ShowChestPopupById(List<BattlePassReward> rewards, string chestId, Action onDone)
		{
		}

		public void ShowTooltip(Transform parent, List<BattlePassReward> rewards)
		{
		}

		public void InitializeRewardLayoutItem(ICustomLayoutItem layoutItem, BattlePassReward reward)
		{
		}

		public string FormatRewardCurrency(string rewardName, int amount)
		{
			return null;
		}
	}
}
