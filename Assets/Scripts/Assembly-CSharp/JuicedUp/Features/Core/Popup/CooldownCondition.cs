namespace JuicedUp.Features.Core.Popup
{
	public class CooldownCondition : IPopupCondition
	{
		private readonly PopupId _popupId;

		private readonly float _cooldownSeconds;

		public CooldownCondition(PopupId popupId, float cooldownSeconds)
		{
		}

		public bool IsMet(PopupContext popupContext)
		{
			return false;
		}
	}
}
