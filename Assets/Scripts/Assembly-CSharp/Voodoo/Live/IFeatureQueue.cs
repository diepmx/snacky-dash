using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public interface IFeatureQueue : IDisposable
	{
		bool HasFeatureShown { get; }

		IComparer<IFeature> sortingFunc { get; }

		event Func<IFeature, bool> showFeature;

		event Func<IFeature, bool> filteringFunc;

		event Action OnQueueBecameActive;

		event Action OnQueueBecameIdle;

		void Show(List<IFeature> triggeringFeature);

		void Clear();
	}
}
