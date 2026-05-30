using Voodoo.Live.Offers;

namespace Voodoo.Live.Sample.Offers
{
	public class UIFactory : FeatureQueue
	{
		private FeaturePopup[] _prefabs;

		public bool ShowFeature(IFeature feature)
		{
			return false;
		}

		public int GetPopupIndex(IFeature feature)
		{
			return 0;
		}
	}
}
