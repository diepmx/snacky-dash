using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Common.QueueManagement
{
	public interface IQueuedAction
	{
		string Id { get; }

		int Priority { get; }

		bool CanShow();

		UniTask RunAsync(CancellationToken ct);
	}
}
