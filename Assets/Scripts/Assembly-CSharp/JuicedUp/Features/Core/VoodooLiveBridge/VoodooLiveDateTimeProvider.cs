using System;
using JuicedUp.Common.Time;
using Voodoo.Live;

namespace JuicedUp.Features.Core.VoodooLiveBridge
{
	internal sealed class VoodooLiveDateTimeProvider : IDateTimeProvider
	{
		private readonly IServerTimeProvider _serverTimeProvider;

		public DateTime Now => default(DateTime);

		public DateTime Today => default(DateTime);

		public VoodooLiveDateTimeProvider(IServerTimeProvider serverTimeProvider)
		{
		}
	}
}
