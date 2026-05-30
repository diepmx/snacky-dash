using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace JuicedUp.Core.Bootstrap
{
	public sealed class LevelEntryPoint : IAsyncStartable
	{
		private readonly ILifetimeBootstrapOrchestrator _orchestrator;

		public LevelEntryPoint(ILifetimeBootstrapOrchestrator orchestrator)
		{
		}

		public UniTask StartAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}
