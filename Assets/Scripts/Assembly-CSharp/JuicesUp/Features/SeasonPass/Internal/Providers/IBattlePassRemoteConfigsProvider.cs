using JuicesUp.Features.SeasonPass.Internal.Data.RemoteConfig;

namespace JuicesUp.Features.SeasonPass.Internal.Providers
{
	internal interface IBattlePassRemoteConfigsProvider
	{
		SeasonPassConfig Data { get; }
	}
}
