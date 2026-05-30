using UniRx;

namespace JuicedUp.Common.FeatureOriented
{
	public interface IFeatureAvailabilityProvider
	{
		ReactiveProperty<bool> IsAvailable { get; }

		ReactiveProperty<bool> IsInitialized { get; }

		void Initialize();
	}
}
