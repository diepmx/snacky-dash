using JuicedUp.Common.FeatureOriented;
using UniRx;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionsFeatureStatusProvider : IFeatureAvailabilityProvider
	{
		public ReactiveProperty<bool> IsAvailable { get; }

		public ReactiveProperty<bool> IsInitialized { get; }

		public void Initialize()
		{
		}

		private bool CheckAvailability()
		{
			return false;
		}
	}
}
