namespace JuicedUp.Features.Core.Popup
{
	public class ScheduledPopupEntry
	{
		public PopupId Id { get; }

		public PopupPriority Priority { get; }

		public IPopupPayload Payload { get; }

		public float DelaySeconds { get; }

		private IPopupCondition[] Conditions { get; }

		public ScheduledPopupEntry(PopupId id, PopupPriority priority, float delaySeconds, params IPopupCondition[] conditions)
		{
		}

		public ScheduledPopupEntry(PopupId id, PopupPriority priority = PopupPriority.Normal, IPopupPayload payload = null, float delaySeconds = 0f, params IPopupCondition[] conditions)
		{
		}

		public bool CanShow(PopupContext ctx)
		{
			return false;
		}
	}
}
