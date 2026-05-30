using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.CloudContent
{
	public interface ILevelDownloader
	{
		UniTask<LevelDataSO> DownloadLevelAsync(string ccdPath, CancellationToken ct);
	}
}
