using System;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IServerTimeProvider
	{
		DateTime UtcTime();
	}
}
