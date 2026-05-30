using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public interface IFeatureDecorator
	{
		void OnStatusChanged(string status, IFeature feature);

		void Reset();
	}
}
