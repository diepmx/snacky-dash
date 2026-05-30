namespace JuicedUp.Features.Core.Popup
{
	public readonly struct PopupHistoryEntry
	{
		public PopupId Id { get; }

		public PopupAction ClosedWith { get; }

		public float ShownAtTime { get; }

		public float ClosedAtTime { get; }

		public PopupHistoryEntry(PopupId id, PopupAction closedWith, float shownAtTime, float closedAtTime)
		{
			Id = default(PopupId);
			ClosedWith = default(PopupAction);
			ShownAtTime = 0f;
			ClosedAtTime = 0f;
		}
	}
}
