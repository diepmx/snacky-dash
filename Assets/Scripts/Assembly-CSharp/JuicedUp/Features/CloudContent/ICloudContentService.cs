using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.CloudContent
{
	public interface ICloudContentService
	{
		CloudContentState State { get; }

		CloudFunnelData FunnelData { get; }

		UniTask WaitForReadyAsync(TimeSpan timeout, CancellationToken ct);
	}
}
