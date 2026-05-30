using System;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IDebugBattlePassTimeOverride
	{
		void SetDebugTimeOffset(TimeSpan? offset);
	}
}
