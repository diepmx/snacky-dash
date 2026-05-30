using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Core.Bootstrap.Builder;

namespace JuicedUp.Core.Bootstrap
{
	public interface ILifetimeBootstrapOrchestrator
	{
		event Action<BuildStage> OnStageCompleted;

		UniTask RunAsync(CancellationToken cancellationToken);
	}
}
