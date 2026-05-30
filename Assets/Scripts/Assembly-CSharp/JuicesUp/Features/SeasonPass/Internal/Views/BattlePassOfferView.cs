using System;
using System.Collections.Generic;
using JuicesUp.Features.SeasonPass.Internal.Core;
using KiraganGames.Ui;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassOfferView : MonoBehaviour
	{
		private static readonly Dictionary<string, int> RewardSortOrder;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _purchaseButton;

		[SerializeField]
		private TMP_Text _priceText;

		[SerializeField]
		private CountdownTimerText _countdownTimerText;

		[SerializeField]
		private CustomLayoutItem[] _layoutItems;

		[Header("Feedback")]
		[SerializeField]
		private MMF_Player _openFeedeback;

		[SerializeField]
		private MMF_Player _closeFeedback;

		private IBattlePassManager _manager;

		private Action<bool> _onPurchaseCompleted;

		private IBattlePassAppBridge _appBridge;

		private IBattlePassRewardPresenter _rewardPresenter;

		private void Awake()
		{
		}

		private void OnCloseButtonClicked()
		{
		}

		private void OnPurchaseButtonClicked()
		{
		}

		public void Show(Action<bool> onPurchaseCompleted)
		{
		}

		private void Close()
		{
		}

		private void UpdateCanvasGroup(bool isEnabled)
		{
		}

		public void Initialise(IBattlePassManager manager, IBattlePassAppBridge appBridge, IBattlePassRewardPresenter rewardPresenter)
		{
		}

		public void UpdateView(MainViewArgs mainViewArgs)
		{
		}
	}
}
