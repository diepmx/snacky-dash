using System;
using System.Collections.Generic;
using System.Threading;
using JuicesUp.Features.SeasonPass.Internal.Data;
using JuicesUp.Features.SeasonPass.Internal.Views;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IBattlePassRewardPresenter
	{
		void Initialize(CancellationToken ct);

		void Deactivate();

		void ShowChestPopup(List<BattlePassReward> rewards, string viewPrefabKey, bool grantRewards, Action onDone);

		void ShowChestPopupById(List<BattlePassReward> rewards, string chestId, Action onDone);

		void ShowTooltip(Transform parent, List<BattlePassReward> rewards);

		void InitializeRewardLayoutItem(ICustomLayoutItem layoutItem, BattlePassReward reward);

		string FormatRewardCurrency(string rewardName, int amount);
	}
}
