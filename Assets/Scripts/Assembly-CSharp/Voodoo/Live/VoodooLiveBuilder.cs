using System;
using Voodoo.Live.Offers;
using Voodoo.Live.Shop.UI;

namespace Voodoo.Live
{
	public class VoodooLiveBuilder
	{
		private IVoodooLiveBridge _bridge;

		private Func<string, IOperator> _customOperatorFactory;

		private IDecoratorFactory<IFeature> _decoratorFactory;

		private IFeatureQueue _featureQueue;

		private IDateTimeProvider _dateTimeProvider;

		private IGameShop _shopDisplay;

		public VoodooLiveBuilder WithBridge(IVoodooLiveBridge bridge)
		{
			return null;
		}

		public VoodooLiveBuilder WithOperators(Func<string, IOperator> customFactory)
		{
			return null;
		}

		public VoodooLiveBuilder WithDecorators(IDecoratorFactory<IFeature> factory)
		{
			return null;
		}

		public VoodooLiveBuilder WithQueue(IFeatureQueue queue)
		{
			return null;
		}

		public VoodooLiveBuilder WithDateTime(IDateTimeProvider provider)
		{
			return null;
		}

		public VoodooLiveBuilder WithShopDisplay(IGameShop shopDisplay)
		{
			return null;
		}

		public void Initialize()
		{
		}
	}
}
