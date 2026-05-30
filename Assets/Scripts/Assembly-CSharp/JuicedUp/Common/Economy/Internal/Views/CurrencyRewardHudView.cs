using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Views
{
	internal class CurrencyRewardHudView : RewardHudView
	{
		[Space]
		[SerializeField]
		private CanvasGroup _panel;

		[Space]
		[SerializeField]
		private Canvas _canvas;

		[field: Space]
		[field: SerializeField]
		public CurrencyId CurrencyId { get; private set; }

		public override void Show()
		{
		}

		public void ShowWithOverrideSorting()
		{
		}

		public override void Hide()
		{
		}
	}
}
