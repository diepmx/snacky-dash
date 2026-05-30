using System;

namespace Voodoo.Live.Offers
{
	public interface IBuyAllFeatureGroup : IFeatureGroup, IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable
	{
		IPrice BuyAllPrice { get; }

		IReward BuyAllReward { get; }

		Transaction PurchaseAll();
	}
}
