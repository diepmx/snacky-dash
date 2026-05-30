using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassPurchaseButtonView : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private TMP_Text _activatedText;

		private Action _onPurchaseButtonClicked;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnPremiumPurchased()
		{
		}

		public void Initialise(bool isPremiumActivated, bool hasEnded, Action onPurchaseButtonClick)
		{
		}

		public void UpdateView(bool isPremiumActivated)
		{
		}

		private void OnButtonClicked()
		{
		}
	}
}
