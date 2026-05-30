using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.Boosters.Shuffle
{
	public interface IShuffleVortexVfxController : IDisposable
	{
		UniTask PlayAsync(CancellationToken cancellationToken);
	}
}
