using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Common.QueueManagement
{
	public sealed class QueuedAction : IQueuedAction
	{
		private readonly Func<bool> _canShow;

		private readonly Func<CancellationToken, UniTask> _run;

		public string Id { get; }

		public int Priority { get; }

		public QueuedAction(string id, QueuedActionPriority priority, Func<bool> canShow, Func<CancellationToken, UniTask> run)
		{
		}

		public bool CanShow()
		{
			return false;
		}

		public UniTask RunAsync(CancellationToken ct)
		{
			return default(UniTask);
		}
	}
}
