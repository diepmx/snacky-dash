using System.Collections.Generic;

namespace JuicedUp.Features.Core.Popup
{
	internal class PopupPriorityQueue
	{
		private readonly List<PopupRequest> _items;

		public int Count => 0;

		public void Enqueue(PopupRequest request)
		{
		}

		public PopupRequest Dequeue()
		{
			return default(PopupRequest);
		}

		public PopupRequest Peek()
		{
			return default(PopupRequest);
		}

		public bool Contains(PopupId id)
		{
			return false;
		}

		public bool Remove(PopupId id)
		{
			return false;
		}

		public void EnqueueFirst(PopupRequest request)
		{
		}

		public void Clear()
		{
		}
	}
}
