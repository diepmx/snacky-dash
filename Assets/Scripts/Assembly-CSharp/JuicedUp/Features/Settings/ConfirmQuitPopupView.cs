using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Settings
{
	public class ConfirmQuitPopupView : BasePopupView
	{
		[Header("Hearts Preview -- shows lives AFTER losing 1")]
		[SerializeField]
		private GameObject[] _heartsFull;

		[SerializeField]
		private GameObject[] _heartsEmpty;

		[Header("Timer")]
		[SerializeField]
		private TextMeshProUGUI _timerText;

		[Header("Buttons")]
		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private Button _closeButton;

		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void RefreshUI()
		{
		}

		private void HandleSecondsChanged(int seconds)
		{
		}

		private void HandleLivesChanged(int current, int max)
		{
		}

		private void OnContinuePressed()
		{
		}

		private void OnClosePressed()
		{
		}
	}
}
