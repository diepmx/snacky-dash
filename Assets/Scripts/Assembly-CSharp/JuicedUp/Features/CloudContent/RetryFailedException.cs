using System;

namespace JuicedUp.Features.CloudContent
{
	public sealed class RetryFailedException : Exception
	{
		public RetryFailedException(int attempts, Exception innerException)
		{
		}
	}
}
