using System;
using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public interface IFeatureGroup : IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable
	{
		List<Product> Products { get; set; }

		Product SelectedProduct { get; set; }
	}
	public interface IFeatureGroup<T> : IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable where T : Product
	{
		List<T> Products { get; set; }
	}
}
