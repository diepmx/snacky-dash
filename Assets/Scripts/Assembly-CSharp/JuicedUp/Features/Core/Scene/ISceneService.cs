using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.Core.Scene
{
	public interface ISceneService
	{
		UniTask LoadMainAsync(CancellationToken cancellationToken);

		UniTask ActivateGameSceneAsync(CancellationToken cancellationToken);

		UniTask ReturnToMainAsync(CancellationToken cancellationToken);

		bool IsSceneActive(string sceneName);
	}
}
