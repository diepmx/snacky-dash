using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voodoo.Live
{
	public interface IReloadableClient : IClient, IDisposable
	{
		ReloadState CurrentReloadState { get; }

		DateTime LastReloadAppliedAt { get; }

		bool HasBlockers { get; }

		IReadOnlyList<string> ActiveBlockers { get; }

		event Action reloadApplied;

		event Action<string> reloadFailed;

		void AddReloadBlocker(string blocker);

		void RemoveReloadBlocker(string blocker);

		Task Reload();
	}
}
