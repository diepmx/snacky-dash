using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Common.QueueManagement
{
	public static class QueueAsync
	{
		public static UniTask FromCallback(Action<Action> starter, CancellationToken ct = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask FromCallback(Func<Action, UniTask> starter, CancellationToken ct = default(CancellationToken))
		{
			return default(UniTask);
		}
	}
}
