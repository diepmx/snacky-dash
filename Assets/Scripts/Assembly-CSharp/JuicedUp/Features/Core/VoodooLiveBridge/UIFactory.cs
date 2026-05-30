using Voodoo.Live.Offers;
using Voodoo.Live.Sample.Offers;

namespace JuicedUp.Features.Core.VoodooLiveBridge
{
	internal sealed class UIFactory : FeatureQueue
	{
		private readonly FeaturePopup[] _prefabs;

		private bool ShowFeature(IFeature feature)
		{
			return false;
		}
	}
}
