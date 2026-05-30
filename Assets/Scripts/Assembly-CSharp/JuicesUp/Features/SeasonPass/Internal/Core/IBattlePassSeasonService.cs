using System;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassSeasonService
	{
		IFeature MainOffer { get; }

		bool RefreshSeasonDetection();

		TimeSpan GetTimeRemaining();

		void CheckSeasonStatus();

		void StartSeasonStatusPolling();

		void Dispose();
	}
}
