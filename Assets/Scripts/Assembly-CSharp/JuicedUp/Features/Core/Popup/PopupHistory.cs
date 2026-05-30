using System.Collections.Generic;

namespace JuicedUp.Features.Core.Popup
{
	public class PopupHistory
	{
		private readonly PopupHistoryEntry[] _buffer;

		private int _head;

		private int _count;

		public PopupHistory(int capacity = 32)
		{
		}

		public void Record(PopupId id, PopupAction closedWith, float shownAtTime, float closedAtTime)
		{
		}

		public IReadOnlyList<PopupHistoryEntry> GetEntries()
		{
			return null;
		}

		public PopupHistoryEntry? GetLast()
		{
			return null;
		}

		public bool WasShownRecently(PopupId id, float withinSeconds)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
