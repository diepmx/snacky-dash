using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core.Popup;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public sealed class BoosterTutorialPopupPayload : IPopupPayload
	{
		public readonly BoosterId BoosterId;

		public readonly string Title;

		public readonly string Description;

		public readonly Sprite Icon;

		public BoosterTutorialPopupPayload(BoosterId boosterId, string title, string description, Sprite icon)
		{
		}
	}
}
