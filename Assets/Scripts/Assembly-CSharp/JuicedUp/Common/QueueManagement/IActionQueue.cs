namespace JuicedUp.Common.QueueManagement
{
	public interface IActionQueue
	{
		bool Enqueue(IQueuedAction action, bool dedupeById = true);

		void Clear();

		void Reset();

		bool IsRegistered(string id);
	}
}
