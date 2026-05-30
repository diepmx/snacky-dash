using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Core.Bootstrap
{
	public interface IAsyncInitializable
	{
		UniTask InitAsync(CancellationToken cancellationToken);
	}
}
